using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMS.Models;

namespace CRMS.Controllers
{
    public class CRMS700Controller : Controller
    {
        private CRMSEntities db = new CRMSEntities();

        // GET: /CRMS700/
        public ActionResult Index()
        {
            return View(db.CRMS_700.ToList());
        }

        // GET: /CRMS700/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_700 crms_700 = db.CRMS_700.Find(id);
            if (crms_700 == null)
            {
                return HttpNotFound();
            }
            return View(crms_700);
        }

        // GET: /CRMS700/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CRMS700/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Unique_Identifcation_Type,Unique_Identifcation_Number,CRMS_Reference_Number,Credit_Purpose_By_Business_Lines,Credit_Purpose_By_Business_Lines_Subsector,Fee_Type1,Fee_Amount1,Fee_Type2,Fee_Amount2,Fee_Type3,Fee_Amount3,Fee_Type4,Fee_Amount4,Fee_Type5,Fee_Amount5,Fee_Type6,Fee_Amount6,Fee_Type7,Fee_Amount7,Fee_Type8,Fee_Amount8,Fee_Type9,Fee_Amount9,Fee_Type10,Fee_Amount10,Fee_Type11,Fee_Amount11,Fee_Type12,Fee_Amount12,Fee_Type13,Fee_Amount13,Fee_Type14,Fee_Amount14,Fee_Type15,Fee_Amount15,Fee_Type16,Fee_Amount16,Tenor,Beneficiary_Account_Number,Location_of_Beneficiary,Relationship_Type,Company_Size,Funding_Source_Category,ECCI_Number,Funding_Source,Legal_Status,Classification_By_Business_Lines,Classification_By_Business_Lines_Subsector,Specialised_Loan,Specialised_Loan_Period,Director_Id_Type1,Director_Id_Number1,Director_Id_Email1,Director_Id_Type2,Director_Id_Number2,Director_Id_Email2,Director_Id_Type3,Director_Id_Number3,Director_Id_Email3,Director_Id_Type4,Director_Id_Number4,Director_Id_Email4,Director_Id_Type5,Director_Id_Number5,Director_Id_Email5,Syndication,Syndication_Status,Syndication_Name,Syndication_Total_Amount,Syndication_Reference_Number,Collateral_Present1,Collateral_Secure1,Security_Type1,Address_of_Security1,Owner_of_Security1,Security_Id_Type1,Security_Id_Number1,Collateral_Secure2,Security_Type2,Address_of_Security2,Owner_of_Security2,Security_Id_Type2,Security_Id_Number2,Collateral_Secure3,Security_Type3,Address_of_Security3,Owner_of_Security3,Security_Id_Type3,Security_Id_Number3,Collateral_Secure4,Security_Type4,Address_of_Security4,Owner_of_Security4,Security_Id_Type4,Security_Id_Number4,Collateral_Secure5,Security_Type5,Address_of_Security5,Owner_of_Security5,Security_Id_Type5,Security_Id_Number5,Collateral_Secure6,Security_Type6,Address_of_Security6,Owner_of_Security6,Security_Id_Type6,Security_Id_Number6,Collateral_Secure7,Security_Type7,Address_of_Security7,Owner_of_Security7,Security_Id_Type7,Security_Id_Number7,Collateral_Secure8,Security_Type8,Address_of_Security8,Owner_of_Security8,Security_Id_Type8,Security_Id_Number8,Collateral_Secure9,Security_Type9,Address_of_Security9,Owner_of_Security9,Security_Id_Type9,Security_Id_Number9,Collateral_Secure10,Security_Type10,Address_of_Security10,Owner_of_Security10,Security_Id_Type10,Security_Id_Number10,Guarantee1,Guarantee_Type1,Guarantor_Id_Type1,Guarantor_Id_Number1,Amount_Guaranteed1,Guarantee_Type2,Guarantor_Id_Type2,Guarantor_Id_Number2,Amount_Guaranteed2,Guarantee_Type3,Guarantor_Id_Type3,Guarantor_Id_Number3,Amount_Guaranteed3,Guarantee_Type4,Guarantor_Id_Type4,Guarantor_Id_Number4,Amount_Guaranteed4,Guarantee_Type5,Guarantor_Id_Type5,Guarantor_Id_Number5,Amount_Guaranteed5,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_700 crms_700)
        {
            if (ModelState.IsValid)
            {
                db.CRMS_700.Add(crms_700);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crms_700);
        }

