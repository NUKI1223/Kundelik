using Kundelik.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Model
{
    [Serializable]
    public class Teacher : User
    {
        
        public UserController userController =  new UserController();
        public Teacher(string name, string post) 
        {
            
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым ", nameof(name));
            }
            
            
        }

        public Teacher(string name, string gender, DateTime birthDate, string post) 
        {

            #region Проверка условий

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым ", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым ", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозмождная дата рождения", nameof(birthDate));

            }
            if (post == null)
            {
                throw new ArgumentNullException("Пост не может быть пустым ", nameof(post));
            }
            #endregion
            var teach = new Posts(post);
            var teachGend = new Genders(gender);
            Name = name;
            
            BirthDate = birthDate;
            Post = teach;
            Gender = teachGend;
        }
    }
}
