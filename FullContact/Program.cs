using System;
using Nito.AsyncEx;
using System.Threading.Tasks;
using FullContactApi;


namespace FullContact
{
    class Program
    {
        private static async Task<int> AsyncMain()
        {
            API fc = new API(Environment.GetEnvironmentVariable("API_KEY"));
            FullContactPerson person = await fc.LookupPersonByEmailAsync("bill.gates@microsoft.com");

            Console.WriteLine(person.contactInfo.fullName);
            Console.WriteLine(person.likelihood);
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
