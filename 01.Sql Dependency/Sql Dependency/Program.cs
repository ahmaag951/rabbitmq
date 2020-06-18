using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Dependency
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
            
            var x = Console.ReadLine();
            if (x.Equals("a"))
            {
                DoDatabaseStuff();
            }
        }

        static void DoDatabaseStuff()
        {
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
        }

        private static void sqlDependency_onChange(object sender, SqlNotificationEventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("yeeeeeeeeeeees");
        }
    }
}
