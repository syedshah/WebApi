using System;
using System.Configuration;
using System.Web
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAFRepository.Context;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PAFDb(connectionString: ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString)
            {
                db.Localities local =  from b in db.Localities.Take(10)
                    orderby b.LocalityID descending
                    select b;

                foreach (var item in query)
                {
                    Console.WriteLine(item.PostTown);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
