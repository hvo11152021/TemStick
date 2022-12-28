using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Composition;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.Style;
using ShippingMark.Data;
using ShippingMark.Models;
using static OfficeOpenXml.ExcelErrorValue;

namespace ShippingMark.Controllers
{
    public class CartonLabelsController : Controller
    {
        private readonly ShippingContext _context;

        public CartonLabelsController(ShippingContext context)
        {
            _context = context;
        }

        // GET: CartonLabels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CartonLabels.OrderBy(l => l.BuyerCartonNumber).ToListAsync());
        }

        // GET: CartonLabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CartonLabels == null)
            {
                return NotFound();
            }

            var cartonLabel = await _context.CartonLabels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cartonLabel == null)
            {
                return NotFound();
            }

            List<string> names = new List<string>();
            List<int> values = new List<int>();
            if (cartonLabel.Col00 != 0)
            {
                names.Add("00");
                values.Add(cartonLabel.Col00);
            }
            for (int i = 0; i <= 54; i++)
            {
                var prop = typeof(CartonLabel).GetProperty($"Col{i}");
                int objInt = (int)prop.GetValue(cartonLabel, null);
                if (objInt != 0)
                {
                    names.Add($"{i}");
                    values.Add(objInt);
                }
            }

            ViewData["Names"] = names;
            ViewData["Values"] = values;

            return View(cartonLabel);
        }

        // GET: CartonLabels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartonLabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CartonNumber,BuyerCartonNumber, StylePPJ,Brand,Description,Fab,ColorName," +
            "Col00,Col0,Col1,Col2,Col3,Col4,Col5,Col6,Col7,Col8,Col9,Col10," +
            "Col11,Col12,Col13,Col14,Col15,Col16,Col17,Col18,Col19,Col20," +
            "Col21,Col22,Col23,Col24,Col25,Col26,Col27,Col28,Col29,Col30," +
            "Col31,Col32,Col33,Col34,Col35,Col36,Col37,Col38,Col39,Col40," +
            "Col41,Col42,Col43,Col44,Col45,Col46,Col47,Col48,Col49,Col50," +
            "Col51,Col52,Col53,Col54,SizeXS,SizeS,SizeM,SizeL,SizeXL,Size2XL," +
            "TotalQuantity,CartonQuantity,TotalPieces,TotalNetWeight,TotalGrossWeight,Dimension")] CartonLabel cartonLabel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartonLabel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartonLabel);
        }

        // GET: CartonLabels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CartonLabels == null)
            {
                return NotFound();
            }

            var cartonLabel = await _context.CartonLabels.FindAsync(id);
            if (cartonLabel == null)
            {
                return NotFound();
            }
            return View(cartonLabel);
        }

        // POST: CartonLabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var labelToUpdate = await _context.CartonLabels.SingleOrDefaultAsync(l => l.ID == id);

            if (labelToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(labelToUpdate, "", l => l.CartonNumber, l => l.BuyerCartonNumber, l => l.StylePPJ, l => l.Brand, l => l.Description, l => l.Fab, l => l.ColorName,
                l => l.Col00, l => l.Col0, l => l.Col1, l => l.Col2, l => l.Col3, l => l.Col4, l => l.Col5, l => l.Col6, l => l.Col7, l => l.Col8, l => l.Col9, l => l.Col10,
                l => l.Col11, l => l.Col12, l => l.Col13, l => l.Col14, l => l.Col15, l => l.Col16, l => l.Col17, l => l.Col18, l => l.Col19, l => l.Col20,
                l => l.Col21, l => l.Col22, l => l.Col23, l => l.Col24, l => l.Col25, l => l.Col26, l => l.Col27, l => l.Col28, l => l.Col29, l => l.Col30,
                l => l.Col31, l => l.Col32, l => l.Col33, l => l.Col34, l => l.Col35, l => l.Col36, l => l.Col37, l => l.Col38, l => l.Col39, l => l.Col40,
                l => l.Col41, l => l.Col42, l => l.Col43, l => l.Col44, l => l.Col45, l => l.Col46, l => l.Col47, l => l.Col48, l => l.Col49, l => l.Col50,
                l => l.Col51, l => l.Col52, l => l.Col53, l => l.Col54, l => l.SizeXS, l => l.SizeS, l => l.SizeM, l => l.SizeL, l => l.SizeXL, l => l.Size2XL,
                l => l.TotalQuantity, l => l.TotalPieces, l => l.TotalNetWeight, l => l.TotalGrossWeight, l => l.Dimension))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartonLabelExists(labelToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(labelToUpdate);
        }

        // GET: CartonLabels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CartonLabels == null)
            {
                return NotFound();
            }

            var cartonLabel = await _context.CartonLabels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cartonLabel == null)
            {
                return NotFound();
            }

            List<string> names = new List<string>();
            List<int> values = new List<int>();
            if (cartonLabel.Col00 != 0)
            {
                names.Add("00");
                values.Add(cartonLabel.Col00);
            }
            for (int i = 0; i <= 54; i++)
            {
                var prop = typeof(CartonLabel).GetProperty($"Col{i}");
                int objInt = (int)prop.GetValue(cartonLabel, null);
                if (objInt != 0)
                {
                    names.Add($"{i}");
                    values.Add(objInt);
                }
            }

            ViewData["Names"] = names;
            ViewData["Values"] = values;

            return View(cartonLabel);
        }

        // POST: CartonLabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CartonLabels == null)
            {
                return Problem("Entity set 'ShippingContext.CartonLabels'  is null.");
            }
            var cartonLabel = await _context.CartonLabels.FindAsync(id);
            if (cartonLabel != null)
            {
                _context.CartonLabels.Remove(cartonLabel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private int ConvertInput(string input)
        {
            if (input == null || input == "")
                return 0;
            else
                return int.Parse(input);
        }

        private double ConvertDouble(string input)
        {
            if (input == null || input == "")
                return 0;
            else
                return double.Parse(input);
        }

        private bool CartonLabelExists(int id)
        {
            return _context.CartonLabels.Any(e => e.ID == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CartonLabels/InsertFromExcel
        public async Task<IActionResult> InsertFromExcel(IFormFile theExcel)
        {
            //Make sure file is uploaded
            if (theExcel == null)
            {
                TempData["Message"] = "Please select an Excel file to upload. File type must be .csv or .xlsx!";
                return RedirectToAction(nameof(Index));
            }

            string uploadMessage = "";
            int i = 0;//Counter for inserted records
            int j = 0;//Counter for duplicates

            try
            {
                ExcelPackage excel;
                using (var memoryStream = new MemoryStream())
                {
                    await theExcel.CopyToAsync(memoryStream);
                    excel = new ExcelPackage(memoryStream);
                }
                var workSheet = excel.Workbook.Worksheets[0];
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;

                //Start a new list to hold imported objects
                List<CartonLabel> cartonLabels = new List<CartonLabel>();

                for (int row = start.Row + 2; row <= end.Row; row++)
                {
                    // Row by row...
                    CartonLabel l = new CartonLabel();
                    l.CartonNumber = ConvertInput(workSheet.Cells[row, 1].Text);
                    l.BuyerCartonNumber = ConvertInput(workSheet.Cells[row, 4].Text);
                    l.StylePPJ = workSheet.Cells[row, 6].Text;
                    l.Brand = workSheet.Cells[row, 7].Text;
                    l.Description = workSheet.Cells[row, 8].Text;
                    l.Fab = workSheet.Cells[row, 9].Text;
                    l.ColorName = workSheet.Cells[row, 10].Text;
                    l.Col00 = ConvertInput(workSheet.Cells[row, 11].Text);

                    //using reflection to loop through all properties in one object
                    for (int p = 0; p <= 54; p++)
                    {
                        var prop = typeof(CartonLabel).GetProperty($"Col{p}");
                        prop.SetValue(l, ConvertInput(workSheet.Cells[row, p + 12].Text), null);
                    }

                    l.SizeXS = ConvertInput(workSheet.Cells[row, 67].Text);
                    l.SizeS = ConvertInput(workSheet.Cells[row, 68].Text);
                    l.SizeM = ConvertInput(workSheet.Cells[row, 69].Text);
                    l.SizeL = ConvertInput(workSheet.Cells[row, 70].Text);
                    l.SizeXL = ConvertInput(workSheet.Cells[row, 71].Text);
                    l.Size2XL = ConvertInput(workSheet.Cells[row, 72].Text);

                    l.TotalQuantity = ConvertInput(workSheet.Cells[row, 73].Text);
                    l.CartonQuantity = ConvertInput(workSheet.Cells[row, 74].Text);
                    l.TotalPieces = ConvertInput(workSheet.Cells[row, 75].Text);
                    l.TotalNetWeight = ConvertDouble(workSheet.Cells[row, 76].Text);
                    l.TotalGrossWeight = ConvertDouble(workSheet.Cells[row, 77].Text);
                    l.Dimension = workSheet.Cells[row, 78].Text;

                    if (l.TotalQuantity != 0 &&
                        l.CartonQuantity != 0 &&
                        l.TotalPieces != 0 &&
                        l.TotalNetWeight != 0 &&
                        l.TotalGrossWeight != 0)
                        cartonLabels.Add(l);

                }
                _context.CartonLabels.AddRange(cartonLabels);
                _context.SaveChanges();
                TempData["Success"] = "Data successfully uploaded!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //uploadMessage = ex.GetBaseException().Message;
                uploadMessage = "Incorrect column placement or missing columns. " +
                    "Please review the upload format by download the upload guideline on the right. " +
                    "(Sai vị trí cột hoặc thiếu cột. Vui lòng xem xét hướng dẫn tải lên) " +
                    ex.GetBaseException().Message;
                /*"Failed to import data.  Check that file type is .csv or .xlsx!";*/
            }
            if (String.IsNullOrEmpty(uploadMessage))
            {
                uploadMessage = "Imported " + (i + j).ToString() + " records, with "
                    + j.ToString() + " rejected as duplicates and " + i.ToString() + " inserted.";
            }
            TempData["Message"] = uploadMessage;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CartonLabels/DownloadLabels
        public async Task<IActionResult> DownloadLabels()
        {
            var labels = await _context.CartonLabels.OrderBy(l => l.BuyerCartonNumber).ToListAsync();

            if (labels.Count == 0)
            {
                TempData["Message"] = "Failed to download. Currently there is no record on the page.";
                return RedirectToAction(nameof(Index));
            }

            string downloadMessage = "";

            try
            {
                var stream = new MemoryStream();
                //required using OfficeOpenXml;
                // If you use EPPlus in a noncommercial context
                // according to the Polyform Noncommercial license:
                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    //workSheet.Cells[2,1].LoadFromCollection(list, true);
                    int startRow = 2;

                    int maxValue = 0;
                    foreach (var l in labels)
                    {
                        if (maxValue < l.BuyerCartonNumber)
                            maxValue = l.BuyerCartonNumber;
                    }

                    foreach (var l in labels)
                    {
                        workSheet.Cells[startRow, 1].Value = "BRAND NAME";
                        workSheet.Cells[startRow + 1, 1].Value = "STYLE #";
                        workSheet.Cells[startRow + 3, 1].Value = "COLORS";
                        workSheet.Cells[startRow + 4, 1].Value = "SIZE";
                        workSheet.Cells[startRow + 5, 1].Value = "QTY";
                        workSheet.Cells[startRow + 7, 1].Value = "TOTAL QTY";
                        workSheet.Cells[startRow + 9, 1].Value = "NET. WT";
                        workSheet.Cells[startRow + 11, 1].Value = "GROSS WT";
                        workSheet.Cells[startRow + 13, 1].Value = "DIMS";
                        workSheet.Cells[startRow + 15, 1].Value = "CARTON #";
                        workSheet.Cells[startRow + 17, 1].Value = "MADE IN VIETNAM";
                        workSheet.Cells[startRow + 17, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[startRow + 17, 1, startRow + 17, 15].Merge = true;

                        workSheet.Cells[startRow, 3].Value = ":";
                        workSheet.Cells[startRow + 1, 3].Value = ":";
                        workSheet.Cells[startRow + 3, 3].Value = ":";
                        workSheet.Cells[startRow + 4, 3].Value = ":";
                        workSheet.Cells[startRow + 7, 3].Value = ":";
                        workSheet.Cells[startRow + 9, 3].Value = ":";
                        workSheet.Cells[startRow + 11, 3].Value = ":";
                        workSheet.Cells[startRow + 13, 3].Value = ":";
                        workSheet.Cells[startRow + 15, 3].Value = ":";

                        workSheet.Cells[startRow, 4].Value = l.Brand.ToUpper();
                        workSheet.Cells[startRow + 1, 4].Value = l.StylePPJ.ToString().ToUpper();
                        workSheet.Cells[startRow + 3, 4].Value = l.ColorName.ToUpper();

                        List<string> names = new List<string>();
                        List<int> values = new List<int>();
                        if (l.Col00 != 0)
                        {
                            names.Add("00");
                            values.Add(l.Col00);
                        }

                        //using reflection to loop through all properties in one object
                        for (int i = 0; i <= 54; i++)
                        {
                            var prop = typeof(CartonLabel).GetProperty($"Col{i}");
                            int objInt = (int)prop.GetValue(l, null);
                            if (objInt != 0)
                            {
                                names.Add($"{i}");
                                values.Add(objInt);
                            }
                        }

                        if (l.SizeXS != 0) names.Add("XS");
                        if (l.SizeS != 0) names.Add("S");
                        if (l.SizeM != 0) names.Add("M");
                        if (l.SizeL != 0) names.Add("L");
                        if (l.SizeXL != 0) names.Add("XL");
                        if (l.Size2XL != 0) names.Add("2XL");

                        if (l.SizeXS != 0) values.Add(l.SizeXS);
                        if (l.SizeS != 0) values.Add(l.SizeS);
                        if (l.SizeM != 0) values.Add(l.SizeM);
                        if (l.SizeL != 0) values.Add(l.SizeL);
                        if (l.SizeXL != 0) values.Add(l.SizeXL);
                        if (l.Size2XL != 0) values.Add(l.Size2XL);

                        for (int i = 0; i < values.Count(); i++)
                        {
                            workSheet.Cells[startRow + 4, i + 4].Value = names.ElementAt(i);
                            workSheet.Cells[startRow + 4, i + 4].Style.Font.UnderLine = true;
                            workSheet.Cells[startRow + 5, i + 4].Value = values.ElementAt(i);
                            workSheet.Cells[startRow + 4, i + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            workSheet.Cells[startRow + 5, i + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        workSheet.Cells[startRow + 7, 8].Value = l.TotalQuantity.ToString().ToUpper() + " PCS";
                        workSheet.Cells[startRow + 9, 8].Value = l.TotalNetWeight.ToString().ToUpper() + " KGS";
                        workSheet.Cells[startRow + 11, 8].Value = l.TotalGrossWeight.ToString().ToUpper() + " KGS";

                        char[] dmsn = l.Dimension.ToUpper().ToCharArray();
                        workSheet.Cells[startRow + 13, 6].Value = $"{dmsn[0]}{dmsn[1]}CM {dmsn[2]} {dmsn[3]}{dmsn[4]}CM {dmsn[5]} {dmsn[6]}{dmsn[7]}CM";

                        workSheet.Cells[startRow + 15, 6].Value = l.BuyerCartonNumber.ToString().ToUpper();
                        workSheet.Cells[startRow + 15, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[startRow + 15, 6, startRow + 15, 8].Merge = true;
                        workSheet.Cells[startRow + 15, 9].Value = "OF";
                        workSheet.Cells[startRow + 15, 11].Value = maxValue.ToString();

                        for (int i = 0; i <= 17; i++)
                        {
                            workSheet.Cells[startRow + i, 1].Style.Border.Left.Style = ExcelBorderStyle.Medium;
                        }

                        for (int i = 1; i <= 15; i++)
                        {
                            workSheet.Cells[startRow - 1, i].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                        }

                        for (int i = 0; i <= 17; i++)
                        {
                            workSheet.Cells[startRow + i, 15].Style.Border.Right.Style = ExcelBorderStyle.Medium;
                        }

                        for (int i = 1; i <= 15; i++)
                        {
                            workSheet.Cells[startRow + 17, i].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                        }

                        startRow += 19;
                    }

                    workSheet.Cells.Style.Font.Name = "Times New Roman";
                    workSheet.Cells.Style.Font.Size = 36;
                    workSheet.Cells.Style.Font.Bold = true;

                    workSheet.Column(1).Width = 18.67;
                    workSheet.Column(2).Width = 46.67;
                    workSheet.Column(3).Width = 11.67;

                    for (int i = 4; i <= 15; i++)
                    {
                        workSheet.Column(i).Width = 10.67;
                    }

                    workSheet.Row(1).Height = 41.40;
                    workSheet.Row(2).Height = 72.60;
                    workSheet.Row(3).Height = 56.40;
                    workSheet.Row(4).Height = 21.00;
                    workSheet.Row(5).Height = 46.80;
                    workSheet.Row(6).Height = 48.00;
                    workSheet.Row(7).Height = 66.00;

                    for (int i = 8; i <= 15; i++)
                    {
                        workSheet.Row(i).Height = 46.80;
                    }
                    workSheet.Row(16).Height = 34.20;
                    workSheet.Row(17).Height = 46.80;
                    workSheet.Row(18).Height = 33.00;
                    workSheet.Row(19).Height = 47.40;

                    workSheet.PrinterSettings.HeaderMargin = 0;
                    workSheet.PrinterSettings.FooterMargin = 0;
                    workSheet.PrinterSettings.TopMargin = 0.34m;
                    workSheet.PrinterSettings.LeftMargin = 0.3m;
                    workSheet.PrinterSettings.RightMargin = 0.25m;
                    workSheet.PrinterSettings.BottomMargin = 0.25m;
                    workSheet.PrinterSettings.HorizontalCentered = true;
                    workSheet.PrinterSettings.PaperSize = ePaperSize.A4;
                    workSheet.PrinterSettings.Scale = 46;

                    package.Save();
                }
                stream.Position = 0;
                string excelName = $"listToPrint.xlsx";
                
                return File(stream, "application/octet-stream", excelName);
            }
            catch (Exception ex)
            {
                downloadMessage = ex.GetBaseException().Message;
            }
            TempData["Message"] = downloadMessage;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CartonLabels/DeleteAll
        public async Task<IActionResult> DeleteAll()
        {
            var labels = await _context.CartonLabels.ToListAsync();

            if (labels.Count == 0)
            {
                TempData["Message"] = "Failed to delete. Currently there is no record on the page.";
                return RedirectToAction(nameof(Index));
            }
            string deleteMessage = "";

            try
            {
                int listCount = _context.CartonLabels.ToList().Count();
                _context.CartonLabels.RemoveRange(_context.CartonLabels.ToList());
                _context.SaveChanges();
                TempData["Success"] = $"{listCount} records deleted!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                deleteMessage = ex.GetBaseException().Message;
            }
            TempData["Message"] = deleteMessage;
            return RedirectToAction(nameof(Index));
        }

    }
}
