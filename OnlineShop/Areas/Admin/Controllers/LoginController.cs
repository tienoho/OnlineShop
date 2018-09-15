using Common;
using Model.Dao;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            //Kiểm tra xem form có rỗng hay không
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    //lấy ra id của userName
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserID = user.ID;
                    //gắn user vào Session
                    Session.Add(Common.CommonConstants.USER_SESSION, userSession);
                    //thành công thì trả về trang index home
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                else if (result == -1)
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                else if (result == -2)
                    ModelState.AddModelError("", "Mật khẩu không đúng!");
                else
                    ModelState.AddModelError("", "Đăng nhập không thành công!");
            }
            return View("Index");
        }
    }
}