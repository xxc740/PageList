using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagingAndSorting.DBHelper;
using PagingAndSorting.Models;

namespace PagingAndSorting.Controllers
{
    public class StudentController : Controller
    {
        private StudentDBContext db = null;

        public StudentController() 
        {
            db = new StudentDBContext();
        }

        // GET: Student
        public ActionResult Index(string sortBy,string currentSort, int?page)
        {
            int pageIndex = 1;
            int pageSize = 10;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortBy;

            sortBy = string.IsNullOrEmpty(sortBy) ? "Name" : sortBy;
            IPagedList<Student> studentList = null;

            switch (sortBy)
            {
                case "Name":
                    if (sortBy.Equals(currentSort))
                    {
                        studentList = db.Set<Student>().OrderByDescending(s => s.Name).ToPagedList(pageIndex, pageSize);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        studentList = db.Set<Student>().OrderBy(s => s.Name).ToPagedList(pageIndex, pageSize);
                    }
                    break;

                case "Sex":
                    if (sortBy.Equals(currentSort))
                    {
                        studentList = db.Set<Student>().OrderByDescending(s => s.Sex).ToPagedList(pageIndex, pageSize);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        studentList = db.Set<Student>().OrderBy(s => s.Sex).ToPagedList(pageIndex, pageSize);
                    }
                    break;

                case "Email":
                    if (sortBy.Equals(currentSort))
                    {
                        studentList = db.Set<Student>().OrderByDescending(s => s.Email).ToPagedList(pageIndex, pageSize);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        studentList = db.Set<Student>().OrderBy(s => s.Email).ToPagedList(pageIndex, pageSize);
                    }
                    break;

                case "Age":
                    if (sortBy.Equals(currentSort))
                    {
                        studentList = db.Set<Student>().OrderByDescending(s => s.Age).ToPagedList(pageIndex, pageSize);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        studentList = db.Set<Student>().OrderBy(s => s.Age).ToPagedList(pageIndex, pageSize);
                    }
                    break;

                default:
                    if (sortBy.Equals(currentSort))
                    {
                        studentList = db.Set<Student>().OrderByDescending(s => s.Name).ToPagedList(pageIndex, pageSize);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        studentList = db.Set<Student>().OrderBy(s => s.Name).ToPagedList(pageIndex, pageSize);
                    }
                    break;
            }
            return View(studentList);
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(Student model)
        {
            db.Set<Student>().Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}