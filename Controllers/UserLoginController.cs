using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elevatescape.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Elevatescape.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginClass lc)
        {
            string con = ConfigurationManager.ConnectionStrings["elevate"].ConnectionString;
            SqlConnection conn = new SqlConnection(con);
            string query = "Select Email,password from usermaster where email=@email and password=@password";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email",lc.Email);
            cmd.Parameters.AddWithValue("@password", lc.Password);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["Email"] = lc.Email.ToString();
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewData["Message"] = "User Login Details Failed !";
            }
            conn.Close();
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}