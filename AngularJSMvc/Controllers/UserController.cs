﻿using AngularJSMvc.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace AngularJSMvc.Controllers
{
    public class UserController : Controller
    {
        private AngularJSDbContext db = null;

        public UserController()
        {
            db = new AngularJSDbContext();
        }

        // GET: User
        public JsonResult Index()
        {
            var users = db.Users.ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Details(int id)
        {
            var user = db.Users.Find(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return null;
        }

        [HttpPost]
        public JsonResult Edit(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return null;
        }

        public JsonResult Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return null;
        }
    }
}