        // GET: /CRMS700/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_700 crms_700 = db.CRMS_700.Find(id);
            if (crms_700 == null)
            {
                return HttpNotFound();
            }
            return View(crms_700);
        }

        // POST: /CRMS700/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Unique_Identifcation_Type,Unique_Identifcation_Number,CRMS_Reference_Number,Credit_Purpose_By_Business_Lines,Credit_Purpose_By_Business_Lines_Subsector,Fee_Type1,Fee_Amount1,Fee_Type2,Fee_Amount2,Fee_Type3,Fee_Amount3,Fee_Type4,Fee_Amount4,Fee_Type5,Fee_Amount5,Fee_Type6,Fee_Amount6,Fee_Type7,Fee_Amount7,Fee_Type8,Fee_Amount8,Fee_Type9,Fee_Amount9,Fee_Type10,Fee_Amount10,Fee_Type11,Fee_Amount11,Fee_Type12,Fee_Amount12,Fee_Type13,Fee_Amount13,Fee_Type14,Fee_Amount14,Fee_Type15,Fee_Amount15,Fee_Type16,Fee_Amount16,Tenor,Beneficiary_Account_Number,Location_of_Beneficiary,Relationship_Type,Company_Size,Funding_Source_Category,ECCI_Number,Funding_Source,Legal_Status,Classification_By_Business_Lines,Classification_By_Business_Lines_Subsector,Specialised_Loan,Specialised_Loan_Period,Director_Id_Type1,Director_Id_Number1,Director_Id_Email1,Director_Id_Type2,Director_Id_Number2,Director_Id_Email2,Director_Id_Type3,Director_Id_Number3,Director_Id_Email3,Director_Id_Type4,Director_Id_Number4,Director_Id_Email4,Director_Id_Type5,Director_Id_Number5,Director_Id_Email5,Syndication,Syndication_Status,Syndication_Name,Syndication_Total_Amount,Syndication_Reference_Number,Collateral_Present1,Collateral_Secure1,Security_Type1,Address_of_Security1,Owner_of_Security1,Security_Id_Type1,Security_Id_Number1,Collateral_Secure2,Security_Type2,Address_of_Security2,Owner_of_Security2,Security_Id_Type2,Security_Id_Number2,Collateral_Secure3,Security_Type3,Address_of_Security3,Owner_of_Security3,Security_Id_Type3,Security_Id_Number3,Collateral_Secure4,Security_Type4,Address_of_Security4,Owner_of_Security4,Security_Id_Type4,Security_Id_Number4,Collateral_Secure5,Security_Type5,Address_of_Security5,Owner_of_Security5,Security_Id_Type5,Security_Id_Number5,Collateral_Secure6,Security_Type6,Address_of_Security6,Owner_of_Security6,Security_Id_Type6,Security_Id_Number6,Collateral_Secure7,Security_Type7,Address_of_Security7,Owner_of_Security7,Security_Id_Type7,Security_Id_Number7,Collateral_Secure8,Security_Type8,Address_of_Security8,Owner_of_Security8,Security_Id_Type8,Security_Id_Number8,Collateral_Secure9,Security_Type9,Address_of_Security9,Owner_of_Security9,Security_Id_Type9,Security_Id_Number9,Collateral_Secure10,Security_Type10,Address_of_Security10,Owner_of_Security10,Security_Id_Type10,Security_Id_Number10,Guarantee1,Guarantee_Type1,Guarantor_Id_Type1,Guarantor_Id_Number1,Amount_Guaranteed1,Guarantee_Type2,Guarantor_Id_Type2,Guarantor_Id_Number2,Amount_Guaranteed2,Guarantee_Type3,Guarantor_Id_Type3,Guarantor_Id_Number3,Amount_Guaranteed3,Guarantee_Type4,Guarantor_Id_Type4,Guarantor_Id_Number4,Amount_Guaranteed4,Guarantee_Type5,Guarantor_Id_Type5,Guarantor_Id_Number5,Amount_Guaranteed5,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_700 crms_700)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crms_700).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crms_700);
        }

        // GET: /CRMS700/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_700 crms_700 = db.CRMS_700.Find(id);
            if (crms_700 == null)
            {
                return HttpNotFound();
            }
            return View(crms_700);
        }

        // POST: /CRMS700/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRMS_700 crms_700 = db.CRMS_700.Find(id);
            db.CRMS_700.Remove(crms_700);
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
