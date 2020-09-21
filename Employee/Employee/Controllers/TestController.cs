using Employee.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        database_access_layer.db dblayer = new database_access_layer.db();

        // View for Add record
        public ActionResult Index()
        {
            return View();
        }

        // View for Display record
        public ActionResult Show_data()
        {
            return View();
        }

        // View for Update record
        public ActionResult update_data(int id)
        {
            return View();
        }
        //Add record
        public JsonResult Add_record(register rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_record(rs);
                res = "Inserted";
            }
           catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }



        // Display all records
        public JsonResult Get_data()
        {
            DataSet ds = dblayer.get_record();
            List<register> listrs = new List<register>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new register
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),
                    Name = dr["Name"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString()
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }



        // Display records by id
        public JsonResult Get_databyid(int id)
        {
            DataSet ds = dblayer.get_recordbyid(id);
            List<register> listrs = new List<register>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new register
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),
                    Name = dr["Name"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString()
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }



        // Update records
        public JsonResult update_record(register rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.update_record(rs);
                res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }



        // Delete record
        public JsonResult delete_record(int id)
        {
            string res = string.Empty;
            try
            {
                dblayer.deletedata(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}