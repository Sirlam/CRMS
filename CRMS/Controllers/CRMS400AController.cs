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
    public class CRMS400AController : Controller
    {
        private CRMSEntities db = new CRMSEntities();

        // GET: /CRMS400A/
        public ActionResult Index()
        {
            return View(db.CRMS_400A.ToList());
        }

        // GET: /CRMS400A/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_400A crms_400a = db.CRMS_400A.Find(id);
            if (crms_400a == null)
            {
                return HttpNotFound();
            }
            return View(crms_400a);
        }

        // GET: /CRMS400A/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CRMS400A/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Unique_Identifcation_Type,Unique_Identifcation_Number,CRMS_Reference_Number,Effective_Date,Tenor,Expiry_Date,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_400A crms_400a)
        {
            if (ModelState.IsValid)
            {
                db.CRMS_400A.Add(crms_400a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crms_400a);
        }

        // GET: /CRMS400A/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_400A crms_400a = db.CRMS_400A.Find(id);
            if (crms_400a == null)
            {
                return HttpNotFound();
            }
            return View(crms_400a);
        }

        // POST: /CRMS400A/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Unique_Identifcation_Type,Unique_Identifcation_Number,CRMS_Reference_Number,Effective_Date,Tenor,Expiry_Date,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_400A crms_400a)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crms_400a).State = EntityState.Modified;
                db.SaveChanges();
                var saveData = new SaveData();
                if (crms_400a.CRMS_Ref_Number != null)
                    saveData.SendMail(new string[] { crms_400a.Inputter_ID + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS Reference Number updated " + crms_400a.Modifier_ID, "CRMS Reference Number: " + crms_400a.CRMS_Ref_Number + " \n has been generated for your CRMS 400A request");
                return RedirectToAction("Index");
            }
            return View(crms_400a);
        }

        // GET: /CRMS400A/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_400A crms_400a = db.CRMS_400A.Find(id);
            if (crms_400a == null)
            {
                return HttpNotFound();
            }
            return View(crms_400a);
        }

        // POST: /CRMS400A/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRMS_400A crms_400a = db.CRMS_400A.Find(id);
            db.CRMS_400A.Remove(crms_400a);
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
