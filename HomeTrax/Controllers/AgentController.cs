﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTrax.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        //
        // GET: /Agent/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Agent/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Agent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Agent/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Agent/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Agent/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Agent/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Agent/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}