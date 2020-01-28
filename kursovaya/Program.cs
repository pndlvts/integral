using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandelov_cs
{
    class Program
    {
        static double Integral(double p)
        {
            return Math.Cos(Math.Pow(p, 2))/Math.Sqrt(Math.Sin(p)); //Наш интеграл
        }






        static int Simpson()
        {
            double x, a, b, h, s; //a, b-пределы интегрирования, s-сумма в скобках, h-шаг
            int n;
            try
            { 
                Console.Write("Отрезок интегрирования[a, b] —> (a) = ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Отрезок интегрирования[a, b] —> (b) = ");
                b = double.Parse(Console.ReadLine());
                Console.Write("На сколько частей нужно разделить отрезок? n = ");
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введено неверное значение!");
                return 1;
            }
            h = (b - a) / n;
            s = 0; x = a + h;
            while (x < b)
            {
                s = s + 4 * Integral(x);
                x = x + h;
                s = s + 2 * Integral(x);
                x = x + h;
            }
            s = h / 3 * (s + Integral(a) - Integral(b)); //integral(a), integral(b)-значения функции на концах отрезка
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("");
            Console.WriteLine("Интеграл = {0}", Math.Round(s, 2));
            Console.WriteLine("_____________________________________________");
            return 0;
        }




        
        static int Trapezoid()
        {
            double x, a, b, h, s; //a, b-пределы интегрирования, s-сумма в скобках, h-шаг
            int n;
            try
            {
                Console.Write("Отрезок интегрирования[a, b] —> (a) = ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Отрезок интегрирования[a, b] —> (b) = ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Количество интервалов разбиения n = ");
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введено неверное значение!");
                return 1;
            }
            h = (b - a) / n; //шаг (он же основание трапеции)
            s = (Integral(a) + Integral(b)) / 2; //точно не помню, но вроде как тут учитываем граничные значения 
            for (x = a + h; x < b; x += h)
            {
                s += Integral(x); //складываем значения правых сторон всех трапеций
            }
            s = s * h; //домножаем на шаг
            Console.WriteLine("Ответ: {0}", Math.Round(s, 2));
            return 0;
        }






        static int Rect()
        {
            double a, b;
            int n;
            try
            {
                Console.Write("Отрезок интегрирования[a, b] —> (a) = ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Отрезок интегрирования[a, b] —> (b) = ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Введите количество прямоугольников: ");
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введено неверное значение");
                return 1;
            }
            double h, s = 0, f;
            h = (b - a) / n;
            for (double x1 = 0, x = a; x <= b; x += h)
            {
                if (x < b)
                {
                    x1 = x + h / 2;
                    if (x1 >= 2)
                        continue;
                    f = Integral(x1);
                    s += f;
                }

            }
            s = s * h;
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("");
            Console.WriteLine("Данный интеграл равен: {0}", Math.Round(s, 2));
            Console.WriteLine("_____________________________________________");
            return 0;
        }






        static void Main(string[] args)
        {
            string method;
            int methodNum;
            while (true)
            {
                Console.WriteLine("1: Метод Cимпсона");
                Console.WriteLine("2: Метод прямоугольника");
                Console.WriteLine("3: Метод трапеции");
                Console.WriteLine("4: Выход");
                Console.Write("Метод (от 1 до 3): ");
                method = Console.ReadLine();
                if (Int32.TryParse(method, out methodNum) !=true)
                {
                    Console.WriteLine("Некорректный ввод");
                    while (Int32.TryParse(method, out methodNum) != true)
                    {
                        Console.Write("Введите значение снова: ");
                        method = Console.ReadLine();
                    }
                }
                switch (methodNum)
                {
                    case 1:
                        Simpson();
                        break;
                    case 2:
                        Rect();
                        break;
                    case 3:
                        Trapezoid();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверное значение");
                        break;

                }
            }
        }
    }
}