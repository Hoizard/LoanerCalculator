using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoanerCalculator.Models;

namespace LoanerCalculator.Controllers
{
    public class CalculateModelsController : Controller
    {
        private LoanerCalculatorContext db = new LoanerCalculatorContext();

        // GET: CalculateModels
        public ActionResult Index()
        {
            return View(db.CalculateModels.ToList());
        }

        // GET: CalculateModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculateModel calculateModel = db.CalculateModels.Find(id);
            if (calculateModel == null)
            {
                return HttpNotFound();
            }
            return View(calculateModel);
        }

        // GET: CalculateModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalculateModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrincipleAmount,LoanDuration,InterestRate")] CalculateModel calculateModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CalculateTemp = ComputeMortgage.ComputeMonthlyPayment(calculateModel.PrincipleAmount,calculateModel.LoanDuration,calculateModel.InterestRate);
                ViewBag.Msg = $"The Cost is is {ViewBag.CalculateTemp}";
                calculateModel.Results = ComputeMortgage.ComputeMonthlyPayment(calculateModel.PrincipleAmount, calculateModel.LoanDuration, calculateModel.InterestRate);

                db.CalculateModels.Add(calculateModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calculateModel);
        }

        // GET: CalculateModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculateModel calculateModel = db.CalculateModels.Find(id);
            if (calculateModel == null)
            {
                return HttpNotFound();
            }
            return View(calculateModel);
        }

        // POST: CalculateModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrincipleAmount,LoanDuration,InterestRate")] CalculateModel calculateModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calculateModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calculateModel);
        }

        // GET: CalculateModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalculateModel calculateModel = db.CalculateModels.Find(id);
            if (calculateModel == null)
            {
                return HttpNotFound();
            }
            return View(calculateModel);
        }

        // POST: CalculateModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalculateModel calculateModel = db.CalculateModels.Find(id);
            db.CalculateModels.Remove(calculateModel);
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
