using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Kursovaya
{
    internal class SaveCheckPDF
    {
        public void SaveMakeCheck(

            string[] itemsNames,
            int[] itemsCosts,
            int[] itemsCounts,
            string orderDateTime,
            string orderCompDateTime,
            bool delivery,
            bool build,
            string phone_number,
            string delivery_address)
        {
            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts", "arialmt.ttf");

            if (!File.Exists(fontPath))
            {
                throw new Exception("Файл шрифта НЕ найден: " + fontPath);
            }
            //MessageBox.Show(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts"));
            var font = PdfFontFactory.CreateFont(
    fontPath,
    PdfEncodings.IDENTITY_H
);

            var boldFont = PdfFontFactory.CreateFont(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts", "arialbolditalicmt.ttf"),
                PdfEncodings.IDENTITY_H
            );
            string path = Path.Combine(
            Path.GetTempPath(),
            $"Receipt_{Guid.NewGuid()}.pdf"
            );
            using (var writer = new PdfWriter(path))
            using (var pdf = new PdfDocument(writer))
            using (var doc = new Document(pdf))
            {
                // ===== Магазин =====
                doc.Add(new Paragraph("pepeShop")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(26)
                    .SetFont(boldFont));

                // ===== ЧЕК =====
                doc.Add(new Paragraph("ЧЕК")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(16)
                    .SetFont(boldFont));

                // ===== Даты =====
                doc.Add(new Paragraph(
                    $"Дата заказа: {orderDateTime}\nДата выполнения: {orderCompDateTime}")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFont(font)
                    .SetFontSize(12));

                // ===== Телефон =====
                if (!string.IsNullOrWhiteSpace(phone_number))
                {
                    doc.Add(new Paragraph("Телефон: " + phone_number)
                    .SetFont(font)
                        .SetTextAlignment(TextAlignment.CENTER));
                }

                // ===== Адрес =====
                if (!string.IsNullOrWhiteSpace(delivery_address))
                {
                    doc.Add(new Paragraph("Адрес: " + delivery_address)
                    .SetFont(font)
                        .SetTextAlignment(TextAlignment.CENTER));
                }

                doc.Add(new Paragraph("\n"));

                // ===== Подсчёт товаров =====
                int counter = 0;
                for (int i = 0; i < itemsNames.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(itemsNames[i]))
                        counter++;
                }

                int itemsRows = counter;
                int extraRows = 4;
                int totalRows = itemsRows + 1 + extraRows;

                // ===== Таблица =====
                Table table = new Table(4).UseAllAvailableWidth();
                table.SetFont(font);
                table.AddHeaderCell("Товар");
                table.AddHeaderCell("Цена");
                table.AddHeaderCell("Кол-во");
                table.AddHeaderCell("Подытог");

                int total = 0;
                int j = 0;

                for (int i = 0; i < itemsNames.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(itemsNames[i]))
                        continue;

                    int subtotal = itemsCosts[i] * itemsCounts[i];
                    total += subtotal;

                    table.AddCell(itemsNames[i]);
                    table.AddCell(getMakedString(itemsCosts[i].ToString()));
                    table.AddCell(itemsCounts[i].ToString());
                    table.AddCell(getMakedString(subtotal.ToString()));

                    j++;
                }

                // ===== ДОСТАВКА =====
                table.AddCell("Доставка");
                table.AddCell(delivery ? "3 000 ₽" : "0 ₽");
                table.AddCell(delivery ? "1" : "0");
                table.AddCell(delivery ? "3 000 ₽" : "0 ₽");

                // ===== СБОРКА =====
                table.AddCell("Сборка");
                table.AddCell(build ? "3 000 ₽" : "0 ₽");
                table.AddCell(build ? "1" : "0");
                table.AddCell(build ? "3 000 ₽" : "0 ₽");

                // ===== СКИДКА =====
                table.AddCell(new Cell(1, 3).Add(new Paragraph("Скидка")));
                table.AddCell((build && delivery) ? "2 000 ₽" : "0 ₽");

                // ===== ИТОГО =====
                int grandTotal = total
                    + (delivery ? 3000 : 0)
                    + (build ? 3000 : 0)
                    - ((build && delivery) ? 2000 : 0);

                table.AddCell(new Cell(1, 3)
                    .Add(new Paragraph("ИТОГО:").SetFont(boldFont)));

                table.AddCell(new Paragraph(getMakedString(grandTotal.ToString()))
                    .SetFont(font)
                    .SetFont(boldFont));

                doc.Add(table);

                doc.Add(new Paragraph("\nСпасибо за покупку!")
                    .SetFont(font)
                    .SetTextAlignment(TextAlignment.CENTER));
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private string getMakedString(string cartSumStr)
        {
            string cost = "";
            string reversed = new string(cartSumStr.Reverse().ToArray());

            for (int j = 0; j < reversed.Length; j++)
            {
                cost += reversed[j];
                if ((j + 1) % 3 == 0 && j != reversed.Length - 1)
                    cost += " ";
            }

            return new string(cost.Reverse().ToArray()) + " ₽";
        }
    }
}