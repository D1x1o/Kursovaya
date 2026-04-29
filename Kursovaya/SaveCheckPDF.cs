using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

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
            string path = Path.Combine(Path.GetTempPath(), $"Receipt_{Guid.NewGuid()}.pdf");

            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "pepe.png");

            if (File.Exists(imagePath))
            {
                XImage logo = XImage.FromFile(imagePath);

                // рисуем в левом верхнем углу
                gfx.DrawImage(logo, 40, 20, 100, 100);
            }
            XFont title = new XFont("Arial", 16);
            XFont bold = new XFont("Arial", 11);
            XFont font = new XFont("Arial", 10);

            double y = 40;

            void DrawCenter(string text, XFont f)
            {
                gfx.DrawString(text, f, XBrushes.Black,
                    new XRect(0, y, page.Width, page.Height),
                    XStringFormats.TopCenter);
                y += 18;
            }

            void DrawLeft(string text, XFont f)
            {
                gfx.DrawString(text, f, XBrushes.Black, new XPoint(40, y));
                y += 15;
            }

            // ===== HEADER =====
            DrawCenter("pepeShop", title);
            DrawCenter("ЧЕК", title);

            DrawCenter($"Дата заказа: {orderDateTime}", font);
            DrawCenter($"Дата выполнения: {orderCompDateTime}", font);

            if (!string.IsNullOrWhiteSpace(phone_number))
                DrawCenter("Телефон: " + phone_number, font);

            if (!string.IsNullOrWhiteSpace(delivery_address))
                DrawCenter("Адрес: " + delivery_address, font);

            DrawCenter("ИНН: 0000000000", font);
            DrawCenter("Смена: 0000", font);
            Random r = new Random();
            DrawCenter($"Чек номер: {r.Next(1000, 9999)}", font);
            y += 15;

            // ===== TABLE HEADER =====
            double x1 = 40;   // товар
            double x2 = 300;  // цена
            double x3 = 380;  // кол-во
            double x4 = 460;  // подытог

            gfx.DrawString("Товар", bold, XBrushes.Black, new XPoint(x1, y));
            gfx.DrawString("Цена", bold, XBrushes.Black, new XPoint(x2, y));
            gfx.DrawString("Кол-во", bold, XBrushes.Black, new XPoint(x3, y));
            gfx.DrawString("Подытог", bold, XBrushes.Black, new XPoint(x4, y));

            y += 12;
            gfx.DrawLine(XPens.Black, 40, y, 550, y);
            y += 15;

            // ===== ITEMS =====
            int total = 0;

            for (int i = 0; i < itemsNames.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(itemsNames[i]))
                    continue;

                int subtotal = itemsCosts[i] * itemsCounts[i];
                total += subtotal;

                gfx.DrawString(itemsNames[i], font, XBrushes.Black, new XPoint(x1, y));
                gfx.DrawString(Format(itemsCosts[i]), font, XBrushes.Black, new XPoint(x2, y));
                gfx.DrawString(itemsCounts[i].ToString(), font, XBrushes.Black, new XPoint(x3, y));
                gfx.DrawString(Format(subtotal), font, XBrushes.Black, new XPoint(x4, y));

                y += 16;
            }

            // ===== DELIVERY =====
            int deliveryCost = delivery ? 3000 : 0;
            gfx.DrawString("Доставка", font, XBrushes.Black, new XPoint(x1, y));
            gfx.DrawString(Format(deliveryCost), font, XBrushes.Black, new XPoint(x2, y));
            gfx.DrawString(delivery ? "1" : "0", font, XBrushes.Black, new XPoint(x3, y));
            gfx.DrawString(Format(deliveryCost), font, XBrushes.Black, new XPoint(x4, y));
            y += 16;

            // ===== BUILD =====
            int buildCost = build ? 3000 : 0;
            gfx.DrawString("Сборка", font, XBrushes.Black, new XPoint(x1, y));
            gfx.DrawString(Format(buildCost), font, XBrushes.Black, new XPoint(x2, y));
            gfx.DrawString(build ? "1" : "0", font, XBrushes.Black, new XPoint(x3, y));
            gfx.DrawString(Format(buildCost), font, XBrushes.Black, new XPoint(x4, y));
            y += 16;

            // ===== DISCOUNT =====
            int discount = (delivery && build) ? 2000 : 0;

            gfx.DrawString("Скидка", font, XBrushes.Black, new XPoint(x1, y));
            gfx.DrawString("", font, XBrushes.Black, new XPoint(x2, y));
            gfx.DrawString("", font, XBrushes.Black, new XPoint(x3, y));
            gfx.DrawString(Format(discount), font, XBrushes.Black, new XPoint(x4, y));
            y += 20;

            // ===== TOTAL =====
            int grandTotal = total + deliveryCost + buildCost - discount;

            gfx.DrawLine(XPens.Black, 40, y, 550, y);
            y += 20;

            gfx.DrawString("ИТОГО:", bold, XBrushes.Black, new XPoint(x1, y));
            gfx.DrawString(Format(grandTotal), bold, XBrushes.Black, new XPoint(x4, y));
            
            y += 30;
           
            DrawCenter("Спасибо за покупку!", font);

            doc.Save(path);
            doc.Close();

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private string Format(int value)
        {
            return value.ToString("N0").Replace(",", " ") + " ₽";
        }
    }
}