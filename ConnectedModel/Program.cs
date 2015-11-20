using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectedModel
{
    class Program
    {
        static void Insert()
        {
            //insertion
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Shuja\DotNetSamples\F10\Ado.Net\ConnectedModel\ConnectedModel\MyDB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter User Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            string query = "insert into Users (userName, password) values('" + userName + "','" + password + "')";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            int NumberOfInsertedRows = cmd.ExecuteNonQuery();

            connection.Close();
            
        }

        static void InsertWithParameters()
        {
            //insertion
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Shuja\DotNetSamples\F10\Ado.Net\ConnectedModel\ConnectedModel\MyDB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter User Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            string query = "insert into Users (userName, password) values(@UserName, @Password);";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlParameter p1 = new SqlParameter("UserName", userName);
            SqlParameter p2 = new SqlParameter("Password", password);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            int NumberOfInsertedRows = cmd.ExecuteNonQuery();
            Console.WriteLine("No of Users Inserted ="+NumberOfInsertedRows);
            connection.Close();

        }

        static void Read()
        {
            //reading
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Shuja\DotNetSamples\F10\Ado.Net\ConnectedModel\ConnectedModel\MyDB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
           
            Console.WriteLine("Reading from DB");

            Console.WriteLine("Enter User Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            //sql injection example query
            //
            //password = 1' or 1=1--
 string query = "select * from users where username = '" 
     + userName + "' and password ='" + password + "'";

            
            Console.WriteLine("query =" + query);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Authenticated");
            }
            else
            {
                Console.WriteLine("Invalid UserName/Password");
            }
           
        }

        static void DeleteWithParameters()
        {
            //insertion
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Shuja\DotNetSamples\F10\Ado.Net\ConnectedModel\ConnectedModel\MyDB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter User Name");
            string userName = Console.ReadLine();
           

            string query = "delete from   Users  where userName= @userName";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlParameter p1 = new SqlParameter("UserName", userName);
           
            cmd.Parameters.Add(p1);
           
            int NumberOfEffectedRows = cmd.ExecuteNonQuery();
            Console.WriteLine("No of Users Deleted =" + NumberOfEffectedRows);
            connection.Close();

        }
        static void UpdateWithParameters()
        {
            //insertion
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Shuja\DotNetSamples\F10\Ado.Net\ConnectedModel\ConnectedModel\MyDB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter User Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            string query = "update  Users set  password= @Password where userName= @UserName";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlParameter p1 = new SqlParameter("UserName", userName);
            SqlParameter p2 = new SqlParameter("Password", password);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            int NumberOfEffectedRows = cmd.ExecuteNonQuery();
            Console.WriteLine("No of Users Updates =" + NumberOfEffectedRows);
            connection.Close();

        }
        static void ReadwithParamters()
        {
            //reading
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Shuja\DotNetSamples\F10\Ado.Net\ConnectedModel\ConnectedModel\MyDB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            Console.WriteLine("Reading from DB using SQL Parameter to prevent SQL Injection");

            Console.WriteLine("Enter User Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

           
            //Preventing Injection
            //using Parameters
  string query = "select * from users where username = @UserName and password = @Password";
            SqlParameter p1 = new SqlParameter("UserName", userName);
            SqlParameter p2 = new SqlParameter("Password", password);

            Console.WriteLine("query =" + query);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Authenticated");
            }
            else
            {
                Console.WriteLine("Invalid UserName/Password");
            }

        }

        static void SingleObjectExample()
        {
            //reading
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Shuja\DotNetSamples\F10\Ado.Net\ConnectedModel\ConnectedModel\MyDB.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);




            string query = "select Count(*) cnt from users";
            
           
            SqlCommand cmd = new SqlCommand(query, connection);
          
            connection.Open();
            object value = cmd.ExecuteScalar();

            Console.WriteLine("Count of Users  = "+ value);


        }
        static void Main(string[] args)
        {
            //Read();
            ReadwithParamters();
            //InsertWithParameters();
            //UpdateWithParameters();
            //DeleteWithParameters();
           // SingleObjectExample();
            
        }
    }
}
