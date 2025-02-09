using Microsoft.AspNetCore.Mvc;
using AspCoreMVCExample.Models;
namespace AspCoreMVCExample.Controllers
{
    public class DisplayAllController : Controller
    {
        EmployeeDB dbobj = new EmployeeDB();
        public IActionResult AllProfile_page()
        {
            List<Employee> getlist = dbobj.SelectDB();
            return View(getlist);
        }
    }
}
