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
        string connectionString = "server=aa124gktif3j980.cjiyeakoxxft.us-east-1.rds.amazonaws.com; port=3306; database=loveyoualattedb; uid=test; pwd=orange1234;";

        [HttpPost]
        public ActionResult AddTime()
        {
            DateTime utcTime = DateTime.UtcNow;
            var easternTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime currentTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, easternTime);

            MySqlDatabase db = new MySqlDatabase(connectionString);
            using (MySqlConnection conn = db.Connection)
            {
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO log_time(log_time) VALUES ('" + currentTime.ToString("yyyy/MM/dd HH:mm:ss") + "')";

                cmd.ExecuteNonQuery();
            }
                


            return RedirectToAction("Index", "Home", new { currentTime = currentTime });
        }
    }
}