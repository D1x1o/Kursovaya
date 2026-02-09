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
        public void SaveMakeCheck(string[] itemsNames, int[] itemsCosts, int[] itemsCounts, string orderDateTime, string orderCompDateTime) 
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
            int rows = itemsNames.Length + 2; // заголовок + итог
            int cols = 4; // Товар | Цена | Количество | Подытог

            Word.Table table = doc.Tables.Add(p3.Range, rows, cols);
            table.Borders.Enable = 1;

            // Заголовки
            table.Cell(1, 1).Range.Text = "Товар";
            table.Cell(1, 2).Range.Text = "Цена";
            table.Cell(1, 3).Range.Text = "Количество";
            table.Cell(1, 4).Range.Text = "Подытог";

            int total = 0;

            // Заполнение таблицы
            for (int i = 0; i < itemsNames.Length; i++)
            {
                int subtotal = itemsCosts[i] * itemsCounts[i];
                total += subtotal;

                table.Cell(i + 2, 1).Range.Text = itemsNames[i];
                table.Cell(i + 2, 2).Range.Text = getMakedString(itemsCosts[i].ToString());
                table.Cell(i + 2, 3).Range.Text = itemsCounts[i].ToString();
                table.Cell(i + 2, 4).Range.Text = getMakedString(subtotal.ToString());
            }

            // ===== ИТОГО =====
            table.Cell(rows, 1).Range.Text = "ИТОГО:";
            table.Cell(rows, 4).Range.Text = getMakedString(total.ToString());

            // Объединяем ячейки ИТОГО
            table.Cell(rows, 1).Merge(table.Cell(rows, 3));

            // Делаем жирным
            table.Cell(rows, 1).Range.Font.Bold = 1;
            table.Cell(rows, 4).Range.Font.Bold = -1;

            
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
