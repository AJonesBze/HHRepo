using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using symptest.Models;

namespace symptest
{
    public class AdminController : Controller
    {
        AdminDataAccessLayer objAdmin = new AdminDataAccessLayer();
        [HttpGet]
        public IActionResult CreateAdmin()
        {


            return View();
        }//end of IActionResult


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAdmin([Bind] Models.Admin admin)
        {

            if (ModelState.IsValid)
            {
                objAdmin.CreateAdmin(admin);
                return RedirectToAction("Index");

            }//end of if
            return View(admin);
        }//end AddAdmin

        [HttpGet]
        public IActionResult Index()
        {
            List<Admin> lstAdmins = new List<Admin>();
            lstAdmins = objAdmin.GetAllAdmins().ToList();

            return View(lstAdmins);
        }//end of Index

    }//end of controller

}//end of namespace