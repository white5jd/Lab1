using System.Data.SqlClient;

namespace Lab1Final.Pages.DB
{
    public class DBClass
    {
    

        public static SqlConnection LabDBConnection = new SqlConnection();

        // Connection String - How to find and connect to DB
        private static readonly String? LabDBConnString =
            "Server=Localhost;Database=LAB;Trusted_Connection=True";

        // Show the Users
        public static SqlDataReader SysUserReader()
        {
            SqlCommand cmdSysUserRead = new SqlCommand();
            cmdSysUserRead.Connection = LabDBConnection;
            cmdSysUserRead.Connection.ConnectionString = LabDBConnString;
            cmdSysUserRead.CommandText = "SELECT * FROM SysUser";
            cmdSysUserRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdSysUserRead.ExecuteReader();

            return tempReader;
        }
        // Show the Grants
        public static SqlDataReader GrantsReader()
        {
            SqlCommand cmdGrantsRead = new SqlCommand();
            cmdGrantsRead.Connection = LabDBConnection;
            cmdGrantsRead.Connection.ConnectionString = LabDBConnString;
            cmdGrantsRead.CommandText = "SELECT * FROM GrantTable";
            cmdGrantsRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdGrantsRead.ExecuteReader();

            return tempReader;
        }
        // Show the Projects
        public static SqlDataReader ProjectsReader()
        {
            SqlCommand cmdProjectsRead = new SqlCommand();
            cmdProjectsRead.Connection = LabDBConnection;
            cmdProjectsRead.Connection.ConnectionString = LabDBConnString;
            cmdProjectsRead.CommandText = "SELECT * FROM Project";
            cmdProjectsRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdProjectsRead.ExecuteReader();

            return tempReader;
        }
        // Insert into user table
        public static void InsertSysUser(string firstName, string lastName, string email, string phoneNumber, string role)
        {
            SqlCommand cmdInsertSysUser = new SqlCommand();
            cmdInsertSysUser.Connection = LabDBConnection;
            cmdInsertSysUser.Connection.ConnectionString = LabDBConnString;

            String sqlQuery = "INSERT INTO SysUser (firstName, lastName, email, phoneNumber, role) " +
                                          "VALUES (@firstName, @lastName, @email, @phoneNumber, @role)";

            cmdInsertSysUser.Parameters.AddWithValue("@firstName", firstName);
            cmdInsertSysUser.Parameters.AddWithValue("@lastName", lastName);
            cmdInsertSysUser.Parameters.AddWithValue("@email", email);
            cmdInsertSysUser.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmdInsertSysUser.Parameters.AddWithValue("role", role);

            cmdInsertSysUser.Connection = LabDBConnection;
            cmdInsertSysUser.Connection.ConnectionString = LabDBConnString;
            cmdInsertSysUser.CommandText = sqlQuery;
            cmdInsertSysUser.Connection.Open();

            cmdInsertSysUser.ExecuteNonQuery();
        }
        // Insert into Grants --
        public static void InsertGrantTable(string grantName, string submissionDate, string awardDate, decimal awardAmount, string grantStatus, string grantCategory)
        {
            SqlCommand cmdGrantTable = new SqlCommand();
            cmdGrantTable.Connection = LabDBConnection;
            cmdGrantTable.Connection.ConnectionString = LabDBConnString;

            String sqlQuery = "INSERT INTO GrantTable (grantName, submissionDate, awardDate, awardAmount, grantStatus, grantCategory) " +
                                          "VALUES (@grantName, @submissionDate, @awardDate, @awardAmount, @grantStatus, @grantCategory)";

            cmdGrantTable.Parameters.AddWithValue("@grantName", grantName);
            cmdGrantTable.Parameters.AddWithValue("@submissionDate", submissionDate);
            cmdGrantTable.Parameters.AddWithValue("@awardDate", awardDate);
            cmdGrantTable.Parameters.AddWithValue("@awardAmount", awardAmount);
            cmdGrantTable.Parameters.AddWithValue("@grantStatus", grantStatus);
            cmdGrantTable.Parameters.AddWithValue("@grantCategory", grantCategory);

            cmdGrantTable.Connection = LabDBConnection;
            cmdGrantTable.Connection.ConnectionString = LabDBConnString;
            cmdGrantTable.CommandText = sqlQuery;
            cmdGrantTable.Connection.Open();

            cmdGrantTable.ExecuteNonQuery();
        }
        // Insert into Project  -- EDIT
        public static bool InsertProject(string projectName, string projectDueDate)
        {
            SqlCommand cmdInsertProject = new SqlCommand();
            cmdInsertProject.Connection = LabDBConnection;
            cmdInsertProject.Connection.ConnectionString = LabDBConnString;

            cmdInsertProject.CommandText = "INSERT INTO Project (projectName, projectDueDate) " +
                                          "VALUES (@projectName, @projectDueDate)";

      
            cmdInsertProject.Parameters.AddWithValue("@projectName", projectName);
            cmdInsertProject.Parameters.AddWithValue("@projectDueDate", projectDueDate);
            

            try
            {
                cmdInsertProject.Connection.Open();
                cmdInsertProject.ExecuteNonQuery();
                return true; // Insert successful
            }
            catch (Exception ex)
            {
               
                return false; // Insert failed
            }
            finally
            {
                cmdInsertProject.Connection.Close();
            }
        }

        
        }
    }
