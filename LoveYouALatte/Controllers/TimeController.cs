using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoveYouALatte;
using LoveYouALatte.Models;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;


namespace LoveYouALatte.Controllers
{
   
    public class TimeController : Controller
    {
        string connectionString = "server=aa1lvp8rxcqhtjt.ccbmorow75ms.us-east-1.rds.amazonaws.com; port=3306; database=loveyoualattedb; uid=test; pwd=test1234;";

        [HttpPost]
        public ActionResult AddTime()
        {
            TimeModel viewModel = new TimeModel();
            DateTime currentTime = DateTime.Now;
            viewModel.CurrentTime = currentTime;

            MySqlDatabase db = new MySqlDatabase(connectionString);
            using (MySqlConnection conn = db.Connection)
            {
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO log_time(log_time) VALUES ('" + currentTime.ToString("yyyy/MM/dd HH:mm:ss") + "')";
                //cmd.Parameters.AddWithValue("@Time", );

                cmd.ExecuteNonQuery();
            }
                


            return RedirectToAction("Index", "Home");
        }
    }
}
//string time = DateTime.Now.ToString("h:mm:ss tt");