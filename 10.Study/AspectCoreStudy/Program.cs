using Microsoft.Extensions.Configuration;
using System;

namespace AspectCoreStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsetting.json");
            
        }
    }
}