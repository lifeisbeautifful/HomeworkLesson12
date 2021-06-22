using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    /*Используя Visual Studio, создайте проект по шаблону Console Application.
   Создайте программу, в которой, создайте класс Calculator.В теле класса создайте четыре метода для арифметических действий: 
    (Add – сложение, Sub – вычитание, Mul – умножение, Div – деление). Метод деления должен делать проверку деления на ноль,
    если проверка не проходит, сгенерировать исключение.Пользователь вводит значения, над которыми хочет произвести операцию и 
    выбрать саму операцию.При возникновении ошибок должны выбрасываться исключения. */

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            
            Console.Write("Enter the arithmetic operator: ");
            string sign = Console.ReadLine();

            switch (sign)
            {
                case "+":
                    calculator.Add();
                    break;
                case "-":
                    calculator.Sub();
                    break;
                case "*":
                    calculator.Mul();
                    break;
                case "/":
                    calculator.Div();
                    break;
            }

            Console.ReadLine();
        }
    }
    public class Calculator
    {
        Exception exception = new Exception("Attempt divide by zero!");
        public void Add()
        {
            try
            {
                Console.Write("Enter first operand: ");
                double firstNum = double.Parse(Console.ReadLine());
                Console.Write("Enter second operand: ");
                double secondNum = double.Parse(Console.ReadLine());
                Console.WriteLine("{0} + {1} = {2}", firstNum, secondNum, Math.Round(firstNum + secondNum,2));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter 'Exit' to close calculator or press any key to continue");
                string userChoice = Console.ReadLine();
                if (!userChoice.Equals("Exit")){ Add(); }
            }
        }
        public void Sub() 
        {
            try
            {
                Console.Write("Enter first operand: ");
                double firstNum = double.Parse(Console.ReadLine());
                Console.Write("Enter second operand: ");
                double secondNum = double.Parse(Console.ReadLine());
                Console.WriteLine("{0} - {1} = {2}", firstNum,secondNum,Math.Round(firstNum - secondNum,2));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter 'Exit' to close calculator or press any key to continue");
                string userChoice = Console.ReadLine();
                if (!userChoice.Equals("Exit")) { Sub(); }
            }
        }
        public void Mul()
        {
            try
            {
                Console.Write("Enter first operand: ");
                double firstNum = double.Parse(Console.ReadLine());
                Console.Write("Enter second operand: ");
                double secondNum = double.Parse(Console.ReadLine());
                Console.WriteLine("{0} * {1} = {2}", firstNum,secondNum,Math.Round(firstNum * secondNum,2));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter 'Exit' to close calculator or press any key to continue");
                string userChoice = Console.ReadLine();
                if (!userChoice.Equals("Exit")) { Mul(); }
            }
        }
        public void Div()
        {
            try
            {
                Console.Write("Enter first operand: ");
                double firstNum = double.Parse(Console.ReadLine());
                Console.Write("Enter second operand: ");
                double secondNum = double.Parse(Console.ReadLine());
                if (secondNum == 0)
                {
                    throw exception;
                }
                else
                {
                    Console.WriteLine("{0} / {1} = {2}", firstNum, secondNum, Math.Round(firstNum / secondNum,2));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Enter 'Exit' to close calculator or press any key to continue");
                string userChoice = Console.ReadLine();
                if (!userChoice.Equals("Exit")) { Div(); }
            }
        }
    }
}

