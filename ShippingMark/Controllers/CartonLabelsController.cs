using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ShippingMark.Data;
using ShippingMark.Models;

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
            return View(await _context.CartonLabels.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("ID,CartonNumber,BuyerCartonNumber,StylePPJ,Brand,Description,Fab,ColorName,Col00,Col0,Col1,Col2,Col3,Col4,Col5,Col6,Col8,Col10,Col12,Col14,Col16,Col18,Col20,Col22,Col24,Col26,Col28,Col30,Quantity,TotalQuantity,CartonQuantity,TotalPieces,TotalNetWeight,TotalGrossWeight,Dimension")] CartonLabel cartonLabel)
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,CartonNumber,BuyerCartonNumber,StylePPJ,Brand,Description,Fab,ColorName,Col00,Col0,Col1,Col2,Col3,Col4,Col5,Col6,Col8,Col10,Col12,Col14,Col16,Col18,Col20,Col22,Col24,Col26,Col28,Col30,Quantity,TotalQuantity,CartonQuantity,TotalPieces,TotalNetWeight,TotalGrossWeight,Dimension")] CartonLabel cartonLabel)
        {
            if (id != cartonLabel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartonLabel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartonLabelExists(cartonLabel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cartonLabel);
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
                    CartonLabel l = new CartonLabel
                    {
                        CartonNumber = ConvertInput(workSheet.Cells[row, 1].Text),
                        BuyerCartonNumber = ConvertInput(workSheet.Cells[row, 4].Text),
                        StylePPJ = ConvertInput(workSheet.Cells[row, 6].Text),
                        Brand = workSheet.Cells[row, 7].Text,
                        Description = workSheet.Cells[row, 8].Text,
                        Fab = workSheet.Cells[row, 9].Text,
                        ColorName = workSheet.Cells[row, 10].Text,
                        Col00 = ConvertInput(workSheet.Cells[row, 11].Text),
                        Col0 = ConvertInput(workSheet.Cells[row, 12].Text),
                        Col1 = ConvertInput(workSheet.Cells[row, 13].Text),
                        Col2 = ConvertInput(workSheet.Cells[row, 14].Text),
                        Col3 = ConvertInput(workSheet.Cells[row, 15].Text),
                        Col4 = ConvertInput(workSheet.Cells[row, 16].Text),
                        Col5 = ConvertInput(workSheet.Cells[row, 17].Text),
                        Col6 = ConvertInput(workSheet.Cells[row, 18].Text),
                        Col8 = ConvertInput(workSheet.Cells[row, 19].Text),
                        Col10 = ConvertInput(workSheet.Cells[row, 20].Text),
                        Col12 = ConvertInput(workSheet.Cells[row, 21].Text),
                        Col14 = ConvertInput(workSheet.Cells[row, 22].Text),
                        Col16 = ConvertInput(workSheet.Cells[row, 23].Text),
                        Col18 = ConvertInput(workSheet.Cells[row, 24].Text),
                        Col20 = ConvertInput(workSheet.Cells[row, 25].Text),
                        Col22 = ConvertInput(workSheet.Cells[row, 26].Text),
                        Col24 = ConvertInput(workSheet.Cells[row, 27].Text),
                        Col26 = ConvertInput(workSheet.Cells[row, 28].Text),
                        Col28 = ConvertInput(workSheet.Cells[row, 29].Text),
                        Col30 = ConvertInput(workSheet.Cells[row, 30].Text),
                        TotalQuantity = ConvertInput(workSheet.Cells[row, 31].Text),
                        CartonQuantity = ConvertInput(workSheet.Cells[row, 32].Text),
                        TotalPieces = ConvertInput(workSheet.Cells[row, 33].Text),
                        TotalNetWeight = ConvertDouble(workSheet.Cells[row, 34].Text),
                        TotalGrossWeight = ConvertDouble(workSheet.Cells[row, 35].Text),
                        Dimension = workSheet.Cells[row, 36].Text,
                    };
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
        public IActionResult DownloadLabels()
        {
            var labels = _context.CartonLabels.ToList();

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
                        if (l.Col00 != 0) names.Add("00");
                        if (l.Col0 != 0) names.Add("0");
                        if (l.Col1 != 0) names.Add("1");
                        if (l.Col2 != 0) names.Add("2");
                        if (l.Col3 != 0) names.Add("3");
                        if (l.Col4 != 0) names.Add("4");
                        if (l.Col5 != 0) names.Add("5");
                        if (l.Col6 != 0) names.Add("6");
                        if (l.Col8 != 0) names.Add("8");
                        if (l.Col10 != 0) names.Add("10");
                        if (l.Col12 != 0) names.Add("12");
                        if (l.Col14 != 0) names.Add("14");
                        if (l.Col16 != 0) names.Add("16");
                        if (l.Col18 != 0) names.Add("18");
                        if (l.Col20 != 0) names.Add("20");
                        if (l.Col22 != 0) names.Add("22");
                        if (l.Col24 != 0) names.Add("24");
                        if (l.Col26 != 0) names.Add("26");
                        if (l.Col28 != 0) names.Add("28");
                        if (l.Col30 != 0) names.Add("30");


                        List<int> values = new List<int>();
                        if (l.Col00 != 0) values.Add(l.Col00);
                        if (l.Col0 != 0) values.Add(l.Col0);
                        if (l.Col1 != 0) values.Add(l.Col1);
                        if (l.Col2 != 0) values.Add(l.Col2);
                        if (l.Col3 != 0) values.Add(l.Col3);
                        if (l.Col4 != 0) values.Add(l.Col4);
                        if (l.Col5 != 0) values.Add(l.Col5);
                        if (l.Col6 != 0) values.Add(l.Col6);
                        if (l.Col8 != 0) values.Add(l.Col8);
                        if (l.Col10 != 0) values.Add(l.Col10);
                        if (l.Col12 != 0) values.Add(l.Col12);
                        if (l.Col14 != 0) values.Add(l.Col14);
                        if (l.Col16 != 0) values.Add(l.Col16);
                        if (l.Col18 != 0) values.Add(l.Col18);
                        if (l.Col20 != 0) values.Add(l.Col20);
                        if (l.Col22 != 0) values.Add(l.Col22);
                        if (l.Col24 != 0) values.Add(l.Col24);
                        if (l.Col26 != 0) values.Add(l.Col26);
                        if (l.Col28 != 0) values.Add(l.Col28);
                        if (l.Col30 != 0) values.Add(l.Col30);

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

                        workSheet.Cells[startRow + 15, 6].Value = l.CartonNumber.ToString().ToUpper();
                        workSheet.Cells[startRow + 15, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[startRow + 15, 6, startRow + 15, 8].Merge = true;
                        workSheet.Cells[startRow + 15, 9].Value = "OF";
                        workSheet.Cells[startRow + 15, 11].Value = labels.Count.ToString().ToUpper();

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
        public IActionResult DeleteAll()
        {
            var labels = _context.CartonLabels.ToList();

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
