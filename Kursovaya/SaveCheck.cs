using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kursovaya
{
    internal class SaveCheck
    {
        public void SaveMakeCheck(string[] itemsNames, int[] itemsCosts, int[] itemsCounts, string orderDateTime, string orderCompDateTime, bool delivery, bool build) 
        {
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = true;

            
            Word.Document doc = wordApp.Documents.Add();
            string dateStr = DateTime.Now.ToString("dd.MM.yyyy");
            string docTitle = $"ЧЕК - {dateStr}";

            // Устанавливаем имя в заголовке окна Word
            doc.ActiveWindow.Caption = docTitle;
            // ===== Название магазина =====
            Word.Paragraph p = doc.Paragraphs.Add();
            p.Range.Text = "pepeShop";
            p.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            p.Range.Font.Size = 26;
            p.Range.Font.Bold = 1;
            p.Range.InsertParagraphAfter();

            doc.Paragraphs.Add();

            // ===== ЧЕК =====
            Word.Paragraph p2 = doc.Paragraphs.Add();
            p2.Range.Text = "ЧЕК";
            p2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            p2.Range.Font.Size = 16;
            p2.Range.Font.Bold = 1;
            p2.Range.InsertParagraphAfter();

            // ===== Даты =====
            Word.Paragraph p3 = doc.Paragraphs.Add();
            p3.Range.Text = "Дата заказа: " + orderDateTime +
                            "\nДата выполнения: " + orderCompDateTime + "\n";
            p3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            p3.Range.Font.Size = 12;
            p3.Range.Font.Bold = 0;
            p3.Range.InsertParagraphAfter();

            // ===== ТАБЛИЦА =====
            int counter = 0;
            for (int i = 0; i < itemsNames.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(itemsNames[i])) { continue; }
                else counter++;
            }
            int rows = counter + 2; // заголовок + итог

            // ===== Подсчёт строк =====
            int itemsRows = counter;         // количество товаров
            int extraRows = 4;                         // Доставка, Сборка, Скидка, ИТОГО
            int totalRows = itemsRows + 1 + extraRows; // +1 для заголовка

            Word.Table table = doc.Tables.Add(p3.Range, totalRows, 4);
            table.Borders.Enable = 1;

            // ===== Задание ширины столбцов =====
            table.Columns[1].Width = 200f; // Товар — широкий
            table.Columns[2].Width = 80f;  // Цена — узкий
            table.Columns[3].Width = 60f;  // Количество
            table.Columns[4].Width = 100f; // Подытог

            // ===== Заголовки =====
            table.Cell(1, 1).Range.Text = "Товар";
            table.Cell(1, 2).Range.Text = "Цена";
            table.Cell(1, 3).Range.Text = "Количество";
            table.Cell(1, 4).Range.Text = "Подытог";

            int total = 0;

            // ===== Товары =====
            for (int i = 0; i < itemsNames.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(itemsNames[i]))
                {
                    continue;
                }
                int subtotal = itemsCosts[i] * itemsCounts[i];
                total += subtotal;

                table.Cell(i + 2, 1).Range.Text = itemsNames[i];
                table.Cell(i + 2, 2).Range.Text = getMakedString(itemsCosts[i].ToString());
                table.Cell(i + 2, 3).Range.Text = itemsCounts[i].ToString();
                table.Cell(i + 2, 4).Range.Text = getMakedString(subtotal.ToString());
            }

            // ===== ДОСТАВКА =====
            int rowIndex = itemsRows + 2; // следующая строка после товаров
            table.Cell(rowIndex, 1).Range.Text = "Доставка";
            table.Cell(rowIndex, 2).Range.Text = delivery ? "3 000 ₽" : "0 ₽";
            table.Cell(rowIndex, 3).Range.Text = delivery ? "1" : "0";
            table.Cell(rowIndex, 4).Range.Text = delivery ? "3 000 ₽" : "0 ₽";

            // ===== СБОРКА =====
            rowIndex++;
            table.Cell(rowIndex, 1).Range.Text = "Сборка";
            table.Cell(rowIndex, 2).Range.Text = build ? "3 000 ₽" : "0 ₽";
            table.Cell(rowIndex, 3).Range.Text = build ? "1" : "0";
            table.Cell(rowIndex, 4).Range.Text = build ? "3 000 ₽" : "0 ₽";

            // ===== СКИДКА =====
            rowIndex++;
            table.Cell(rowIndex, 1).Range.Text = "Скидка";
            table.Cell(rowIndex, 4).Range.Text = (build && delivery) ? "2 000 ₽" : "0 ₽";
            table.Cell(rowIndex, 1).Merge(table.Cell(rowIndex, 3)); // объединяем колонки 1-3 для скидки

            // ===== ИТОГО =====
            rowIndex++;
            int grandTotal = total + (delivery ? 3000 : 0) + (build ? 3000 : 0) - ((build && delivery) ? 2000 : 0);
            table.Cell(rowIndex, 1).Range.Text = "ИТОГО:";
            table.Cell(rowIndex, 4).Range.Text = getMakedString(grandTotal.ToString());
            table.Cell(rowIndex, 1).Merge(table.Cell(rowIndex, 3));
            table.Cell(rowIndex, 1).Range.Font.Bold = 1;
            table.Cell(rowIndex, 2).Range.Font.Bold = 1;
        }

        private string getMakedString(string cartSumStr)
        {
            string cost = "";
            string cartSumReversed = new String(cartSumStr.Reverse().ToArray());
            for (int j = 0; j < cartSumReversed.Length; j++)
            {
                cost += cartSumReversed[j];
                if ((j + 1) % 3 == 0 && j != cartSumReversed.Length - 1)
                {
                    cost += " ";
                }
            }
            return new String(cost.Reverse().ToArray()) + " ₽";
        }
    }
}
