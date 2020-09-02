using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        public object DUI { get; private set; }
        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Tables.ToList());
        }

        [HttpPost]

        

                // GET: Insuree/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Table table = db.Tables.Find(id);
                if (table == null)
                {
                    return HttpNotFound();
                }
                return View(table);
                
            }

            // GET: Insuree/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Insuree/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Id, FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake, CarModel, DUI, SpeedingTickets, CoverageType, Quote")] Table table)
            {
                if (ModelState.IsValid)
                {
                decimal total = 50;
                var today = DateTime.Today;
                var age = today.Year - table.DateOfBirth.Year;
                if (age > 25)
                {
                    total = total + 25;
                }
                else if (age > 18 && age < 25)
                {
                    total = total + 50;

                }
                else if (age <= 18)
                {
                    total = total + 100;
                }


                if (table.CarYear < 2000)
                {
                    total = total + 25;
                }
                else if (table.CarYear > 2015)
                {
                    total = total + 25;
                }

                if (table.CarMake == "Porsche")
                {
                    total = total + 25;
                }

                if (table.CarMake == "Porsche" && table.CarModel == "911 Carrera")
                {
                    total = total + 25;
                }
                
                if (table.SpeedingTickets > 0)
                {
                    total = total + (table.SpeedingTickets * 10);
                }

                if (table.DUI == true)
                {
                    total = total + (total * 25 / 100);
                }
                else
                {
                    total = total + 0;
                }



                if (table.CoverageType == true)
                {
                    total = total + (total * 50 / 100);
                }
                else
                {
                    total = total + 0;
                }
                table.Quote = total;
                db.Tables.Add(table);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(table);
            }

            // GET: Insuree/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Table table = db.Tables.Find(id);
                if (table == null)
                {
                    return HttpNotFound();
                }
                return View(table);
            }

            // POST: Insuree/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Table table)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(table).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(table);
            }

            // GET: Insuree/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Table table = db.Tables.Find(id);
                if (table == null)
                {
                    return HttpNotFound();
                }
                return View(table);
            }

            // POST: Insuree/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Table table = db.Tables.Find(id);
                db.Tables.Remove(table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
