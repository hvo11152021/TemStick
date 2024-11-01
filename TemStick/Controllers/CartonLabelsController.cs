﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using TemStick.Data;
using TemStick.Models;
using TemStick.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TemStick.Controllers
{
    public class CartonLabelsController : Controller
    {
        private readonly ShippingContext _context;

        public CartonLabelsController(ShippingContext context)
        {
            _context = context;
        }

        // GET: CartonLabels
        public async Task<IActionResult> Index(string SearchString, int? page, int? pageSizeID, string actionButton, string sortDirection = "asc", string sortField = "Style PPJ")
        {
            var cartons = from c in _context.CartonLabels
                          select c;

            //Clear the sort/filter/paging URL Cookie for Controller
            CookieHelper.CookieSet(HttpContext, ControllerName() + "URL", "", -1);

            //Toggle the Open/Closed state of the collapse depending on if we are filtering
            ViewData["Filtering"] = ""; //Asume not filtering
            //Then in each "test" for filtering, add ViewData["Filtering"] = " show" if true;

            //NOTE: make sure this array has matching values to the column headings
            string[] sortOptions = new[] { "Style PPJ", "Brand" };

            if (!String.IsNullOrEmpty(SearchString))
            {
                cartons = cartons.Where(p => p.StylePPJ.ToUpper().Contains(SearchString.ToUpper())
                                       || p.Brand.ToUpper().Contains(SearchString.ToUpper()));
                ViewData["Filtering"] = " show";
            }

            //Before we sort, see if we have called for a change of filtering or sorting
            if (!String.IsNullOrEmpty(actionButton)) //Form Submitted!
            {
                page = 1;//Reset page to start

                if (sortOptions.Contains(actionButton))//Change of sort is requested
                {
                    //Reverse order on same field
                    if (actionButton == sortField) sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    sortField = actionButton;//Sort by the button clicked
                }
            }
            //Now we know which field and direction to sort by
            if (sortField == "Brand")
            {
                cartons = sortDirection == "asc" ? cartons.OrderBy(p => p.Brand).ThenBy(p => p.StylePPJ) : cartons = cartons.OrderByDescending(p => p.Brand).ThenByDescending(p => p.StylePPJ);
            }
            else //Sorting by Last Name
            {
                cartons = sortDirection == "asc" ? cartons.OrderBy(p => p.StylePPJ).ThenBy(p => p.Brand) : cartons.OrderByDescending(p => p.StylePPJ).ThenByDescending(p => p.Brand);
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            //Handle Paging
             int pageSize = PageSizeHelper.SetPageSize(HttpContext, pageSizeID);
            ViewData["pageSizeID"] = PageSizeHelper.PageSizeList(pageSize);

            var pagedData = await PaginatedList<CartonLabel>.CreateAsync(cartons.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: CartonLabels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null || _context.CartonLabels == null) NotFound();

            var cartonLabel = await _context.CartonLabels.FirstOrDefaultAsync(m => m.ID == id);

            if (cartonLabel == null) NotFound();

            List<string> names = new List<string>();
            List<int> values = new List<int>();

            void SetNamesAndValues(string n, int v)
            {
                names.Add(n);
                values.Add(v);
            }

            if (cartonLabel.Col000 != 0) SetNamesAndValues("000", cartonLabel.Col000);
            if (cartonLabel.Col00 != 0) SetNamesAndValues("00", cartonLabel.Col00);
            for (int i = 0; i <= 60; i++)
            {
                var prop = typeof(CartonLabel).GetProperty($"Col{i}");
                int objInt = (int)prop.GetValue(cartonLabel, null);
                if (objInt != 0)
                {
                    names.Add($"{i}");
                    values.Add(objInt);
                }
            }

            var sizes = new List<(string n, int v)>{
                ("XXS", cartonLabel.Size2XS),
                ("XS", cartonLabel.SizeXS),
                ("S", cartonLabel.SizeS),
                ("M", cartonLabel.SizeM),
                ("L", cartonLabel.SizeL),
                ("XL", cartonLabel.SizeXL),
                ("XXL", cartonLabel.Size2XL),
                ("3XL", cartonLabel.Size3XL),
                ("X1", cartonLabel.SizeX1),
                ("X2", cartonLabel.SizeX2),
                ("X3", cartonLabel.SizeX3),
                ("LL", cartonLabel.SizeLL),
                ("3L", cartonLabel.Size3L),
                ("4L", cartonLabel.Size4L),
                ("5L", cartonLabel.Size5L)
            };

            foreach (var size in sizes)
            {
                if (size.v != 0) SetNamesAndValues(size.n, size.v);
            }

            ViewData["Names"] = names;
            ViewData["Values"] = values;

            return View(cartonLabel);
        }

        // GET: CartonLabels/Create
        public IActionResult Create()
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();
            return View();
        }

        // POST: CartonLabels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CartonNumber,BuyerCartonNumber, StylePPJ,Brand,Description,Fab,ColorName," +
            "Col000,Col00,Col0,Col1,Col2,Col3,Col4,Col5,Col6,Col7,Col8,Col9,Col10," +
            "Col11,Col12,Col13,Col14,Col15,Col16,Col17,Col18,Col19,Col20," +
            "Col21,Col22,Col23,Col24,Col25,Col26,Col27,Col28,Col29,Col30," +
            "Col31,Col32,Col33,Col34,Col35,Col36,Col37,Col38,Col39,Col40," +
            "Col41,Col42,Col43,Col44,Col45,Col46,Col47,Col48,Col49,Col50," +
            "Col51,Col52,Col53,Col54,Col55,Col56,Col57,Col58,Col59,Col60," +
            "Size2XS,SizeXS,SizeS,SizeM,SizeL,SizeXL,Size2XL,Size3XL,SizeX1,SizeX2,SizeX3,SizeLL,Size3L,Size4L,Size5L," +
            "TotalQuantity,CartonQuantity,TotalPieces,TotalNetWeight,TotalGrossWeight,Dimension")] CartonLabel cartonLabel)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

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
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null || _context.CartonLabels == null) NotFound();

            var cartonLabel = await _context.CartonLabels.FindAsync(id);
            if (cartonLabel == null) NotFound();
            return View(cartonLabel);
        }

        // POST: CartonLabels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            var labelToUpdate = await _context.CartonLabels.SingleOrDefaultAsync(l => l.ID == id);

            if (labelToUpdate == null) NotFound();

            if (await TryUpdateModelAsync(labelToUpdate, "", l => l.CartonNumber, l => l.BuyerCartonNumber, l => l.StylePPJ, l => l.Brand, l => l.Description, l => l.Fab, l => l.ColorName,
                l => l.Col00, l => l.Col0, l => l.Col1, l => l.Col2, l => l.Col3, l => l.Col4, l => l.Col5, l => l.Col6, l => l.Col7, l => l.Col8, l => l.Col9, l => l.Col10,
                l => l.Col11, l => l.Col12, l => l.Col13, l => l.Col14, l => l.Col15, l => l.Col16, l => l.Col17, l => l.Col18, l => l.Col19, l => l.Col20,
                l => l.Col21, l => l.Col22, l => l.Col23, l => l.Col24, l => l.Col25, l => l.Col26, l => l.Col27, l => l.Col28, l => l.Col29, l => l.Col30,
                l => l.Col31, l => l.Col32, l => l.Col33, l => l.Col34, l => l.Col35, l => l.Col36, l => l.Col37, l => l.Col38, l => l.Col39, l => l.Col40,
                l => l.Col41, l => l.Col42, l => l.Col43, l => l.Col44, l => l.Col45, l => l.Col46, l => l.Col47, l => l.Col48, l => l.Col49, l => l.Col50,
                l => l.Col51, l => l.Col52, l => l.Col53, l => l.Col54, l => l.Col55, l => l.Col56, l => l.Col57, l => l.Col58, l => l.Col59, l => l.Col60,
                l => l.Size2XS, l => l.SizeXS, l => l.SizeS, l => l.SizeM, l => l.SizeL, l => l.SizeXL, l => l.Size2XL, l => l.Size3XL,
                l => l.SizeX1, l => l.SizeX2, l => l.SizeX3, l => l.SizeLL, l => l.Size3L, l => l.Size4L, l => l.Size5L,
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
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

            if (id == null || _context.CartonLabels == null) NotFound();

            var cartonLabel = await _context.CartonLabels.FirstOrDefaultAsync(m => m.ID == id);

            if (cartonLabel == null) NotFound();

            List<string> names = new List<string>();
            List<int> values = new List<int>();
            if (cartonLabel.Col000 != 0)
            {
                names.Add("000");
                values.Add(cartonLabel.Col000);
            }
            if (cartonLabel.Col00 != 0)
            {
                names.Add("00");
                values.Add(cartonLabel.Col00);
            }
            for (int i = 0; i <= 60; i++)
            {
                var prop = typeof(CartonLabel).GetProperty($"Col{i}");
                int objInt = (int)prop.GetValue(cartonLabel, null);
                if (objInt != 0)
                {
                    names.Add($"{i}");
                    values.Add(objInt);
                }
            }
            if (cartonLabel.Size2XS != 0)
            {
                names.Add("XXS");
                values.Add(cartonLabel.Size2XS);
            }
            if (cartonLabel.SizeXS != 0)
            {
                names.Add("XS");
                values.Add(cartonLabel.Size2XS);
            }
            if (cartonLabel.SizeS != 0)
            {
                names.Add("S");
                values.Add(cartonLabel.SizeS);
            }
            if (cartonLabel.SizeM != 0)
            {
                names.Add("M");
                values.Add(cartonLabel.SizeM);
            }
            if (cartonLabel.SizeL != 0)
            {
                names.Add("L");
                values.Add(cartonLabel.SizeL);
            }
            if (cartonLabel.SizeXL != 0)
            {
                names.Add("XL");
                values.Add(cartonLabel.SizeXL);
            }
            if (cartonLabel.Size2XL != 0)
            {
                names.Add("XXL");
                values.Add(cartonLabel.Size2XL);
            }
            if (cartonLabel.Size3XL != 0)
            {
                names.Add("3XL");
                values.Add(cartonLabel.Size3XL);
            }
            if (cartonLabel.SizeX1 != 0)
            {
                names.Add("X1");
                values.Add(cartonLabel.SizeX1);
            }
            if (cartonLabel.SizeX2 != 0)
            {
                names.Add("X2");
                values.Add(cartonLabel.SizeX2);
            }
            if (cartonLabel.SizeX3 != 0)
            {
                names.Add("X3");
                values.Add(cartonLabel.SizeX3);
            }
            if (cartonLabel.SizeLL != 0)
            {
                names.Add("LL");
                values.Add(cartonLabel.SizeLL);
            }
            if (cartonLabel.Size3L != 0)
            {
                names.Add("3L");
                values.Add(cartonLabel.Size3L);
            }
            if (cartonLabel.Size4L != 0)
            {
                names.Add("4L");
                values.Add(cartonLabel.Size4L);
            }
            if (cartonLabel.Size5L != 0)
            {
                names.Add("5L");
                values.Add(cartonLabel.Size5L);
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
            //URL with the last filter, sort and page parameters for this controller
            ViewDataReturnURL();

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

            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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
                    l.Col000 = ConvertInput(workSheet.Cells[row, 11].Text);
                    l.Col00 = ConvertInput(workSheet.Cells[row, 12].Text);

                    //using reflection to loop through all properties in one object
                    for (int p = 0; p <= 60; p++)
                    {
                        var prop = typeof(CartonLabel).GetProperty($"Col{p}");
                        prop.SetValue(l, ConvertInput(workSheet.Cells[row, p + 13].Text), null);
                    }

                    l.Size2XS = ConvertInput(workSheet.Cells[row, 74].Text);
                    l.SizeXS = ConvertInput(workSheet.Cells[row, 75].Text);
                    l.SizeS = ConvertInput(workSheet.Cells[row, 76].Text);
                    l.SizeM = ConvertInput(workSheet.Cells[row, 77].Text);
                    l.SizeL = ConvertInput(workSheet.Cells[row, 78].Text);
                    l.SizeXL = ConvertInput(workSheet.Cells[row, 79].Text);
                    l.Size2XL = ConvertInput(workSheet.Cells[row, 80].Text);
                    l.Size3XL = ConvertInput(workSheet.Cells[row, 81].Text);

                    l.SizeX = ConvertInput(workSheet.Cells[row, 82].Text);
                    l.SizeX1 = ConvertInput(workSheet.Cells[row, 83].Text);
                    l.SizeX2 = ConvertInput(workSheet.Cells[row, 84].Text);
                    l.SizeX3 = ConvertInput(workSheet.Cells[row, 85].Text);
                    l.SizeLL = ConvertInput(workSheet.Cells[row, 86].Text);
                    l.Size3L = ConvertInput(workSheet.Cells[row, 87].Text);
                    l.Size4L = ConvertInput(workSheet.Cells[row, 88].Text);
                    l.Size5L = ConvertInput(workSheet.Cells[row, 89].Text);

                    l.TotalQuantity = ConvertInput(workSheet.Cells[row, 90].Text);
                    l.CartonQuantity = ConvertInput(workSheet.Cells[row, 91].Text);
                    l.TotalPieces = ConvertInput(workSheet.Cells[row, 92].Text);
                    l.TotalNetWeight = ConvertDouble(workSheet.Cells[row, 93].Text);
                    l.TotalGrossWeight = ConvertDouble(workSheet.Cells[row, 94].Text);
                    l.Dimension = workSheet.Cells[row, 95].Text;

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
                        if (maxValue < l.BuyerCartonNumber) maxValue = l.BuyerCartonNumber;
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

                        if (l.Col000 != 0)
                        {
                            names.Add("000");
                            values.Add(l.Col000);
                        }

                        if (l.Col00 != 0)
                        {
                            names.Add("00");
                            values.Add(l.Col00);
                        }

                        //using reflection to loop through all properties in one object
                        for (int i = 0; i <= 60; i++)
                        {
                            var prop = typeof(CartonLabel).GetProperty($"Col{i}");
                            int objInt = (int)prop.GetValue(l, null);
                            if (objInt != 0)
                            {
                                names.Add($"{i}");
                                values.Add(objInt);
                            }
                        }

                        if (l.Size2XS != 0) names.Add("2XS");
                        if (l.SizeXS != 0) names.Add("XS");
                        if (l.SizeS != 0) names.Add("S");
                        if (l.SizeM != 0) names.Add("M");
                        if (l.SizeL != 0) names.Add("L");
                        if (l.SizeXL != 0) names.Add("XL");
                        if (l.Size2XL != 0) names.Add("2XL");
                        if (l.Size3XL != 0) names.Add("3XL");

                        if (l.Size2XS != 0) values.Add(l.Size2XS);
                        if (l.SizeXS != 0) values.Add(l.SizeXS);
                        if (l.SizeS != 0) values.Add(l.SizeS);
                        if (l.SizeM != 0) values.Add(l.SizeM);
                        if (l.SizeL != 0) values.Add(l.SizeL);
                        if (l.SizeXL != 0) values.Add(l.SizeXL);
                        if (l.Size2XL != 0) values.Add(l.Size2XL);
                        if (l.Size3XL != 0) values.Add(l.Size3XL);

                        if (l.SizeX != 0) names.Add("X");
                        if (l.SizeX1 != 0) names.Add("X1");
                        if (l.SizeX2 != 0) names.Add("X2");
                        if (l.SizeX3 != 0) names.Add("X3");
                        if (l.SizeLL != 0) names.Add("LL");
                        if (l.Size3L != 0) names.Add("3L");
                        if (l.Size4L != 0) names.Add("4L");
                        if (l.Size5L != 0) names.Add("5L");

                        if (l.SizeX != 0) values.Add(l.SizeX);
                        if (l.SizeX1 != 0) values.Add(l.SizeX1);
                        if (l.SizeX2 != 0) values.Add(l.SizeX2);
                        if (l.SizeX3 != 0) values.Add(l.SizeX3);
                        if (l.SizeLL != 0) values.Add(l.SizeLL);
                        if (l.Size3L != 0) values.Add(l.Size3L);
                        if (l.Size4L != 0) values.Add(l.Size4L);
                        if (l.Size5L != 0) values.Add(l.Size5L);

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

        private string ControllerName() => this.ControllerContext.RouteData.Values["controller"].ToString();

        private void ViewDataReturnURL()
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, ControllerName());
        }
    }
}
