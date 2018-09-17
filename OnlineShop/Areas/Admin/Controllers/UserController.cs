using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        //Phân trang bằng PagedList
        public ActionResult Index(string searchString,int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }
        //phân trang bằng jquyery
        //public ActionResult Index()
        //{
        //    var dao = new UserDao();
        //    var model = dao.ListAll();
        //    return View(model);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                //nhập chuyển password sang mã hóa md5
                var encryptedMd5Pass = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pass;
                user.CreatedDate = DateTime.Now;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //nhập chuyển password sang mã hóa md5
                if(!string.IsNullOrEmpty(user.Password))
                {
                    var encrytedMd5Pass = Encryptor.MD5Hash(user.Password);
                    user.Password = encrytedMd5Pass;
                }
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập user không thành công");
                }
            }
            return View(user);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}