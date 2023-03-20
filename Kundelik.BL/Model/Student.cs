using Kundelik.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Model
{
    [Serializable]
    public class Student : User, IGrades
    {
        public UserController userController = new UserController();
        public Student(string name, string post)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым ", nameof(name));
            }
            
            this.name = name;

        }

        public Student(string name, string gender, DateTime birthDate, string post) 
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

            var study = new Posts(post);
            var studyGend = new Genders(gender);
            Name = name;

            BirthDate = birthDate;
            Post = study;
            Gender = studyGend;
        }
        private List<int> math= new List<int>();

        public List<int> Math
        {
            get { return math; }
            set { math = value; }
        }
        private List<int> physics = new List<int>();

        public List<int> Physics
        {
            get { return physics; }
            set { physics = value; }
        }
        private List<int> geometry = new List<int>();

        public List<int> Geometry
        {
            get { return geometry; }
            set { geometry = value; }
        }
        private List<int> chemistry = new List<int>();

        public List<int> Chemistry
        {
            get { return chemistry; }
            set { chemistry = value; }
        }
        private List<int> english = new List<int>();

        public List<int> English
        {
            get { return english; }
            set { english = value; }
        }

        

        public int AverageGrade(List<int> item)
        {
            return  (int)item.Average();
        }
        public void PrintGrades()
        {
            Console.Write("Математика: ");
            foreach (var item in Math)
            {
                Console.Write(item+", " );
            }
            Console.WriteLine();
            Console.Write("Физика: ");
            foreach (var item in Physics)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
            Console.Write("Геометрия: ");
            foreach (var item in Geometry)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
            Console.Write("Химия: ");
            foreach (var item in Chemistry)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
            Console.Write("Английский: ");
            foreach (var item in English)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
}
