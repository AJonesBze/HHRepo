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
    public class ClientController : Controller
    {
        ClientDataAccessLayer objClient = new ClientDataAccessLayer();
        [HttpGet]
        public IActionResult CreateClient()
        {

            return View();
        }//end of IActionResult


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateClient([Bind] Models.Client client)
        {

            if (ModelState.IsValid)
            {
                objClient.CreateClient(client);
                return RedirectToAction("Index");

            }//end of if
            return View(client);
        }//end Addclient

        [HttpGet]
        public IActionResult Index()
        {
            List<Client> lstClients = new List<Client>();
            lstClients = objClient.GetAllClients().ToList();

            return View(lstClients);
        }//end of Index

    }//end of controller

}//end of namespace