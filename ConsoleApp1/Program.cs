// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace dbcon
{
    class program
    {
        static void Main(string[] args)
        { 
            
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;initial catalog=master;integrated security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"))
            {

                conn.Open();
                SqlCommand command = new SqlCommand("select * from student", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("id\tname\t\tmarks\t\tfees\t");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}\t  {1}\t\t{2}\t\t{3}",
                            reader[0], reader[1], reader[2], reader[3]));
                    }
                }
                Console.WriteLine("student database displayed! Now press enter to move to the next section!");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("INSERT INTO command");
               SqlCommand insertCommand = new SqlCommand("INSERT INTO student (id, name, marks, fees) VALUES (@0, @1, @2, @3)", conn);
                
                insertCommand.Parameters.Add(new SqlParameter("0", 111));
                insertCommand.Parameters.Add(new SqlParameter("1", "k"));
                insertCommand.Parameters.Add(new SqlParameter("2", 60));
                insertCommand.Parameters.Add(new SqlParameter("3", 50000));

                //SqlCommand deleteCommand = new SqlCommand("DELETE FROM student where id=104", conn);
                


                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                //Console.WriteLine("Commands executed! Total rows affected are " + deleteCommand.ExecuteNonQuery());
                Console.ReadLine();
                Console.Clear();





            }
        }
    }
}

