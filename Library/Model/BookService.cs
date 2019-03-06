using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Library.Model
{
    public class BookService
    {
        public static void CreateBook(Reader reader)
        {
           
            using (var db = new LiteDatabase(@"Books.db"))
            {
                var col = db.GetCollection<Book>("books");
                Book book = new Book();

                book.author = reader.name;
                book.publishDate = DateTime.Now.Date;
                Console.WriteLine("Введите название книги: ");
                book.name = Console.ReadLine();
                book.code = book.name.Substring(0, (book.name.Length / 2)) + reader.name.Substring(0, (reader.name.Length) / 2);

                col.Insert(book);
 
            }
        }
        public static void PrintInfoAboutBook(Book book)
        {
            Console.WriteLine("Название книги: {0}", book.name);
            Console.WriteLine("Код книги: {0}", book.code);
            Console.WriteLine("Автор книги: {0}", book.author);
            Console.WriteLine("Дата публикации книги: {0}", book.publishDate);
        }
        public static void SearchBook()
        {
            Console.WriteLine("Введите код книги для поиска: ");
            string bookCode = Console.ReadLine();
            using (var db = new LiteDatabase(@"Books.db"))
            {
                var col = db.GetCollection<Book>("books");

                var result = col.FindAll();
                foreach (Book b in result)
                {
                    if (b.code == bookCode)
                    {
                        PrintInfoAboutBook(b);
                    }
                }
            }
        }
    }
}
