using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace areioredis
{
    public class Program
    {
        //public static IConfigurationRoot Configuration { get; set; } //add
        //const string SecretName = "CacheConnection"; //add
        //private static void InitializeConfiguration()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .AddUserSecrets<Program>();

        //    Configuration = builder.Build();
        //}

        //private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        //{
        //    string cacheConnection = Configuration[SecretName];
        //    return ConnectionMultiplexer.Connect(cacheConnection);
        //});

        //public static ConnectionMultiplexer Connection
        //{
        //    get
        //    {
        //        return lazyConnection.Value;
        //    }
        //}

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //Connection c = new Connection();
            //c.InitializeConfiguration();

            // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            //IDatabase cache = lazyConnection.Value.GetDatabase();

            //// Perform cache operations using the cache object...

            //// Simple PING command
            //string cacheCommand = "PING";
            //Console.WriteLine("\nCache command  : " + cacheCommand);
            //Console.WriteLine("Cache response : " + cache.Execute(cacheCommand).ToString());

            //// Simple get and put of integral data types into the cache
            //cacheCommand = "GET Message";
            //Console.WriteLine("\nCache command  : " + cacheCommand + " or StringGet()");
            //Console.WriteLine("Cache response : " + cache.StringGet("Message").ToString());

            //cacheCommand = "SET Message \"Hello! The cache is working from a .NET Core console app!\"";
            //Console.WriteLine("\nCache command  : " + cacheCommand + " or StringSet()");
            //Console.WriteLine("Cache response : " + cache.StringSet("Message", "Hello! The cache is working from a .NET Core console app!").ToString());

            //// Demonstrate "SET Message" executed as expected...
            //cacheCommand = "GET Message";
            //Console.WriteLine("\nCache command  : " + cacheCommand + " or StringGet()");
            //Console.WriteLine("Cache response : " + cache.StringGet("Message").ToString());

            //// Get the client list, useful to see if connection list is growing...
            //cacheCommand = "CLIENT LIST";
            //Console.WriteLine("\nCache command  : " + cacheCommand);
            //Console.WriteLine("Cache response : \n" + cache.Execute("CLIENT", "LIST").ToString().Replace("id=", "id="));
            //// Store .NET object to cache
            //Employee e007 = new Employee("007", "Davide Columbo", 100);
            //Console.WriteLine("Cache response from storing Employee .NET object : " +
            //cache.StringSet("e007", JsonConvert.SerializeObject(e007)));

            //// Retrieve .NET object from cache
            //Employee e007FromCache = JsonConvert.DeserializeObject<Employee>(cache.StringGet("e007"));
            //Console.WriteLine("Deserialized Employee .NET object :\n");
            //Console.WriteLine("\tEmployee.Name : " + e007FromCache.Name);
            //Console.WriteLine("\tEmployee.Id   : " + e007FromCache.Id);
            //Console.WriteLine("\tEmployee.Age  : " + e007FromCache.Age + "\n");

           // lazyConnection.Value.Dispose();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
    }
}
