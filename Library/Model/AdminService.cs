using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class AdminService
    {
        public void CreateReader()
        {
            using (var db = new LiteDatabase(@"Readers"))
            {
                var col = db.GetCollection<Reader>("reader");
                string login = Console.ReadLine();
                string password = Console.ReadLine();
                string name = Console.ReadLine();
                string address = Console.ReadLine();
                string email = Console.ReadLine();
                string telephoneNumber = Console.ReadLine();

                Reader reader = new Reader(login, password, name, address, email, telephoneNumber);

                col.Insert(reader);
            }
        }
        public void ChangePasswordToReader()
        {
            Console.WriteLine("Введите логин пользователя, чтобы поменять пароль: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль пользователя, чтобы поменять пароль");
            string password = Console.ReadLine();
            using (var db = new LiteDatabase(@"Readers"))
            {
                var col = db.GetCollection<Reader>("reader");
                var result = col.FindAll();
                foreach (Reader r in result)
                {
                    if (r.password == password && r.login == login)
                    {
                        Console.WriteLine("Введите новый пароль пользователя");
                        string newPassword = Console.ReadLine();
                        r.password = newPassword;
                        col.Update(r);
                    }
                }
            }
        }


    }
}
