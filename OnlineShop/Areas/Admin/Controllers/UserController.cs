using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using OnlineShop.Common;
using PagedList;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 20)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            var encryptedMd5Pas = Encryptor.MD5Hash(user.Passsword);
            user.Passsword = encryptedMd5Pas;
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
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
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (!string.IsNullOrEmpty(user.Passsword))
            {
                var encryptedMd5Pas = Encryptor.MD5Hash(user.Passsword);
                user.Passsword = encryptedMd5Pas;
            }
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                bool result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}