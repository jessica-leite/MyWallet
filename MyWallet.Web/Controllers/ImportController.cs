using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using MyWallet.Web.ViewModels.Import;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public class ImportController : BaseController
    {
        private static NumberFormatInfo _numberFormatInfo;
        private UnitOfWork _unitOfWork;

        public ImportController()
        {
            _numberFormatInfo = new NumberFormatInfo();
            _numberFormatInfo.NumberDecimalSeparator = ",";

            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Upload(ImportViewModel importViewModel)
        {
            var entries = new List<ImportViewModel>();
            using (var reader = new StreamReader(importViewModel.File.InputStream, Encoding.Default))
            {
                // Jump first line
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var array = line.Split(';');

                    var entry = new ImportViewModel();
                    entry.Date = ConvertToDate(array[0]);
                    entry.Description = array[1];
                    entry.Category = array[2].Trim();
                    entry.Value = ConvertToDecimal(array[3]);
                    entry.IsPaid = array[4] == "Pago" ? true : false;
                    entry.Observation = string.IsNullOrWhiteSpace(array[5]) ? null : array[5];

                    entries.Add(entry);
                }
            }

            var categories = entries.Select(i => i.Category).Distinct();
            var existentCategories = _unitOfWork.CategoryRepository.GetByName(categories, GetCurrentContextId());
        


            foreach (var entry in entries)
            {
                var category = existentCategories.FirstOrDefault(c => c.Name == entry.Category);
                entry.CategoryId = category == null ? 0 : category.Id;
            }

            //var createCategories = 
           
            return null;
        }

        private decimal ConvertToDecimal(string number)
        {
            return decimal.Parse(number, _numberFormatInfo);
        }

        private DateTime ConvertToDate(string date)
        {
            var numbers = date.Split('.');
            var day = int.Parse(numbers[0]);
            var month = int.Parse(numbers[1]);
            var year = int.Parse(numbers[2]);

            return new DateTime(year, month, day);
        }
    }
}