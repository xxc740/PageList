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
            int pageSize = 5;
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
            }
            return View();
        }
    }
}