using CrudOperation.Models;
using CrudOperation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class CompanyController : Controller
    {
        StoreDataRepository oStoreDataRepository = new StoreDataRepository();
        [HttpGet]//how to enable cross origing policy in mvc..and....what is this and 
        public ActionResult PutDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PutDetails(EmployeeDetailsModel oEmployeeDetailsModel)       
        {
            oStoreDataRepository.InsertData(oEmployeeDetailsModel);

            return RedirectToAction("GetDetails");
        }
        public ActionResult GetDetails()
        {
            GetDetailsModel oGetDetailsModel = new GetDetailsModel();
            oGetDetailsModel.EmpList= oStoreDataRepository.getDetails();

            return View(oGetDetailsModel);
        }
        public ActionResult DeleteEmployee(int ID)
        {            
            oStoreDataRepository.DeleteEntery(ID);
            return RedirectToAction("GetDetails");
        }
        public ActionResult EditEmployee(int ID,EmployeeDetailsModel oEmployeeDetailsModel)
        {
           
            oStoreDataRepository.EditEntery(ID,oEmployeeDetailsModel);
            return View("EditEmployee", oEmployeeDetailsModel);
        }
    }
}