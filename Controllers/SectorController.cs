using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elevatescape.Models;
using static System.Collections.Specialized.BitVector32;

namespace Elevatescape.Controllers
{
    public class SectorController : Controller
    {
        // GET: Sector
        public JsonResult GetSectors()
        {
            // Fetch sectors from your database or service
            List<sector> sectors = GetSectorsFromDatabase();

            //var products = HandleSectorClick();

            
            // Return the sectors as JSON
            return Json(sectors.Select(s => new { s.ID, s.Name }).ToList(), JsonRequestBehavior.AllowGet);
        }

        // Sample method to simulate fetching sectors
        private List<sector> GetSectorsFromDatabase()
        {
            //    return new List<sector>
            //{
            //    new sector { ID = 1, Name = "Finance" },
            //    new sector { ID = 2, Name = "Technology" },
            //    new sector { ID = 3, Name = "Healthcare" },
            //    new sector { ID = 4, Name = "Education" }
            //};

            List<sector> sectors = new List<sector>();

            // Define your connection string (or use Web.config connection string)
            string con = ConfigurationManager.ConnectionStrings["elevate"].ConnectionString;

            // Define the query to fetch sectors
            string query = "SELECT ID, Name FROM sectormaster"; // Assuming you have an 'Id' and 'Name' column in the 'Sectors' table

            // Use ADO.NET to connect and fetch data
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sectors.Add(new sector
                        {
                            ID = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }

            return sectors;
        }

        //public JsonResult HandleSectorClick()
        //{
        //    string loginid = HttpContext.Session["email"].ToString();
        //    if (string.IsNullOrEmpty(loginid))
        //    {
        //        return Json(new { success = false, Message = "login id is not found" }, JsonRequestBehavior.AllowGet);
        //    }

        //    DataTable dt = new DataTable();

        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["elevate"].ToString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM institutemaster WHERE code = (SELECT institutecode FROM tbl_loginsignup WHERE code = @loginId)", con);
        //        cmd.Parameters.AddWithValue("@loginId", loginid);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        con.Open();
        //        da.Fill(dt);
        //    }
        //    if (dt.Rows.Count > 0)
        //    {
        //        Session["sectorcode"] = dt.Rows[0]["sectorcode"].ToString();
        //        Session["menuid"] = dt.Rows[0]["menuid"].ToString();
        //        Session["InstCode"] = dt.Rows[0]["code"].ToString();
        //    }

        //    DataTable dt1 = new DataTable();
        //    using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["elevate"].ToString()))
        //    {
        //        SqlCommand cmd1 = new SqlCommand("Pr_CodeMaster_SelectforSearch_full_time_new", con2);
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.Parameters.AddWithValue("@sectorcode", Session["sectorcode"]);

        //        SqlDataAdapter adt1 = new SqlDataAdapter(cmd1);
        //        con2.Open();
        //        adt1.Fill(dt1);
        //    }

        //    var sectorList = dt1.AsEnumerable().Select(row => new
        //    {
        //        SectorCode = row["SectorCode"].ToString(),
        //        SectorName = row["SectorName"].ToString(),
        //        // Add more fields as required
        //    }).ToList();
        //    return Json(new { success = true, data = sectorList }, JsonRequestBehavior.AllowGet);
        //}

        

    }

   
}