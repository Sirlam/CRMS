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
    public class CRMS300Controller : Controller
    {
        private CRMSEntities db = new CRMSEntities();

        // GET: /CRMS300/
        public ActionResult Index()
        {
            return View(db.CRMS_300.ToList());
        }

        // GET: /CRMS300/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_300 crms_300 = db.CRMS_300.Find(id);
            if (crms_300 == null)
            {
                return HttpNotFound();
            }
            return View(crms_300);
        }

        // GET: /CRMS300/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CRMS300/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Unique_Identifcation_Type,Unique_Identifcation_Number,Credit_Type,Credit_Purpose_By_Business_Lines,Credit_Purpose_By_Business_Lines_Subsector,Credit_Limit,Outstanding_Amount,Fee_Type1,Fee_Amount1,Fee_Type2,Fee_Amount2,Fee_Type3,Fee_Amount3,Fee_Type4,Fee_Amount4,Fee_Type5,Fee_Amount5,Fee_Type6,Fee_Amount6,Fee_Type7,Fee_Amount7,Fee_Type8,Fee_Amount8,Fee_Type9,Fee_Amount9,Fee_Type10,Fee_Amount10,Fee_Type11,Fee_Amount11,Fee_Type12,Fee_Amount12,Fee_Type13,Fee_Amount13,Fee_Type14,Fee_Amount14,Fee_Type15,Fee_Amount15,Fee_Type16,Fee_Amount16,Effective_Date,Tenor,Expiry_Date,Repayment_Agreement_Mode,Interest_Rate,Beneficiary_Account_Number,Location_of_Beneficiary,Relationship_Type,Company_Size,Funding_Source_Category,ECCI_Number,Funding_Source,Legal_Status,Classification_By_Business_Lines,Classification_By_Business_Lines_Subsector,Specialised_Loan,Specialised_Loan_Period,Director_Id_Type1,Director_Id_Number1,Director_Id_Email1,Director_Id_Type2,Director_Id_Number2,Director_Id_Email2,Director_Id_Type3,Director_Id_Number3,Director_Id_Email3,Director_Id_Type4,Director_Id_Number4,Director_Id_Email4,Director_Id_Type5,Director_Id_Number5,Director_Id_Email5,Syndication,Syndication_Status,Syndication_Reference_Number,Collateral_Present1,Collateral_Secure1,Security_Type1,Address_of_Security1,Owner_of_Security1,Security_Id_Type1,Security_Id_Number1,Collateral_Secure2,Security_Type2,Address_of_Security2,Owner_of_Security2,Security_Id_Type2,Security_Id_Number2,Collateral_Secure3,Security_Type3,Address_of_Security3,Owner_of_Security3,Security_Id_Type3,Security_Id_Number3,Collateral_Secure4,Security_Type4,Address_of_Security4,Owner_of_Security4,Security_Id_Type4,Security_Id_Number4,Collateral_Secure5,Security_Type5,Address_of_Security5,Owner_of_Security5,Security_Id_Type5,Security_Id_Number5,Collateral_Secure6,Security_Type6,Address_of_Security6,Owner_of_Security6,Security_Id_Type6,Security_Id_Number6,Collateral_Secure7,Security_Type7,Address_of_Security7,Owner_of_Security7,Security_Id_Type7,Security_Id_Number7,Collateral_Secure8,Security_Type8,Address_of_Security8,Owner_of_Security8,Security_Id_Type8,Security_Id_Number8,Collateral_Secure9,Security_Type9,Address_of_Security9,Owner_of_Security9,Security_Id_Type9,Security_Id_Number9,Collateral_Secure10,Security_Type10,Address_of_Security10,Owner_of_Security10,Security_Id_Type10,Security_Id_Number10,Guarantee1,Guarantee_Type1,Guarantor_Id_Type1,Guarantor_Id_Number1,Amount_Guaranteed1,Guarantee_Type2,Guarantor_Id_Type2,Guarantor_Id_Number2,Amount_Guaranteed2,Guarantee_Type3,Guarantor_Id_Type3,Guarantor_Id_Number3,Amount_Guaranteed3,Guarantee_Type4,Guarantor_Id_Type4,Guarantor_Id_Number4,Amount_Guaranteed4,Guarantee_Type5,Guarantor_Id_Type5,Guarantor_Id_Number5,Amount_Guaranteed5,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_300 crms_300)
        {
            if (ModelState.IsValid)
            {
                db.CRMS_300.Add(crms_300);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crms_300);
        }

        // GET: /CRMS300/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_300 crms_300 = db.CRMS_300.Find(id);
            if (crms_300 == null)
            {
                return HttpNotFound();
            }
            return View(crms_300);
        }

        // POST: /CRMS300/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Code,Customer_ID,Customer_Account_Number,Customer_Name,Unique_Identifcation_Type,Unique_Identifcation_Number,Credit_Type,Credit_Purpose_By_Business_Lines,Credit_Purpose_By_Business_Lines_Subsector,Credit_Limit,Outstanding_Amount,Fee_Type1,Fee_Amount1,Fee_Type2,Fee_Amount2,Fee_Type3,Fee_Amount3,Fee_Type4,Fee_Amount4,Fee_Type5,Fee_Amount5,Fee_Type6,Fee_Amount6,Fee_Type7,Fee_Amount7,Fee_Type8,Fee_Amount8,Fee_Type9,Fee_Amount9,Fee_Type10,Fee_Amount10,Fee_Type11,Fee_Amount11,Fee_Type12,Fee_Amount12,Fee_Type13,Fee_Amount13,Fee_Type14,Fee_Amount14,Fee_Type15,Fee_Amount15,Fee_Type16,Fee_Amount16,Effective_Date,Tenor,Expiry_Date,Repayment_Agreement_Mode,Interest_Rate,Beneficiary_Account_Number,Location_of_Beneficiary,Relationship_Type,Company_Size,Funding_Source_Category,ECCI_Number,Funding_Source,Legal_Status,Classification_By_Business_Lines,Classification_By_Business_Lines_Subsector,Specialised_Loan,Specialised_Loan_Period,Director_Id_Type1,Director_Id_Number1,Director_Id_Email1,Director_Id_Type2,Director_Id_Number2,Director_Id_Email2,Director_Id_Type3,Director_Id_Number3,Director_Id_Email3,Director_Id_Type4,Director_Id_Number4,Director_Id_Email4,Director_Id_Type5,Director_Id_Number5,Director_Id_Email5,Syndication,Syndication_Status,Syndication_Reference_Number,Collateral_Present1,Collateral_Secure1,Security_Type1,Address_of_Security1,Owner_of_Security1,Security_Id_Type1,Security_Id_Number1,Collateral_Secure2,Security_Type2,Address_of_Security2,Owner_of_Security2,Security_Id_Type2,Security_Id_Number2,Collateral_Secure3,Security_Type3,Address_of_Security3,Owner_of_Security3,Security_Id_Type3,Security_Id_Number3,Collateral_Secure4,Security_Type4,Address_of_Security4,Owner_of_Security4,Security_Id_Type4,Security_Id_Number4,Collateral_Secure5,Security_Type5,Address_of_Security5,Owner_of_Security5,Security_Id_Type5,Security_Id_Number5,Collateral_Secure6,Security_Type6,Address_of_Security6,Owner_of_Security6,Security_Id_Type6,Security_Id_Number6,Collateral_Secure7,Security_Type7,Address_of_Security7,Owner_of_Security7,Security_Id_Type7,Security_Id_Number7,Collateral_Secure8,Security_Type8,Address_of_Security8,Owner_of_Security8,Security_Id_Type8,Security_Id_Number8,Collateral_Secure9,Security_Type9,Address_of_Security9,Owner_of_Security9,Security_Id_Type9,Security_Id_Number9,Collateral_Secure10,Security_Type10,Address_of_Security10,Owner_of_Security10,Security_Id_Type10,Security_Id_Number10,Guarantee1,Guarantee_Type1,Guarantor_Id_Type1,Guarantor_Id_Number1,Amount_Guaranteed1,Guarantee_Type2,Guarantor_Id_Type2,Guarantor_Id_Number2,Amount_Guaranteed2,Guarantee_Type3,Guarantor_Id_Type3,Guarantor_Id_Number3,Amount_Guaranteed3,Guarantee_Type4,Guarantor_Id_Type4,Guarantor_Id_Number4,Amount_Guaranteed4,Guarantee_Type5,Guarantor_Id_Type5,Guarantor_Id_Number5,Amount_Guaranteed5,Inputter_ID,Inputter_Date_Stamp,Modifier_ID,Modifier_Date_Stamp,CRMS_Ref_Number,Loan_Ref_Number")] CRMS_300 crms_300)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crms_300).State = EntityState.Modified;
                db.SaveChanges();
                var saveData = new SaveData();
                if (crms_300.CRMS_Ref_Number!=null)
                    saveData.SendMail(new string[] { crms_300.Inputter_ID + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS Reference Number updated " + crms_300.Modifier_ID, "CRMS Reference Number: "+crms_300.CRMS_Ref_Number+" \n has been generated for your CRMS 300 request");
            
                return RedirectToAction("Index");
            }
            return View(crms_300);
        }

        // GET: /CRMS300/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMS_300 crms_300 = db.CRMS_300.Find(id);
            if (crms_300 == null)
            {
                return HttpNotFound();
            }
            return View(crms_300);
        }

        // POST: /CRMS300/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRMS_300 crms_300 = db.CRMS_300.Find(id);
            db.CRMS_300.Remove(crms_300);
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
