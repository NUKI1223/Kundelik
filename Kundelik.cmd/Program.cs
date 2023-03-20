using Kundelik.BL.Controller;
using Kundelik.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.cmd
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine("Добро пожаловать!");

            Console.Write("Введите пост: ");
            var post = Console.ReadLine();


            if (post.ToLower() == "admin")
            {
                var admin = new Admin();
                var adminController = new UserController(admin);
            }
            else
            {


                Console.Write("Введите имя пользователя: ");
                string name = Console.ReadLine();
                var userController = new UserController(name, post);
                if (post.ToLower() == "студент")
                {

                    if (userController.IsNewUser)
                    {


                    }
                    else
                    {
                        Console.WriteLine("Студент существует");
                        Console.WriteLine("Хотите посмотреть свои оценки?(да, нет)");
                        if (Console.ReadLine().ToLower()=="да")
                        {
                            userController.StudentViewer();
                        }
                    }
                } 
                if (post.ToLower() == "учитель")
                {

                    if (userController.IsNewUser)
                    {

                    }
                    else
                    {
                        Console.WriteLine("Учитель существует");

                    }


                    Console.Write("Хотите изменить оценку студенту? ");
                    if (Console.ReadLine().ToLower() == "да")
                    {
                        userController.SetGrades();
                    }

                }

            }
            
        }

        
    }
}
