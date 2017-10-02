using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopJN.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new MenuDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public ActionResult Edit(int id)
        {
            SetViewBag();
            var menu = new MenuDao().ViewDetail(id);
            return View(menu);
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new MenuTypeDao();
            ViewBag.TypeID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        [HttpPost]
        public ActionResult Create(Menu menu)
        {
                if (ModelState.IsValid)
                { 
                    var dao = new MenuDao();
                    long id = dao.Insert(menu);
                    if(id>0)
                {
                    SetAlert("Thêm menu thành công", "success");
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm menu không thành công");
                }
            }
             return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                
                var result = dao.Update(menu);
                if (result)
                {
                    SetAlert("Sửa menu thành công", "success");
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật menu không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        
        public ActionResult Delete(int id)
        {
            new MenuDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new MenuDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}