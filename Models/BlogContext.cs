using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace blog
{
    public class BlogContext : DbContext
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();



            // kvp - key value pair
            // Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            // myDictionary.Add("apple","red");
            // // key is apple 
            // var value = myDictionary["apple"];


            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BloggingContext"));
        }

    }


}