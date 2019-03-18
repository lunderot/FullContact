using System;
using RestSharp;
using Nito.AsyncEx;
using System.Threading.Tasks;

namespace FullContact
{
    class Program
    {
        private static async Task<int> AsyncMain()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("todos/{id}");
            request.AddUrlSegment("id", "2");


            client.ExecuteAsync(request, r =>
            {
                Console.WriteLine(r.Content);
            });
            var response = await client.ExecuteTaskAsync(request);

            return 0;

        }

        static int Main(string[] args)
        {
            AsyncContext.Run(AsyncMain);
            Console.ReadKey();
            return 0;
        }
    }
}
