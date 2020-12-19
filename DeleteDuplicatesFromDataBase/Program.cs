using System;
using System.Data.SqlClient;

namespace DeleteDuplicatesFromDataBase
{
    public class Program
    {
       
        public void DeleteDuplicates()
        {
            string connectionString = "Data Source = (LocalDb)\\VenkeyServer;Initial Catalog =AddressBookSystem; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                using (connection)
                {

                    string query = @"
                                     with EmployeeCTE as
                                            (
                                  select * , Row_Number() over(Partition by id order by id) as RowNumber from Employees 
                                               )
                                    Delete from EmployeeCTE where RowNumber>1; ";
                    SqlCommand cnd = new SqlCommand(query, connection);
                    connection.Open();


                    var result = cnd.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {

                        Console.WriteLine("Deleted Duplicates Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Duplcates found");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();

            }
        }


        public static void Main()
        {
            Program obj = new Program();
            obj.DeleteDuplicates();
        }
    }
}