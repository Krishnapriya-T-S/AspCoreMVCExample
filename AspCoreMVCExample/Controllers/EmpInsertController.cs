using AspCoreMVCExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
namespace AspCoreMVCExample.Controllers
{
    public class EmpInsertController : Controller
    {
        EmployeeDB dbobj = new EmployeeDB();
        public IActionResult Insert_Load()
        {
            return View();
        }
        public IActionResult Insert_click(Employee objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.InsertDB(objcls);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("Insert_Load", objcls);
        }
    }
}