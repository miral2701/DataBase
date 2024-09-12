using Microsoft.Data.SqlClient;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string connetionString2 = "Server=192.168.68.105,875\\DESKTOP-A9BTA2K\\SQLEXPRESS;Database=Academy;User Id=dbadmin;Password=qwerty1234";
            //string connectionString = "Server=HomePc;Database=master;Trusted_Connection=true";
            CreateDataBase();
            //CreateTable();

        }
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }
        public static void CreateTable()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand("CREATE TABLE [Users]([Id] INT PRIMARY KEY IDENTITY,[Name] NVARCHAR(60) NOT NULL", connection);
                command.ExecuteNonQuery();
            }
        }

        public static void CreateDataBase()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand("CREATE DATABASE [FirstDb]", connection);
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateTable()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand("UPDATE [Users] SET [Name]=Mira", connection);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteFromTable(User user)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"DELETE FROM [Users] WHERE [Id]={user.Id}", connection);
                command.ExecuteNonQuery();
            }
        }

        public static void ReadFromTable()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected");
                SqlCommand command = new SqlCommand($"SELECT [Id],[Name],[Age] FROM [Users]", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //string columnName1 = reader.GetName(0);
                    //string columnName2 = reader.GetName(1);

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);

                    }
                }
                reader.Close();
            }


          
            }
        }
    }
}