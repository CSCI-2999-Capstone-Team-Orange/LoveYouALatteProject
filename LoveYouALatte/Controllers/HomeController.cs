using LoveYouALatte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoveYouALatte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string currentTime = "")
        {
            TimeModel vm = new TimeModel();
            vm.CurrentTime = currentTime;

            //Display the last time the button was clicked
            string connectionString = "server=aau5bw81zij6sr.ccbmorow75ms.us-east-1.rds.amazonaws.com; port=3306; database=loveyoualattedb; uid=test; pwd=test1234;";
            MySqlDatabase db = new MySqlDatabase(connectionString);
            using (MySqlConnection conn = db.Connection)
            {
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT log_time FROM loveyoualattedb.log_time ORDER BY log_time_id DESC LIMIT 1";

                vm.CurrentTime = cmd.ExecuteScalar().ToString();
            }

            return View(vm);
        }
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
