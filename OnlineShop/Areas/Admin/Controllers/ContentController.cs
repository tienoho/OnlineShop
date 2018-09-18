using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            var dao = new ContentDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                long id = dao.Insert(content);
                content.CreatedDate = DateTime.Now;
                if (id > 0) return RedirectToAction("Index", "Content");
                else ModelState.AddModelError("", "Thêm không thành công");
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var content = new ContentDao().ViewDetail(id);
            SetViewBag(content.CategoryID);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Content content)
        {
            if(ModelState.IsValid)
            {
                var dao = new ContentDao();
                var result = dao.Update(content);
                if (result) return RedirectToAction("Index", "Content");
                else  ModelState.AddModelError("", "Cập nhật khong thành công");
            }
            SetViewBag(content.CategoryID);
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ContentDao().Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListCategoryActive(), "ID", "Name", selectedId);
        }
    }
}