using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adgtechAssesment.Models;
using adgtechAssesment.DAL;
using System.Data;

namespace adgtechAssesment.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Problem1()
        {
            return View();
        }

        public ActionResult Problem2()
        {
            return View();
        }

        dataaccesslayer dblayer = new dataaccesslayer();

        public JsonResult get_record()
        {
            DataSet ds = dblayer.get_record();
            List<incident_model> listrs = new List<incident_model>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new incident_model
                {
                    Incident_No = dr["Incident_ID"].ToString(),
                    Incident_Desc = dr["Incident_Desc"].ToString(),
                    Incident_Priority = dr["Incident_Priority"].ToString()
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);

        }

        public JsonResult update_record(incident_model inc)
        {
            string res = string.Empty;

            if (dblayer.update_record(inc) == true)
            { res = "updated"; }
            else
            { res = "failed"; }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult delete_record(string id)
        {
            string res = string.Empty;

            if (dblayer.delete_record(id) == true)
            { res = "data deleted"; }
            else
            { res = "failed"; }

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}