using System;
using System.Linq;

namespace IssueHasColumnName
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new TableSplittingContext();

            var id = context.DetailedOrders.Select(f => f.Id).FirstOrDefault();
            //sql SELECT TOP(1) [o].[IdFoo] FROM[Orders] AS[o]
            Console.WriteLine(id);

            var name = context.DetailedOrders.Select(f => f.Name).FirstOrDefault();
            //sql SELECT TOP(1) [o].[Name] FROM [Orders] AS [o]
            Console.WriteLine(name);
        }
    }
}
