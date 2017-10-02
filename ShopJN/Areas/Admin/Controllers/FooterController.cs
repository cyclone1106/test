using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopJN.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        // GET: Admin/Footer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var footer = new FooterDao().ViewDetail(id);
            return View(footer);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Footer footer)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDao();

                var result = dao.Update(footer);
                
            }
            return View("Index");
        }
    }
}