using HiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiWeb.DataContext
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RepositoryContext())
            //serviceProvider.GetRequiredService<DbContextOptions<<RepositoryContext>>()))
            {
                if (context.Students.Any())
                    return;   // DB has been seeded

                var list = new List<Student>()
                {
                    new Student() { Firstname = "Tope", Lastname = "Adara", Email = "tope.adara@yahoo.com" },
                    new Student() { Firstname = "Seun", Lastname = "Opanuga", Email = "seun.opanuga@yahoo.com" }
                };

                list.ForEach(c => context.Students.Add(c));
                context.SaveChanges();
            }
        }
    }
}