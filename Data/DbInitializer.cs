using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            LibraryDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<LibraryDbContext>();

            UserManager<IdentityUser> userManager = applicationBuilder.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            // Add Lender
            var user = new IdentityUser("Marius Tudor");
            await userManager.CreateAsync(user, "%Miro1");

            // Add Customers
            var Popescu = new Customer { Name = "Popescu George" };

            var Constantin = new Customer { Name = "Constantin Mihai" };

            var Marius = new Customer { Name = "Marius Tudor" };

            context.Customers.Add(Popescu);
            context.Customers.Add(Constantin);
            context.Customers.Add(Marius);

            // Add Author
            var authorDostoievski = new Author
            {
                Name = "Feodor Dostoievski",
                Books = new List<Book>()
                {
                    new Book { Title = "Crima si Pedeapsa" },
                    new Book { Title = "Fratii Karamazov" },
                    new Book { Title = "Dublura" },
                }
            };

            var authorMartin = new Author
            {
                Name = "George R. R. Martin",
                Books = new List<Book>()
                {
                    new Book { Title = "Urzeala tronurilor"},
                    new Book { Title = "Inclestarea regilor"},
                    new Book { Title = "Iuresul Sabiilor"},
                    new Book { Title = "Festinul Ciorilor"},
                    new Book { Title = "Festinul Dragonilor"},
                }
            };

            var authorEminescu = new Author
            {
                Name = "Mihai Eminescu",
                Books = new List<Book>()
                {
                    new Book { Title = "Luceafarul"},
                    new Book { Title = "Poesii"},
                    new Book { Title = "Lacul"},
                    new Book { Title = "Floare Albastra"},
                    new Book { Title = "Geniu Pustiu"},
                }
            };

            context.Authors.Add(authorDostoievski);
            context.Authors.Add(authorMartin);
            context.Authors.Add(authorEminescu);

            context.SaveChanges();
        }
    }
}
