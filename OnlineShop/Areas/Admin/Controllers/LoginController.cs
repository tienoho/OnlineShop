using Common;
using Model.Dao;
using OnlineShop.Areas.Admin.Models;
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
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    //lấy ra id của userName
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserID = user.ID;
                    //gắn user vào Session
                    Session.Add(Common.CommonConstants.USER_SESSION,userSession);
                    //thành công thì trả về trang index home
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công!");
                }
            }
            return View("Index");
            
        }
    }
}