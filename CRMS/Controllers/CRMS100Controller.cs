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
    public class CRMS100Controller : Controller
    {
        private CRMSEntities db = new CRMSEntities();

        // GET: /CRMS100/
        public ActionResult Index()
        {
            return View(db.CRMS_100.ToList());
        }

        // GET: /CRMS100/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_100 crms_100 = db.CRMS_100.Find(id);
            if (crms_100 == null)
            {
                return HttpNotFound();
            }
            return View(crms_100);
        }

        // GET: /CRMS100/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CRMS100/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Government_Code,Legal_Status,Credit_Type,Credit_Purpose_By_Business_Lines,Credit_Purpose_By_Business_Lines_Subsector,Credit_Limit,Outstanding_Amount,Fee_Type1,Fee_Amount1,Fee_Type2,Fee_Amount2,Fee_Type3,Fee_Amount3,Fee_Type4,Fee_Amount4,Fee_Type5,Fee_Amount5,Fee_Type6,Fee_Amount6,Fee_Type7,Fee_Amount7,Fee_Type8,Fee_Amount8,Fee_Type9,Fee_Amount9,Fee_Type10,Fee_Amount10,Fee_Type11,Fee_Amount11,Fee_Type12,Fee_Amount12,Fee_Type13,Fee_Amount13,Fee_Type14,Fee_Amount14,Fee_Type15,Fee_Amount15,Fee_Type16,Fee_Amount16,Effective_Date,Tenor,Expiry_Date,Repayment_Agreement_Mode,Specialised_Loan,Specialised_Loan_Period,Interest_Rate,Collateral_Present1,Collateral_Secure1,Security_Type1,Collateral_Secure2,Security_Type2,Collateral_Secure3,Security_Type3,Collateral_Secure4,Security_Type4,Collateral_Secure5,Security_Type5,Collateral_Secure6,Security_Type6,Collateral_Secure7,Security_Type7,Collateral_Secure8,Security_Type8,Collateral_Secure9,Security_Type9,Collateral_Secure10,Security_Type10,Repayment_Source,Syndication,Syndication_Status,Syndication_Reference_Number,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_100 crms_100)
        {
            if (ModelState.IsValid)
            {
                db.CRMS_100.Add(crms_100);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crms_100);
        }

        // GET: /CRMS100/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_100 crms_100 = db.CRMS_100.Find(id);
            if (crms_100 == null)
            {
                return HttpNotFound();
            }
            return View(crms_100);
        }

        // POST: /CRMS100/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Government_Code,Legal_Status,Credit_Type,Credit_Purpose_By_Business_Lines,Credit_Purpose_By_Business_Lines_Subsector,Credit_Limit,Outstanding_Amount,Fee_Type1,Fee_Amount1,Fee_Type2,Fee_Amount2,Fee_Type3,Fee_Amount3,Fee_Type4,Fee_Amount4,Fee_Type5,Fee_Amount5,Fee_Type6,Fee_Amount6,Fee_Type7,Fee_Amount7,Fee_Type8,Fee_Amount8,Fee_Type9,Fee_Amount9,Fee_Type10,Fee_Amount10,Fee_Type11,Fee_Amount11,Fee_Type12,Fee_Amount12,Fee_Type13,Fee_Amount13,Fee_Type14,Fee_Amount14,Fee_Type15,Fee_Amount15,Fee_Type16,Fee_Amount16,Effective_Date,Tenor,Expiry_Date,Repayment_Agreement_Mode,Specialised_Loan,Specialised_Loan_Period,Interest_Rate,Collateral_Present1,Collateral_Secure1,Security_Type1,Collateral_Secure2,Security_Type2,Collateral_Secure3,Security_Type3,Collateral_Secure4,Security_Type4,Collateral_Secure5,Security_Type5,Collateral_Secure6,Security_Type6,Collateral_Secure7,Security_Type7,Collateral_Secure8,Security_Type8,Collateral_Secure9,Security_Type9,Collateral_Secure10,Security_Type10,Repayment_Source,Syndication,Syndication_Status,Syndication_Reference_Number,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_100 crms_100)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crms_100).State = EntityState.Modified;
                db.SaveChanges(); 
                var saveData = new SaveData();
                if (crms_100.CRMS_Ref_Number != null)
                    saveData.SendMail(new string[] { crms_100.Inputter_ID + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS Reference Number updated " + crms_100.Modifier_ID, "CRMS Reference Number: " + crms_100.CRMS_Ref_Number + " \n has been generated for your CRMS 100 request");
            
                return RedirectToAction("Index");
            }
            return View(crms_100);
        }

        // GET: /CRMS100/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_100 crms_100 = db.CRMS_100.Find(id);
            if (crms_100 == null)
            {
                return HttpNotFound();
            }
            return View(crms_100);
        }

        // POST: /CRMS100/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRMS_100 crms_100 = db.CRMS_100.Find(id);
            db.CRMS_100.Remove(crms_100);
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
