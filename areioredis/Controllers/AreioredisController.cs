using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace areioredis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreioredisController : ControllerBase
    {

        [HttpGet]  
        public List<String> Get()
        {
            
            // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            Connection c = new Connection();
            var cache = c.Con.GetDatabase();

            // Perform cache operations using the cache object...

            // Simple PING command
            var lista = new List<String>();
            
            string cacheCommand = "PING";
            lista.Add(cacheCommand);
            Console.WriteLine("\nCache command  : " + cacheCommand);
            lista.Add("\nCache command: " + cacheCommand);
            Console.WriteLine("Cache response : " + cache.Execute(cacheCommand).ToString());
            lista.Add("Cache response : " + cache.Execute(cacheCommand).ToString());
            // Simple get and put of integral data types into the cache
            cacheCommand = "GET Message";
            lista.Add(cacheCommand);
            Console.WriteLine("\nCache command  : " + cacheCommand + " or StringGet()");
            Console.WriteLine("Cache response : " + cache.StringGet("Message").ToString());
            lista.Add("Cache response : " + cache.StringGet("Message").ToString());

            cacheCommand = "SET Message \"Hello! The cache is working from a .NET Core console app!\"";
            lista.Add(cacheCommand);
            Console.WriteLine("\nCache command  : " + cacheCommand + " or StringSet()");
            lista.Add("\nCache command  : " + cacheCommand + " or StringSet()");
            Console.WriteLine("Cache response : " + cache.StringSet("Message", "Hello! The cache is working from a .NET Core console app!").ToString());
            lista.Add("Cache response : " + cache.StringSet("Message", "Hello! The cache is working from a .NET Core console app!").ToString());
            // Demonstrate "SET Message" executed as expected...
            cacheCommand = "GET Message";
            lista.Add(cacheCommand);
            Console.WriteLine("\nCache command  : " + cacheCommand + " or StringGet()");
            lista.Add("\nCache command  : " + cacheCommand + " or StringGet()");
            Console.WriteLine("Cache response : " + cache.StringGet("Message").ToString());
            lista.Add("Cache response : " + cache.StringGet("Message").ToString());
            // Get the client list, useful to see if connection list is growing...
            cacheCommand = "CLIENT LIST";
            lista.Add(cacheCommand);
            Console.WriteLine("\nCache command  : " + cacheCommand);
            lista.Add("\nCache command  : " + cacheCommand);
            Console.WriteLine("Cache response : \n" + cache.Execute("CLIENT", "LIST").ToString().Replace("id=", "id="));
            lista.Add("Cache response : \n" + cache.Execute("CLIENT", "LIST").ToString().Replace("id=", "id="));
            // Store .NET object to cache
            Employee iohana = new Employee("007", "Iohana", 23);
            Console.WriteLine("Cache response from storing Employee .NET object : " +
            cache.StringSet("iow", JsonConvert.SerializeObject(iohana)));
            lista.Add("Cache response from storing Employee .NET object : " +
            cache.StringSet("iow", JsonConvert.SerializeObject(iohana)));


            // Retrieve .NET object from cache
            Employee iohanaDoCache = JsonConvert.DeserializeObject<Employee>(cache.StringGet("iow"));
            Console.WriteLine("Deserialized objeto de employee :\n");
            lista.Add("Deserialized objeto de employee :\n");
            Console.WriteLine("\tNome : " + iohanaDoCache.Name);
            lista.Add("\tNome : " + iohanaDoCache.Name);
            Console.WriteLine("\tId   : " + iohanaDoCache.Id);
            lista.Add("\tId   : " + iohanaDoCache.Id);
            Console.WriteLine("\tIdade  : " + iohanaDoCache.Age + "\n");
            lista.Add("\tIdade  : " + iohanaDoCache.Age + "\n");
            //c.Con.Dispose();
            return lista;
        }

        [HttpGet("{id}")]   
        public int GetId(int id)
        {

            return id;
        }

    }
}
