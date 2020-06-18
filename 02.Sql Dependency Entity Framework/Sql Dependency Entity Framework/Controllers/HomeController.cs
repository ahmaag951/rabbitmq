using Sql_Dependency_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sql_Dependency_Entity_Framework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // make the Sql Dependency ...
            string connectionString = @"Data Source=.;Initial Catalog=TestSqlDependency;Persist Security Info=True;Integrated Security=SSPI;MultipleActiveResultSets=true;Pooling=False;";

            string commandText = @"SELECT [Id], [Name] FROM [TestSqlDependency].[dbo].[Emp]";

            SqlDependency.Start(connectionString);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    connection.Open();

                    var sqlDependency = new SqlDependency(command);

                    sqlDependency.OnChange += new OnChangeEventHandler(sqlDependency_onChange);

                    // you have to execute the command or it will not fire.
                    //using (SqlDataReader reader = command.ExecuteReader())
                    //{
                    //}
                }
            }

            return View();
        }

        private void sqlDependency_onChange(object sender, SqlNotificationEventArgs e)
        {
            // This method will be called every time a change happens on 'emp' table.
            
        }

        public ActionResult Action1()
        {
            return View();
        }

        public ActionResult Action2()
        {
            return View();
        }

        [HttpPost]
        public int Action1(Emp emp)
        {
            TestSqlDependencyEntities db = new TestSqlDependencyEntities();
            db.Emps.Add(emp);
            return db.SaveChanges();
        }

        [HttpPost]
        public int Action2(Emp emp)
        {
            TestSqlDependencyEntities db = new TestSqlDependencyEntities();
            db.Emps.Add(emp);
            return db.SaveChanges();
        }

        public ActionResult ChangesList()
        {
            TestSqlDependencyEntities db = new TestSqlDependencyEntities();
            var model = db.Emps.ToList();

            //-------------------- This is a workaround and has to be changed From this to be pure EF --------------
            string connectionString = @"Data Source=.;Initial Catalog=TestSqlDependency;Persist Security Info=True;Integrated Security=SSPI;MultipleActiveResultSets=true;Pooling=False;";

            string commandText = @"SELECT [Id], [Name] FROM [TestSqlDependency].[dbo].[Emp]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    connection.Open();

                    // you have to execute the command or it will not fire.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }

            //-------------------
            return View(model);
        }
	}
}