using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Organization.Models;

namespace Organization.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly OrganisationContext _context;

        public ProjectsController(OrganisationContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var organisationContext = _context.Project.Include(p => p.Product);
            return View(await organisationContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            var employeeNames = _context.Employee.Select(e => e.EmployeeName).ToList();

            // Set the employeeNames in the ViewData
            ViewData["EmployeeNames"] = employeeNames;

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,DueDate,Status,ProductID,SelectedEmployees")] Project project)
        {
            if (ModelState.IsValid)
            {
                // Add the project to the context and save changes
                _context.Project.Add(project);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Retrieve and log the validation errors
            var validationErrors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            foreach (var error in validationErrors)
            {
                Console.WriteLine(error);
            }

            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", project.ProductID);
            return View(project);
        }


        // GET: Projects/GetEmployeeNames
        [HttpGet]
        public IActionResult GetEmployeeNames(int productId)
        {
            var selectedProduct = _context.Product
            .Include(p => p.Employees)
            .FirstOrDefault(p => p.ProductID == productId);

            var employeeNames = selectedProduct?.Employees.Select(e => e.EmployeeName).ToList();

            return Json(employeeNames); 
        }



        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            var employeeNames = _context.Employee.Select(e => e.EmployeeName).ToList();

            // Set the employeeNames in the ViewData
            ViewData["EmployeeNames"] = employeeNames;

            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
    
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,DueDate,Status,ProductID,SelectedEmployees")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            ViewData["Products"] = new SelectList(_context.Product, "ProductID", "ProductName", project.ProductID);
            var employeeNames = _context.Employee.Select(e => e.EmployeeName).ToList();

            // Set the employeeNames in the ViewData
            ViewData["EmployeeNames"] = employeeNames;
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Project == null)
            {
                return Problem("Entity set 'OrganisationContext.Project'  is null.");
            }
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return (_context.Project?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
