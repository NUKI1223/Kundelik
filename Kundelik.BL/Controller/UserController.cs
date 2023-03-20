using Kundelik.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Controller
{
    [Serializable]
    public class UserController
    {
        
        public  List<Student> Students { get; set; }
        public  List<Teacher> Teachers { get; set; }
        
        public Student CurrentStudent { get; }
        public Teacher CurrentTeacher { get; }
        public bool IsNewUser { get; } = false;
        public UserController()
        {

        }
        public UserController(Admin admin)
        {
            while (true)
            {


                Console.Write("Здравствуйте! Что вы хотите сделать?(1-добавить учителя, 2-удалить учителя, 3-выйти) ");
                int action = Convert.ToInt32(Console.ReadLine());
                if (action==3)
                {
                    break;
                }
                switch (action)
                {

                    case 1:
                        string post = "Учитель";
                        Console.Write("Введите имя учителя: ");
                        string userName = Console.ReadLine();
                        Teachers = GetTeachersData();

                        CurrentTeacher = Teachers.SingleOrDefault(x => x.Name == userName);

                        if (CurrentTeacher == null)
                        {
                            Console.Write("Введите пол(М или Ж): ");
                            var gender = Console.ReadLine();
                            DateTime birthDate = DateTimeParser();
                            CurrentTeacher = new Teacher(userName, gender, birthDate, post);
                            Teachers.Add(CurrentTeacher);
                            IsNewUser = true;



                            SetNewUserData(gender, birthDate, post);
                            Console.WriteLine($"{CurrentTeacher.Name} {CurrentTeacher.Age}");
                            SaveTeacher();
                        }

                        break;
                    case 2:
                        Teachers = GetTeachersData();
                        int i = 0;
                        foreach (var item in Teachers)
                        {
                            
                            Console.WriteLine($"{item.Name}-{i++}, ");
                        }
                        Console.Write("Введите номер учителя, которого вы хотите удалить: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Teachers.RemoveAt(index);
                        SaveTeacher();
                        break;
                    
                    default:
                        
                        break;
                }
            }
        }
        public UserController(string userName, string post)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Строка не может быть пустой!", nameof(userName));
            }
            if (post.ToLower() == "студент")
            {
                Students = GetStudentsData();

                CurrentStudent = Students.SingleOrDefault(x => x.Name == userName);
                
                if (CurrentStudent == null)
                {
                    Console.Write("Введите пол(М или Ж): ");
                    var gender = Console.ReadLine();
                    DateTime birthDate = DateTimeParser();
                    CurrentStudent = new Student(userName, gender, birthDate, post);
                    Students.Add(CurrentStudent);
                    IsNewUser = true;
                    SetNewUserData(gender, birthDate, post);
                    Console.WriteLine($"{CurrentStudent.Name} {CurrentStudent.Age}");
                    SaveStudents();
                    
                }
                else
                {
                    Console.WriteLine($"{CurrentStudent.Name} {CurrentStudent.Age}");
                }
            }

        }
        
        public void StudentViewer()
        {
            Students = GetStudentsData();

            CurrentStudent.PrintGrades();
        }
        public DateTime DateTimeParser()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения(dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректная дата рождения");
                }
            }

            return birthDate;
        }
        public void SetNewUserData(string genderName, DateTime birthDate, string postName)
        {

            if (postName.ToLower() =="студент")
            {
                CurrentStudent.Gender = new Genders(genderName);
                CurrentStudent.BirthDate = birthDate;
                CurrentStudent.Post = new Posts(postName);

            }
            if (postName.ToLower() =="учитель")
            {
                CurrentTeacher.Gender = new Genders(genderName);
                CurrentTeacher.BirthDate = birthDate;
                CurrentTeacher.Post = new Posts(postName);
            }
            
        }
        
        
        private List<Student> GetStudentsData()
        {
            
            var formatter = new BinaryFormatter();
            using (var filestring = new FileStream("students.dat", FileMode.OpenOrCreate))
            {
                
                if (filestring.Length > 0 && formatter.Deserialize(filestring) is List<Student> student)
                {

                    return student;
                }
                else
                {
                    return new List<Student>();
                }

            }
        }
        private List<Teacher> GetTeachersData()
        {
            var formatter = new BinaryFormatter();
            using (var filestring = new FileStream("teachers.dat", FileMode.OpenOrCreate))
            {
                
                
                if (filestring.Length > 0 && formatter.Deserialize(filestring) is List<Teacher> teacher)
                {

                    return teacher;
                }
                else
                {
                    return new List<Teacher>();
                }

            }
        }
        
        public void SaveTeacher()
        {
            var formatter = new BinaryFormatter();
            using (var filestring = new FileStream("teachers.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestring, Teachers);
                
            }

        }
        public void SaveStudents()
        {
            var formatter = new BinaryFormatter();
            using (var filestring = new FileStream("students.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestring, Students);
            }

        }
        public void SetGrades()
        {
            while (true)
            {
                Console.Write("Вы хотите добавить или изменить оценки студенту?(да, нет): ");
                if (Console.ReadLine().ToLower()=="нет")
                {
                    break;
                }
                    Console.Write("Введите имя студента, которому вы хотите изменить оценку: ");
                    Students = GetStudentsData();
                    string name = Console.ReadLine();
                    var student = Students.SingleOrDefault(x => x.Name == name);
                
                
                if (Students.Contains(student))
                {


                    
                        Console.Write("Какой предмет вы хотите ему изменить(1-Математика, 2-Физика, 3-Геометрия, 4-Химия, 5-Английский): ");
                        int item = Convert.ToInt32(Console.ReadLine());
                        switch (item)
                        {

                            case 1:
                                Console.Write("Введите оценку по математике: ");
                                int gradeMath = Convert.ToInt32(Console.ReadLine());
                                student.Math.Add(gradeMath);
                                break;
                            case 2:
                                Console.Write("Введите оценку по физике: ");
                                int gradePhysics = Convert.ToInt32(Console.ReadLine());
                                student.Physics.Add(gradePhysics);
                                break;
                            case 3:
                                Console.Write("Введите оценку по геометрии: ");
                                int gradeGeometry = Convert.ToInt32(Console.ReadLine());
                                student.Geometry.Add(gradeGeometry);
                                break;
                            case 4:
                                Console.Write("Введите оценку по химии: ");
                                int gradeChemistry = Convert.ToInt32(Console.ReadLine());
                                student.Chemistry.Add(gradeChemistry);
                                break;
                            case 5:
                                Console.Write("Введите оценку по английскому: ");
                                int gradeEnglish = Convert.ToInt32(Console.ReadLine());
                                student.English.Add(gradeEnglish);
                                break;
                            default:
                                Console.WriteLine("Некорректные данные!");
                                break;
                        }
                        int index =  Students.IndexOf(student);
                        Students[index] = student;
                        SaveStudents();
                        student.PrintGrades();
                    
                    

                }
                else
                {
                    Console.WriteLine("Студент не найден! ");
                }
                   
                      
                
            }
        }

        
    }
}
