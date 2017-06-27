using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalRegister.Models;
using PersonalRegister.DataAccessLayer;

namespace PersonalRegister.Controllers
{
    public class PersonalsController : Controller
    {
        private RegisterContext db = new RegisterContext();

        // GET: Personals
        public ActionResult Index()
        {
            return View(db.Personals.ToList());
        }

        // GET: Personals
        public ActionResult SearchByDeptName2(string searchDept)
        {
            // var model = db.Personals.Where(i => i.Department == searchDept);
            //return View(model.ToList());

            var model = from dep in db.Personals
                        select dep;
            if(!String.IsNullOrEmpty(searchDept))
            {
                model = model.Where(s => s.Department.Contains(searchDept));
            }

            return View(model);

        }

        // GET: Personals
        // this methods shows department directly without inserting any string in URL
        // 
        public ActionResult SearchByDeptName1(string id)
        {
            // var model = db.Personals.Where(i => i.Department == searchDept);
            //return View(model.ToList());
            //http://localhost:49870/Personals/SearchByDeptName/GUI
            string searchDeptId = id;
            var model = from dep in db.Personals
                        select dep;
            if (!String.IsNullOrEmpty(searchDeptId))
            {
                model = model.Where(s => s.Department.Contains(searchDeptId));
            }

            return View(model);

        }

        // GET: Personals / LastName
        public ActionResult SearchByDeptName4(string searchLastName)
        {
            // var model = db.Personals.Where(i => i.Department == searchDept);
            //return View(model.ToList());

            var model = from dep in db.Personals
                        select dep;
            if (!String.IsNullOrEmpty(searchLastName))
            {
                model = model.Where(s => s.LastName.Contains(searchLastName));
            }

            return View(model);

        }



        // I want to search via two thing:

        // GET: Personals
        public ActionResult SearchByDeptName(string searchDept, string lastName)
        {
            // the first  lines of code create a LIST object to hold
            // department from database
            var deptList = new List<string>();

            //this LINQ query that retreives all the Department/lastName
            // from the database
            // Distinct() is used to remove the dublicates
            // the code then stores the list of department name in the viewbag object
            var deptQry = from d in db.Personals
                          orderby d.Department
                          select d.Department;

            // AddRange = 
            //Adds the elements of the specified collection to the end of the List<T>.
            deptList.AddRange(deptQry.Distinct());
            ViewBag.searchDept = new SelectList(deptList);

            var model = from dep in db.Personals
                        select dep;

            if (!String.IsNullOrEmpty(lastName))
            {
                model = model.Where(s => s.LastName.Contains(lastName));
            }

            if(string.IsNullOrEmpty(searchDept))
             return View(model);
            else
            {
                return View(model.Where(x => x.Department == searchDept));
            }
        }






        // GET: Personals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: Personals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Salary,Position,Department")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Personals.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personal);
        }

        // GET: Personals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Salary,Position,Department")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personal);
        }

        // GET: Personals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personals.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal personal = db.Personals.Find(id);
            db.Personals.Remove(personal);
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
