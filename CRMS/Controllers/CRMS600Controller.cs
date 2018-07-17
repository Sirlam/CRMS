using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMS.Models;
using CRMS.Utils;

namespace CRMS.Controllers
{
    public class CRMS600Controller : Controller
    {
        private CRMSEntities db = new CRMSEntities();

        // GET: /CRMS600/
        public ActionResult Index()
        {
            return View(db.CRMS_600.ToList());
        }

        // GET: /CRMS600/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_600 crms_600 = db.CRMS_600.Find(id);
            if (crms_600 == null)
            {
                return HttpNotFound();
            }
            return View(crms_600);
        }

        // GET: /CRMS600/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CRMS600/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Syndication_Reference_Number,Syndication_Name,Syndication_Total_Amount,Participating_Bank_COde,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_600 crms_600)
        {
            if (ModelState.IsValid)
            {
                db.CRMS_600.Add(crms_600);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crms_600);
        }

        // GET: /CRMS600/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_600 crms_600 = db.CRMS_600.Find(id);
            if (crms_600 == null)
            {
                return HttpNotFound();
            }
            return View(crms_600);
        }

        // POST: /CRMS600/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Syndication_Reference_Number,Syndication_Name,Syndication_Total_Amount,Participating_Bank_COde,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_600 crms_600)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crms_600).State = EntityState.Modified;
                db.SaveChanges();
                var saveData = new SaveData();
                if (crms_600.CRMS_Ref_Number != null)
                    saveData.SendMail(new string[] { crms_600.Inputter_ID + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS Reference Number updated " + crms_600.Modifier_ID, "CRMS Reference Number: " + crms_600.CRMS_Ref_Number + " \n has been generated for your CRMS 600 request");
                return RedirectToAction("Index");
            }
            return View(crms_600);
        }

        // GET: /CRMS600/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_600 crms_600 = db.CRMS_600.Find(id);
            if (crms_600 == null)
            {
                return HttpNotFound();
            }
            return View(crms_600);
        }

        // POST: /CRMS600/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRMS_600 crms_600 = db.CRMS_600.Find(id);
            db.CRMS_600.Remove(crms_600);
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
