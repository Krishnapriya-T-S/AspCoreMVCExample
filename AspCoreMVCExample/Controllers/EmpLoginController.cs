using Microsoft.AspNetCore.Mvc;
using AspCoreMVCExample.Models;
namespace AspCoreMVCExample.Controllers
{
    public class EmpLoginController : Controller
    {
        EmployeeDB dbobj = new EmployeeDB();
        public IActionResult Log_PageLoad()
        {
            return View();
        }
        public IActionResult Log_click(Employee obcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.LoginDB(obcls);
                    if (resp == "Success")
                    {
                        // TempData["msg"] = resp;
                          return RedirectToAction("UserProfile_PageLoad", "EMPProfile", new {id= obcls.eid});
                         // return RedirectToAction("Index", "EMPEdit", new {id= obcls.eid});
                    }
                    else
                    {
                        TempData["msg"] = resp;
                    }

                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("Log_PageLoad");

        }
    }
}
