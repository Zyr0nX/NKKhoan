using NKKhoan.Models;
using NKKhoan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKKhoan.Areas.Admin.Controllers
{
    public class TaskController : Controller
    {
        private ApplicationDbContext _context;

        public TaskController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/Task
        public ActionResult Index()
        {
            var task = _context.NKSLK.ToList();
            return View(task);
        }

        public ViewResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var task = _context.NKSLK.SingleOrDefault(c => c.MaNKSLK == id);
            if (task == null)
                return HttpNotFound();
            return View(task);
        }

        public ActionResult Delete(int id)
        {
            var task = _context.NKSLK.SingleOrDefault(c => c.MaNKSLK == id);
            if (task == null)
                return HttpNotFound();
            else
            {
                _context.NKSLK.Remove(task);
                _context.SaveChanges();
                return RedirectToAction("Index", "Task");
            }
        }

        public ActionResult AssignWork(int idTask, int numOfWorks)
        {
            var task = _context.NKSLK.SingleOrDefault(c => c.MaNKSLK == idTask);
            if (task == null)
                return HttpNotFound();
            else
            {
                ViewBag.NumOfWorks = numOfWorks;
                return View(task);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NKSLK task)
        {
            if (task.MaNKSLK == 0)
                _context.NKSLK.Add(task);
            else
            {
                var NKSLKInDb = _context.NKSLK.Single(c => c.MaNKSLK == task.MaNKSLK);
                NKSLKInDb.MaNKSLK = task.MaNKSLK;
                NKSLKInDb.NgayThucHienKhoan = task.NgayThucHienKhoan;
                NKSLKInDb.GioBatDau = task.GioBatDau;
                NKSLKInDb.GioKetThuc = task.GioKetThuc;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Task");
        }
    }
}