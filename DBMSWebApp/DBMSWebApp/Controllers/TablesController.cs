using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBMSWebApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DBMSWebApp.Controllers
{
    public class TablesController : Controller
    {
        private readonly DatabaseContext _context;

        public TablesController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? databaseId)
        {
            ViewBag.DatabaseId = databaseId;
            var databaseContext = _context.Tables.Where(t=> t.DatabaseId == databaseId).Include(t=>t.Database);
            return View(await databaseContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Tables
                .Include(t => t.Database)
                .Include(t=>t.Columns)
                .Include(t=>t.Rows)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Rows", new { tableId = table.Id });
        }

        public IActionResult Create(int? databaseId)
        {
            ViewBag.DatabaseId = databaseId;
            return View() ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DatabaseId")] Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Tables", new { databaseId = table.DatabaseId });
            }
            return View(table);
        }
 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            var table = await _context.Tables
                .Include(t => t.Database)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var columns = _context.Columns.Where(t => t.TableId == id);
            var rows = _context.Rows.Where(t => t.TableId == id);
            foreach (var row in rows)
            {
                var cells = _context.Cells.Where(t => t.RowId == row.Id);
                _context.RemoveRange(cells);
            }
            _context.RemoveRange(rows);
            _context.RemoveRange(columns);
            var table = await _context.Tables.FindAsync(id);
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Tables", new { databaseId = table.DatabaseId });
        }

        private bool TableExists(int id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }

        public IActionResult Cartesian(int? databaseId)
        {
            var db = _context.Databases.Include(t=>t.Tables).First(t=>t.Id == databaseId);
            if(db.Tables.Count < 2)
            {
                ModelState.AddModelError("Database", string.Format("Database {0} contains only {1} tables",db.Name, db.Tables.Count));
                return View();
            }
            ViewBag.DatabaseId = databaseId;
            ViewBag.Tables = new SelectList(_context.Tables.Where(t=>t.DatabaseId == databaseId), "Id", "Name");
            var firstTable = _context.Tables.Where(t => t.DatabaseId == databaseId).First();
            ViewBag.Columns = new SelectList(_context.Columns.Where(t => t.TableId == firstTable.Id), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CartesianProduct([Bind("FirstTable, SecondTable")] CartesianViewModel joinModel)
        {
            var firsttbl = _context.Tables.Include(t => t.Columns).Include(t => t.Rows).FirstOrDefault(t => t.Id == joinModel.FirstTable);
            var secondtbl = _context.Tables.Include(t => t.Columns).Include(t => t.Rows).FirstOrDefault(t => t.Id == joinModel.SecondTable);

            var rows1 = _context.Rows.Where(t => t.TableId == joinModel.FirstTable).ToList();
            var rows2 = _context.Rows.Where(t => t.TableId == joinModel.SecondTable).ToList();


            var table = new Table
            {
                Columns = firsttbl.Columns.ToList()
            };
            foreach (var col in secondtbl.Columns)
            {
                    table.Columns.Add(col);
            }

            foreach (var row1 in rows1)
            {
                var cells1 = _context.Cells.Where(q => q.RowId == row1.Id).ToList();
                foreach (var row2 in rows2)
                {
                    var row = new Row();

                    var cells2 = _context.Cells.Where(q => q.RowId == row2.Id).ToList();

                    row.Cells.AddRange(cells1);
                    row.Cells.AddRange(cells2);
                    table.Rows.Add(row);
                }
            }
            table.Name = "Cartesian of " + firsttbl.Name + ", " + secondtbl.Name;
            table.DatabaseId = firsttbl.DatabaseId;

            return View(table);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetColumns(int tableId)
        {
            List<Column> columns = await _context.Columns.Where(x => x.TableId == tableId).ToListAsync();
            return Json(columns);

        }
    }
}
