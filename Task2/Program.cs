using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /*Используя Visual Studio, создайте проект по шаблону Console Application.
   Создайте программу, в которой, создайте структуру с именем Worker (работник), содержащую следующие поля: фамилия и инициалы работника,
    название занимаемой должности, год поступления на работу. Написать логику, которая будет выполнять следующие действия: 1) ввод с 
    клавиатуры данных в массив, состоящий из пяти элементов типа Worker(записи должны быть упорядочены по алфавиту); 2) сли значение 
    года введено не в соответствующем формате выдает исключение; 3) вывод на экран фамилии работника, стаж работы которого превышает 
    введенное значение*/

    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[5];

            for (int i = 0; i < workers.Length; i++)
            { 
                Console.Write("Enter worker`s initials: ");
                workers[i].EmployeeInitials = Console.ReadLine();
                Console.Write("Enter worker`s position: ");
                workers[i].Position = Console.ReadLine();
                Console.Write("Enter employment year: ");
                int year = Worker.GetYear();
                workers[i].EmploymentYear = new DateTime(year,1,1);
            }

            var sorteredWorkers = from initials in workers orderby initials.EmployeeInitials select initials;
            foreach (var item in sorteredWorkers)
            {
               Console.WriteLine(item.EmployeeInitials);
               Console.WriteLine(item.Position);
               Console.WriteLine(item.EmploymentYear.Year);
            }

            Console.Write("Enter work experinece in years: ");
            int experience = int.Parse(Console.ReadLine());
            Worker.CheckExperience(experience, workers);

            Console.ReadLine();
        }
    }
    public struct Worker
    {
        public string EmployeeInitials { get; set; }
        public string Position { get; set; }
        public DateTime EmploymentYear ;
        public static void CheckExperience(int years,params Worker[]workers)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if ((DateTime.Now.Year - workers[i].EmploymentYear.Year) > years)
                {
                    Console.WriteLine(workers[i].EmployeeInitials);
                }
            }
        }
        public static int GetYear()
        {
            try
            {
                int year = int.Parse(Console.ReadLine());
                return year;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetYear();
            }
        }
    }
}
