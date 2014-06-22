using System;
using System.Transactions;

namespace EFTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person { Name = "Nina" };

            using (var context = new TestEntities())
            {
                foreach (var oldItem in context.Persons)
                    context.Persons.Remove(oldItem);

                context.Persons.Add(person);
                context.SaveChanges();

                using (var ts = new TransactionScope())
                {
                    person.Name = "Karina";
                    context.SaveChanges();

                    // Don't set ts.Complete() here.
                }

                Console.WriteLine("1. " + person.Name);

                context.Entry(person).Reload();

                Console.WriteLine("2. " + person.Name);


                using (var ts = new TransactionScope())
                {
                    person.Name = "Karina";
                    context.SaveChanges();

                    ts.Complete();
                }

                Console.WriteLine("3. " + person.Name);

                context.Entry(person).Reload();

                Console.WriteLine("4. " + person.Name);
            }

            // 1. Karina
            // 2. Nina
            // 3. Karina
            // 4. Karina
        } // Main
    }
}
