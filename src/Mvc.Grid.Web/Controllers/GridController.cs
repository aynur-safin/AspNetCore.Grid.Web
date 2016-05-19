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
        public ActionResult RowProcessing()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Ajax()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GridPartial()
        {
            return PartialView("_AjaxGrid", PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult MultiFiltering()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult GlobalSearch()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GridSearchPartial(String search)
        {
            return PartialView("_AjaxSearchGrid", PeopleRepository.GetPeople(search));
        }

        [HttpGet]
        public ActionResult Filtering()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Sorting()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult RowStyling()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Styling()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult EmptyText()
        {
            return View(Enumerable.Empty<PersonModel>());
        }

        [HttpGet]
        public ActionResult Multiple()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Paging()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Partial()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Localization()
        {
            return View(PeopleRepository.GetPeople());
        }

        [HttpGet]
        public ActionResult Export()
        {
            return View(CreateExportableGrid());
        }

        [HttpGet]
        public ActionResult GetExport()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                Int32 row = 2;
                Int32 col = 1;
                package.Workbook.Worksheets.Add("Data");
                IGrid<PersonModel> grid = CreateExportableGrid();
                ExcelWorksheet sheet = package.Workbook.Worksheets["Data"];

                foreach (IGridColumn column in grid.Columns)
                {
                    sheet.Cells[1, col].Value = column.Title;
                    sheet.Column(col++).Width = 18;
                }

                foreach (var gridRow in grid.Rows)
                {
                    col = 1;
                    foreach (IGridColumn column in grid.Columns)
                        sheet.Cells[row, col++].Value = column.ValueFor(gridRow);

                    row++;
                }

                return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Export.xlsx");
            }
        }

        private IGrid<PersonModel> CreateExportableGrid()
        {
            IGrid<PersonModel> grid = new Grid<PersonModel>(PeopleRepository.GetPeople());
            grid.ViewContext = new ViewContext { HttpContext = HttpContext };
            grid.Query = Request.Query;

            grid.Columns.Add(model => model.Name).Titled("Name");
            grid.Columns.Add(model => model.Surname).Titled("Surname");

            grid.Columns.Add(model => model.Age).Titled("Age");
            grid.Columns.Add(model => model.Birthday).Titled("Birth date");
            grid.Columns.Add(model => model.IsWorking).Titled("Employed");

            grid.Pager = new GridPager<PersonModel>(grid);
            grid.Processors.Add(grid.Pager);
            grid.Pager.RowsPerPage = 6;

            foreach (IGridColumn column in grid.Columns)
            {
                column.IsFilterable = true;
                column.IsSortable = true;
            }

            return grid;
        }
    }
}