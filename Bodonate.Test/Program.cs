using Bodonate.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodonate.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in BooksRepo.GetAllBooks())
            {
                Console.WriteLine(item.Name);
                Console.WriteLine("---------------------------------------------------------");
            }


            foreach (var item2 in BooksRepo.GetBooksByGenreId(1))
            {
                Console.WriteLine(item2.Name);
            }
            Console.ReadKey();
        }
    }
}
