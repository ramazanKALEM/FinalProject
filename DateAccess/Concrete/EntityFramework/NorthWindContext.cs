using Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Concrete.EntityFramework
{   
    // Context  : Db tablolari ile proje claslarini  baglamak
    public class NorthWindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NorthWind;Trusted_Connection=True");
            
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=NorthWind;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Bağlantı başarılı.");
                }
                else
                {
                    Console.WriteLine("Bağlantı başarısız.");
                }
            }


        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
