using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

class Program
{
    public static void Main()
    {
        using IDbConnection connection = new SqlConnection("Data Source=DESKTOP-1B95R4O;Initial Catalog=Magazine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        try
        {
            connection.Open();

            var query = "select * from Customers";
            var emails = "select Email from Customers";
            var category = "select * from Categories";
            var sales = "select * from Sales";
            var city = "select City from Customers";
            var country = "select Country from Customers";


            var result = connection.ExecuteScalar<int>(query);

            Console.WriteLine(result);



            // 
            Console.WriteLine("Enter your city");
            var city_inp = Console.ReadLine();

            Console.WriteLine(connection.ExecuteScalar<int>($"select {city_inp} from Customers"));

            //

            Console.WriteLine("Enter your country");
            var country_inp = Console.ReadLine();

            Console.WriteLine(connection.ExecuteScalar<int>($"select {country_inp} from Customers"));
        }

        catch (Exception ex)
        {
            Console.WriteLine("You could not connect.");
        }
    }
}
