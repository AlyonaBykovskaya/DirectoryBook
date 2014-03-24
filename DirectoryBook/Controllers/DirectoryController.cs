using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DirectoryBook.Models;


namespace DirectoryBook.Controllers
{
    public class DirectoryController : Controller
    {
        //
        // GET: /Directory/

        private PersonsDBEntities db= new PersonsDBEntities();

        public ActionResult ShowData()
        {
            
            var persons = db.Phones.Include(n => n.Name);

                return View(persons.ToList());

           
        }
        [HttpGet]
        public ActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddData(Phone phone,Name name)
        {
           
            try
            {

                if (ModelState.IsValid)
                {

                    db.Names.Add(name);
                    db.Phones.Add(phone);
                    db.SaveChanges();
                    return RedirectToAction("ShowData");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }

            return View();


        }
        [HttpGet]
        public ActionResult EditData(int? id)
        {

            Phone phone = db.Phones.Single(s => s.Id == id);

            return View(phone);
        }

        [HttpPost]
        public ActionResult EditData(Phone phone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbPhone = db.Phones.Where(x => x.Id == phone.Id).FirstOrDefault();
                    if (dbPhone == null) return RedirectToAction("ShowData");
                    dbPhone.Name.TName = phone.Name.TName;
                    dbPhone.Name.Surname = phone.Name.Surname;
                    dbPhone.Name = phone.Name;
                    dbPhone.Tel = phone.Tel;
                    dbPhone.Additional_Information = phone.Additional_Information;
                    db.SaveChanges();
                    return RedirectToAction("ShowData");
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {

            Phone phone = db.Phones.Single(s => s.Id == id);

            return View(phone);

        }

        [HttpPost]
        public ActionResult Delete(Phone phone)
        {
            try
            {
                var dbPhone = db.Phones.Where(x => x.Id == phone.Id).FirstOrDefault();
                if (dbPhone == null) return RedirectToAction("ShowData");
                db.Phones.Remove(dbPhone);
                db.SaveChanges();

                return RedirectToAction("ShowData");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
                return View();
            }

        }

        }

    }

