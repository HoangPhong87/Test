using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class NhanSuController : Controller
    {
        // GET: NhanSu
        public ActionResult Index()
        {
            DsNhanSu danhsach = new DsNhanSu();
            List<NhanSu> obj = danhsach.getnhansu(string.Empty).OrderBy(x => x.FullName).ToList();
            return View(obj);
        }
        //them phuong thuc Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanSu ns)
        {
            if (ModelState.IsValid)
            {
                DsNhanSu danhsach = new DsNhanSu();
                danhsach.AddNhanSu(ns);
                return RedirectToAction("Index");
            }
            return View();
        }

        //Them phuong thuc Edit
        public ActionResult Edit(string id = "")
        {
            DsNhanSu danhsach = new DsNhanSu();
            List<NhanSu> obj = danhsach.getnhansu(id);
            return View(obj.FirstOrDefault());// lay ban ghi dau
        }
        [HttpPost]
        public ActionResult Edit (NhanSu ns)
        {
            DsNhanSu danhsach = new DsNhanSu();
            danhsach.UpdateNhanSu(ns);
            return RedirectToAction("Index");
        }

        //phuong thuc Details
        public ActionResult Details(string id = "")
        {
            DsNhanSu danhsach = new DsNhanSu();
            List<NhanSu> obj = danhsach.getnhansu(id);
            return View(obj.FirstOrDefault());
        }
        // Phuong thuc Delete
        public ActionResult Delete (string id = "")
        {
            DsNhanSu danhsach = new DsNhanSu();
            List<NhanSu> obj = danhsach.getnhansu(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(NhanSu ns)
        {
            DsNhanSu danhsach = new DsNhanSu();
            danhsach.DeleteNhanSu(ns);
            return RedirectToAction("Index");
        }
    }
}