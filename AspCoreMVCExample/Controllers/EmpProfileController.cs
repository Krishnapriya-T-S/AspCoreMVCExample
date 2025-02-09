using Microsoft.AspNetCore.Mvc;
using AspCoreMVCExample.Models;
namespace AspCoreMVCExample.Controllers
{
    public class EmpProfileController : Controller
    {
        EmployeeDB dbobj = new EmployeeDB();
        public IActionResult UserProfile_PageLoad(int id)
        {
            Employee getlist = dbobj.SelectProfileDB(id);
            return View(getlist);
        }
        public IActionResult Profile_Update_click(Employee obcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string s = dbobj.UpdateDB(obcls);
                    TempData["msg1"] = s;
                }
            }
            catch(Exception ex)
            {
                TempData["msg1"] = ex.Message.ToString();
            }
             return View("UserProfile_PageLoad");
           // return View("Edit"); 
        }

    }
}
