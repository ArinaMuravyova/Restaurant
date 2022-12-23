using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

using PDFImage = iTextSharp.text.Image;
using BLL.Models;
using System.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Restaurant.Utils
{
    /// <summary>
    /// Класс для работы с PDF файлами
    /// </summary>
    public class PDFWriter
    {
        /// <summary>
        /// Сохранить информацию о пользователе в файл
        /// </summary>
        /// <param name="order">заказ</param>
        /// <param name="listOrderLines">строки заказа</param>
        /// <param name="filePath">Путь к файлу</param>
        public static void WriteCheck(OrderModel order,ObservableCollection<OrderLineModel> listOrderLines, string filePath) 
        { 
            var document = new Document();
           
            try
            {
                var baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                var font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
                var fontB = new Font(baseFont, Font.DEFAULTSIZE, Font.BOLD);

                using (FileStream stream = new FileStream(@filePath, FileMode.Create))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();

                    Paragraph PheaderString = new Paragraph("Ресторан Цони-Мацони", fontB);
                    PheaderString.Alignment = Element.ALIGN_CENTER;

                    String dateString = "Дата" + System.DateTime.Now.ToString();
                    Paragraph PdateString = new Paragraph(dateString, font)
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };
                    String sum = "ИТОГ:"+order.Cost.ToString();
                    Paragraph Psum = new Paragraph(sum, font)
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };

                    PdfPTable table = new PdfPTable(3);
                    PdfPRow row = null;
                    float[] widths = new float[] { 4f, 4f, 4f };

                    table.SetWidths(widths);

                    table.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    //PdfPCell cell = new PdfPCell(new Phrase("Products"));

                    //cell.Colspan = 3;

                    //foreach (Grid.Col c in dt.Columns)
                    //{
                    //    table.AddCell(new Phrase(c.ColumnName, font5));
                    //}
                    table.AddCell(new Phrase("Название", fontB));
                    table.AddCell(new Phrase("Кол-во", fontB));
                    table.AddCell(new Phrase("Цена", fontB));

                    foreach(OrderLineModel r in listOrderLines)
                    {
                       
                        {
                            table.AddCell(new Phrase(r.DishName.ToString(), font));
                            table.AddCell(new Phrase(r.Amount.ToString(), font));
                            table.AddCell(new Phrase(r.Cost.ToString(), font));
                            
                        }
                    }
                    
                    
                

                document.Add(PheaderString);
                    document.Add(PdateString);
                    document.Add(table);
                    document.Add(Psum);
                    document.Close();
                }
            }
            catch (DocumentException ex)
            {
                //Необходимо использование логгера
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
