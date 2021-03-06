using bigschool.Models;
using bigschool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace bigschool.Controllers
    {
        public class CoursesController : Controller
        {

            // GET: Courses
            private readonly ApplicationDbContext _dbContext;
            public CoursesController()
            {
                _dbContext = new ApplicationDbContext();
            }
            [Authorize]
            public ActionResult Attending()
            {
                var userId = User.Identity.GetUserId();

                var courses = _dbContext.Attendances
                    .Where(a => a.AttendeeId == userId)
                    .Select(a => a.Course)
                    .Include(l => l.Lecturer)
                    .Include(l => l.Category)
                    .ToList();

                var viewModel = new CoursesViewModel
                {
                    UpcommingCourses = courses,
                    ShowAction = User.Identity.IsAuthenticated

                };
                return View(viewModel);
            }
            [Authorize]
            public ActionResult Followings()
            {
                var userId = User.Identity.GetUserId();
                var courses = _dbContext.Courses
                    .Where(c => c.LecturerId == userId)
                    .Include(l => l.Lecturer)
                    .ToList();
                    return View(courses);
            }
        [Authorize]
        public ActionResult Mine()
            {
                var userId = User.Identity.GetUserId();

                var courses = _dbContext.Courses
                    .Where(c => c.LecturerId == userId && c.DateTime > DateTime.Now)
                    .Include(l => l.Lecturer)
                    .Include(l => l.Category)
                    .ToList();


            return View(courses);
        }
        public ActionResult ListCourse()
        {
            var userId = User.Identity.GetUserId();

            var courses = _dbContext.Courses
                .Where(c => c.LecturerId == userId)
                .Include(l => l.Lecturer)
                .Include(l => l.Category)
                .ToList();


            return View(courses);
        }

    }
    }

