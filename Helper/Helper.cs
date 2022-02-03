using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    internal class Helper
    {
        static void Main(string[] args)
        {

            Model MyModel = new Model();

            foreach (var author in MyModel.GetAllAuthors())
                Console.WriteLine($"Author:{author.Person.LastName}");

            Console.WriteLine();

            foreach (var genre in MyModel.GetAllGenre())
                Console.WriteLine($"genre:{genre.Name}");

            Console.WriteLine();

            foreach (var group in MyModel.GetAllGroups())
                Console.WriteLine($"group:{group.Name}");

            Console.WriteLine();

            foreach (var popular in MyModel.GetAllPopular())
                Console.WriteLine($"Popular:{popular.MusicRecord.Author.Group.Name}");

            Console.WriteLine();


            foreach (var record in MyModel.GetAllRecordsByGroupName("Bbno$"))
                Console.WriteLine($"Bbno$ Records:{record.Name}");
            Console.WriteLine();
            foreach (var record in MyModel.GetAvailableForPurchase())
                Console.WriteLine($"Available For Purchase:{record.Name}:{record.Cost}");
            Console.WriteLine();

            // add bonuse
            foreach (var bonuse in MyModel.GetAllBonuses())
                Console.WriteLine($"User before add bonuses:ID:{bonuse.Id}:bonuses{bonuse.Count}");

            Console.WriteLine();

            MyModel.InsertBonuses(10, 1);

            foreach (var bonuse in MyModel.GetAllBonuses())
                Console.WriteLine($"User after add bonuses:ID:{bonuse.UserId}:bonuses{bonuse.Count}");

            Console.WriteLine();


            var list = MyModel.GetAvailableForPurchase().ToList().FirstOrDefault();

            MyModel.BuyRecord(list.Cost, list.Id, 1, 300);
            foreach (var sale in MyModel.GetAllSales())
                Console.WriteLine($"sales:ID:{sale.UserId}:bonuses:{sale.Bonuses}cost{sale.Cost}:total:{sale.TotalCost}");

        }
    }
}
