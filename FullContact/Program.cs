using System;
using Nito.AsyncEx;
using FullContactApi;

namespace FullContact
{
    class Program
    {
        static int Main(string[] args)
        {
            API fc = new API(Environment.GetEnvironmentVariable("API_KEY"));
            do
            {
                Console.Write("Please enter an email (or enter nothing to quit): ");
                var email = Console.ReadLine();
                if(email == "")
                {
                    break;
                }
                var person = AsyncContext.Run<FullContactPerson>(async () => await fc.LookupPersonByEmailAsync(email));

                if (person == null)
                {
                    Console.WriteLine("Invalid email");
                    continue;
                }
                if (person.contactInfo == null)
                {
                    Console.WriteLine("Could not find contact data");
                    continue;
                }

                Console.WriteLine("Full name: " + person.contactInfo.fullName);
                Console.WriteLine("Likelihood: " + person.likelihood);

                if (person.contactInfo.websites != null)
                {
                    Console.WriteLine("Websites: ");
                    foreach (var website in person.contactInfo.websites)
                    {
                        Console.WriteLine("\t" + website.url);
                    }
                }

                if (person.socialProfiles != null)
                {
                    Console.WriteLine("Social media: ");
                    foreach (var profile in person.socialProfiles)
                    {
                        Console.WriteLine("\t" + profile.typeName + ": " + profile.url);
                    }
                }
                Console.WriteLine();
            }
            while (true);
            return 0;
        }
    }
}
