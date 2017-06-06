using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyMCE.Models;

namespace TinyMCE.Controllers
{
    public class TinyMCE_DemoController : Controller
    {
        //
        // GET: /TinyMCE_Demo/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TinyDemoModel model)
        {
            //var htmlDoc = new HtmlDocument();
            //var tempModel = model.Template;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["temp"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spInserttemplate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Template", model.Template);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View();
        }

        public ActionResult Display()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["temp"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spGettemplate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            TinyDemoModel model;
            List<TinyDemoModel> lst = new List<TinyDemoModel>();
            while (dr.Read())
            {
                model = new TinyDemoModel();
                model.Id=Convert.ToInt32(dr["Id"]);
                model.Template = Convert.ToString(dr["Body"]);
                lst.Add(model);

            }
            con.Close();
            return View(lst);
        }

        public ActionResult Edit(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["temp"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spEdittemplate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            TinyDemoModel model = new TinyDemoModel();
            if (dr.Read())
            {
                model.Template = Convert.ToString(dr["Body"]);

            }
            con.Close();
            return View(model);
        }
    }
}