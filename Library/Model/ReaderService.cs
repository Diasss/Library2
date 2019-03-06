using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    class ReaderService
    {
        public void ChangePassword(Reader reader)
        {
            Console.WriteLine("Введите новый пароль: ");
            string newPassword = Console.ReadLine();
            reader.password = newPassword;
        }
        public void CreateNewBookReader(Reader reader)
        {
            BookService.CreateBook(reader);
        }
        public void BanThatReader(Reader reader)
        {
            Console.WriteLine("Хотите ли вы заблокировать этого пользователя?(y-да, заблокировать; n- нет, не блокировать): ");
            string chose = Console.ReadLine();
            if (chose == "y")
            {
                reader.bannedUser = true;
            }
            else if (chose == "n")
                reader.bannedUser = false;
        }

    }
}
