using FullCalender.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data;

namespace FullCalender.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(TaskDetails obj)
        {
            var param = new DynamicParameters();
            param.Add("@Name", obj.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Description", obj.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StartTime", obj.StartTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@EndTime", obj.EndTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            int insertedTaskId = 0;

            using (SqlConnection con = new SqlConnection("Data Source=Vishal;Initial Catalog=test;User ID=sa;Password=vishal@sql"))
            {
                var task = await con.QueryMultipleAsync("AddTask", param, commandType: CommandType.StoredProcedure);
                insertedTaskId = task.Read<int>().SingleOrDefault();
            }

            return Json(insertedTaskId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateTask(TaskDetails obj)
        {
            var param = new DynamicParameters();
            param.Add("@Id", obj.Id, dbType: DbType.Int16, direction: ParameterDirection.Input);
            param.Add("@Name", obj.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@Description", obj.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("@StartTime", obj.StartTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add("@EndTime", obj.EndTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            int code = 0;

            using (SqlConnection con = new SqlConnection("Data Source=Vishal;Initial Catalog=test;User ID=sa;Password=vishal@sql"))
            {
                var task = await con.QueryMultipleAsync("UpdateTask", param, commandType: CommandType.StoredProcedure);
                code = task.Read<int>().SingleOrDefault();
            }

            return Json(code, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetTasks()
        {
            SuccessResult<IEnumerable<TaskDetails>> result = await this.GetAllTasks();
            return Json(result.Item, JsonRequestBehavior.AllowGet);
        }

        private async Task<SuccessResult<IEnumerable<TaskDetails>>> GetAllTasks()
        {
            SuccessResult<IEnumerable<TaskDetails>> result = new SuccessResult<IEnumerable<TaskDetails>>();

            using (SqlConnection con = new SqlConnection("Data Source=Vishal;Initial Catalog=test;User ID=sa;Password=vishal@sql"))
            {
                var task = await con.QueryMultipleAsync("GetAllTask", commandType: CommandType.StoredProcedure);
                try
                {
                    result.Item = task.Read<TaskDetails>().AsEnumerable();
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return result;
        }
    }
}