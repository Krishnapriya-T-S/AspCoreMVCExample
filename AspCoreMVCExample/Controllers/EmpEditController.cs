using Microsoft.AspNetCore.Mvc;
using AspCoreMVCExample.Models;
using System.Linq;

namespace AspCoreMVCExample.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index method to retrieve and display employee data
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // GET: Edit method to retrieve employee data for editing
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Eid == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Edit method to update employee data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _context.Employees.FirstOrDefault(e => e.Eid == employee.eid);
                if (existingEmployee != null)
                {
                    existingEmployee.Ename = employee.ename;
                    existingEmployee.Eaddr = employee.eaddr;
                    existingEmployee.Esal = employee.esal;
                    _context.SaveChanges();

                    TempData["msg1"] = "Employee updated successfully!";
                    return RedirectToAction("Index");
                }
            }
            return View(employee);
        }
    }
}
