using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clientes.Models;

namespace Clientes.Controllers
{
    public class ClientsController : Controller
    {
        ClientesEntities clientesDB = new ClientesEntities();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = clientesDB.Clients.ToList();
            return View(clients);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            Client client = clientesDB.Clients.Find(id);
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                clientesDB.Clients.Add(client);
                clientesDB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(client);
            }
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            Client client = clientesDB.Clients.Find(id);
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            try
            {
                clientesDB.Entry(client).State = EntityState.Modified;
                clientesDB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(client);
            }
        }

    // GET: Clients/Delete/5
    public ActionResult Delete(int id)
        {
            Client client = clientesDB.Clients.Find(id);
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = clientesDB.Clients.Find(id);
            try
            {
                clientesDB.Clients.Remove(client);
                clientesDB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(client);
            }
        }

        protected override void Dispose(bool disposing)
        {
            clientesDB.Dispose();
            base.Dispose(disposing);
        }
    }
}
