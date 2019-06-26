using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using DatabaseActivities.Models;
using DatabaseActivities.Models.Entity;
using DatabaseActivities.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseActivities.Controllers
{
    public class StudentsController : Controller
    {
        private StudentService service = new StudentService();

        // GET: Students
        public ActionResult Index()
        {
            return View(service.GetAllStudents());
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            Student student = service.GetStudentById(id);
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                service.AddStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = service.GetStudentById(id);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                service.SaveEdits(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = service.GetStudentById(id);
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = service.GetStudentById(id);
            service.DeleteStudent(student);
            return RedirectToAction("Index");
        }
    }
}
