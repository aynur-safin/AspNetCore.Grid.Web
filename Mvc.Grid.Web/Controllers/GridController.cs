using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NonFactors.Mvc.Grid.Web.Context;
using NonFactors.Mvc.Grid.Web.Models;
using OfficeOpenXml;
using System;
using System.Linq;

namespace NonFactors.Mvc.Grid.Web.Controllers
{
    public class GridController : Controller
    {
        [HttpGet]
        public ViewResult Ajax()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AjaxGrid()
        {
            return PartialView("_AjaxGrid", PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult MultiFiltering()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult GlobalSearch()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GridSearchPartial(String search)
        {
            return PartialView("_AjaxSearchGrid", PeopleRepository.GetPeople(search));
        }

        [HttpGet]
        public ViewResult FilterModes()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Filtering()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Sorting()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult RowStyling()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult SourceUrl()
        {
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_SourceUrlGrid", PeopleRepository.GetPeople());

            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult RowAttributes()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult RowProcessing()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Styling()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult EmptyText()
        {
            return View(Enumerable.Empty<Person>());
        }

        [HttpGet]
        public ViewResult Multiple()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Paging()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult ManualPaging(Int32? rows, Int32? page)
        {
            ViewBag.TotalRows = PeopleRepository.GetPeople().Count();

            return View(PeopleRepository.GetPeople().Skip((page - 1 ?? 0) * (rows ?? 3)).Take(rows ?? 3));
        }

        [HttpGet]
        public ViewResult HtmlAttributes()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Id()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Partial()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Localization()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ViewResult Export()
        {
            return View(CreateExportableGrid());
        }

        [HttpGet]
        public FileContentResult GetExport()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                Int32 row = 2;
                Int32 col = 1;
                package.Workbook.Worksheets.Add("Data");
                IGrid<Person> grid = CreateExportableGrid();
                ExcelWorksheet sheet = package.Workbook.Worksheets["Data"];

                foreach (IGridColumn column in grid.Columns)
                {
                    sheet.Cells[1, col].Value = column.Title;
                    sheet.Column(col++).Width = 18;

                    column.IsEncoded = false;
                }

                foreach (IGridRow<Object> gridRow in grid.Rows)
                {
                    col = 1;
                    foreach (IGridColumn column in grid.Columns)
                        sheet.Cells[row, col++].Value = column.ValueFor(gridRow);

                    row++;
                }

                return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Export.xlsx");
            }
        }

        [HttpGet]
        public ViewResult Footer()
        {
            return View(PeopleRepository.GetPeople());
        }


        private IGrid<Person> CreateExportableGrid()
        {
            IGrid<Person> grid = new Grid<Person>(PeopleRepository.GetPeople());
            grid.ViewContext = new ViewContext { HttpContext = HttpContext };
            grid.Query = Request.Query;

            grid.Columns.Add(model => model.Name);
            grid.Columns.Add(model => model.Surname);

            grid.Columns.Add(model => model.Age);
            grid.Columns.Add(model => model.Birthday).Formatted("{0:d}");
            grid.Columns.Add(model => model.IsWorking);

            grid.Pager = new GridPager<Person>(grid);
            grid.Processors.Add(grid.Pager);
            grid.Pager.RowsPerPage = 6;

            foreach (IGridColumn column in grid.Columns)
            {
                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }
    }
}
