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
            Console.WriteLine(id);
            var name = context.DetailedOrders.Select(f => f.Name).FirstOrDefault();
            Console.WriteLine(name);
        }
    }
}
