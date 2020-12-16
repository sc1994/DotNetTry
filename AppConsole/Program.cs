using System;
using System.Net.Http;
using static Newtonsoft.Json.JsonConvert;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace AppConsole
{
    public class Program
    {
        async static Task Main(
            string region = null,
            string session = null,
            string package = null,
            string project = null,
            string[] args = null)
        {
            #region Main
            switch (region)
            {
                case "Run":
                    Run();
                    break;
                case "Http":
                    await Http();
                    break;
                case "Json":
                    Json();
                    break;
                case "Linq":
                    Linq();
                    break;
                case "Task":
                    Task();
                    break;
            }
        }
        #endregion

        public static void Run()
        {
            #region Run
            System.Console.WriteLine(DateTime.Now);
            #endregion
        }

        public static async Task Http()
        {
            #region Http
            using var client = new HttpClient();
            var response = await client.GetAsync("https://www.ly.com/");
            System.Console.WriteLine(await response.Content.ReadAsStringAsync());
            #endregion
        }

        public static void Json()
        {
            #region Json
            string json;
            System.Console.WriteLine(json = SerializeObject(new { Example = "this is a example" }));
            System.Console.WriteLine(DeserializeObject<JObject>(json)["Example"]);
            #endregion
        }

        public static void Linq()
        {
            #region Linq
            foreach (var item in new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }.Where(x => x % 3 == 0))
            {
                System.Console.WriteLine(item);
            }
            #endregion
        }

        public static void Task()
        {
            #region Task
            Parallel.Invoke(() =>
            {
                System.Console.WriteLine(DateTime.Now);
                Thread.Sleep(3000);
            }, () =>
            {
                System.Console.WriteLine(DateTime.Now);
            });
            #endregion
        }
    }
}
