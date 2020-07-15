using JsonCitiesDivider.Context;
using JsonCitiesDivider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonCitiesDivider
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawCities;
            const string path = @"D:\WeatherAppWPF\WeatherApp\WeatherApp\city.list.min.json";

            using (StreamReader reader = new StreamReader(path))
            {
                rawCities =  reader.ReadToEnd();
            }

            var cities = JsonConvert.DeserializeObject<IList<CityRaw>>(rawCities);

            using (var context = new AppDbContext())
            {
                var countriesList = new List<string>();

                foreach (var cityRaw in cities)
                {
                    var city = new City()
                    {
                        CityId = cityRaw.Id,
                        CityName = cityRaw.Name
                    };
                    
                    context.Add(city);
                }
                context.SaveChanges();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
