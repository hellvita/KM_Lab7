using Newtonsoft.Json.Linq;
using System;

namespace km_api_lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"(♥назва пишеться лiтерами латинського алфавiту♥)" +
                $"\nВведiть назву країни та натиснiть Enter");

            var country = "";
            Console.Write("\t> ");
            country = Console.ReadLine();

            var request = new GetReq($"https://restcountries.com/v3.1/name/{country}");
            request.Run();

            var response = request.Responce;
            if (response != null) {
                Console.WriteLine("\n   ______Результат______\n");
                JArray j_arr = JArray.Parse(response);
                JObject j_obj = j_arr[0].ToObject<JObject>();
                string country_name = j_obj["name"]["official"].ToString();
                string country_capital = j_obj["capital"][0].ToString();
                string country_region = j_obj["region"].ToString();
                Console.WriteLine($"   Країнa: {country_name}");
                Console.WriteLine($"   Столиця: {country_capital}");
                Console.WriteLine($"   Регiон: {country_region}");
                Console.WriteLine("   _____________________\n");
            }
            else { Console.WriteLine("\nВ назвi країни помилка або такої країни не iснує!"); }
            

        }
    }
}
