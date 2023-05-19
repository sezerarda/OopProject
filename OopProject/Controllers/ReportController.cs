using ClosedXML.Excel;
using DataLayer.DataBase;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OopProject.Models;
using Spire.Xls.Core.Spreadsheet;

namespace OopProject.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticReport() 
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage excelPackage = new ExcelPackage();
            var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workBook.Cells[1, 1].Value = "Ürün Adı";
            workBook.Cells[1, 2].Value = "Ürün Kategorisi";
            workBook.Cells[1, 3].Value = "Ürün Stok";

            workBook.Cells[2, 1].Value = "Mercimek";
            workBook.Cells[2, 2].Value = "Bakliyat";
            workBook.Cells[2, 3].Value = "500 KG";


            workBook.Cells[3, 1].Value = "Domates";
            workBook.Cells[3, 2].Value = "Sebze";
            workBook.Cells[3, 3].Value = "1.000 KG";


            workBook.Cells[4, 1].Value = "Havuç";
            workBook.Cells[4, 2].Value = "Sebze";
            workBook.Cells[4, 3].Value = "650 KG";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","UrunRaporu.xlsx");
        }
        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels= new List<ContactModel>();
            using(var context = new ProjectContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactId= x.ContactId,
                    ContactName = x.Name,
                    ContactMessage= x.Message,
                    ContactMail= x.Mail,
                    ContactDate = x.Date
                }).ToList();
            }
            return contactModels;
        }
        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj Id";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 4).Value = "Mesaj Adresi";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";


                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactId;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;

                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRaporu.xlsx");
                }
            }
        }
        public List<NewsModel> NewsList()
        {
            List<NewsModel> newsModels = new List<NewsModel>();
            using (var context = new ProjectContext())
            {
                newsModels = context.Newses.Select(x => new NewsModel
                {
                    Id = x.NewsId,
                    Title = x.Title,
                    Description = x.Description,
                    Date = x.Date,
                    Status = x.Status
                }).ToList();
            }
            return newsModels;
        }
        public IActionResult NewsReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru Id";
                workSheet.Cell(1, 2).Value = "Duyuru Başlığı";
                workSheet.Cell(1, 3).Value = "Duyuru Açıklaması";
                workSheet.Cell(1, 5).Value = "Duyuru Tarihi";
                workSheet.Cell(1, 4).Value = "Duyuru Durumu";



                int contactRowCount = 2;
                foreach (var item in NewsList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.Id;
                    workSheet.Cell(contactRowCount, 2).Value = item.Title;
                    workSheet.Cell(contactRowCount, 3).Value = item.Description;
                    workSheet.Cell(contactRowCount, 4).Value = item.Date;
                    workSheet.Cell(contactRowCount, 5).Value = item.Status;

                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRaporu.xlsx");
                }
            }
        }

    }
}
