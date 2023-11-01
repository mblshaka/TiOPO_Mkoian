using System.Reflection.Metadata;
using System.Text;

namespace ConsoleApp1
{
    class DescriminantBelowZero: Exception
    {
        public override string Message { get { return "Дискриминант меньше нуля"; } }
    }
    class DescriminantZero : Exception
    {
        public override string Message { get { return "Дискриминант равен нулю"; } }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = 0;
            double c = 0;
            string path = "My_Data.txt";
            double[] x_mas = new double[2];
            int count_x = 0;
            try
            {
                string text = "";
                using (var sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }

                int back = 0;
                string[] x_mas_string = text.Split(" ");
                a = Convert.ToInt32(Convert.ToString(x_mas_string[0]));
                b = Convert.ToInt32(Convert.ToString(x_mas_string[1]));
                c = Convert.ToInt32(Convert.ToString(x_mas_string[2]));
                double disc = Math.Pow(b, 2) - 4 * a * c;
                x_mas[0] = (-b + Math.Sqrt(disc))/ (2*a);
                x_mas[1] = (-b - Math.Sqrt(disc))/ (2*a);
                if (disc < 0) throw new DescriminantBelowZero();
                if (disc == 0) throw new DescriminantZero();
                count_x = 2;
            }
            catch(DescriminantBelowZero ex)
            {
                Console.WriteLine(ex.Message);
                count_x = 0;
            }
            catch(DescriminantZero ex)
            {
                Console.WriteLine(ex.Message);
                count_x = 1;
            }
            catch(System.IO.IOException ex)
            {
                Console.WriteLine("Ошибка считывания файла My_Data. Проверьте путь");
                count_x = -1;
            }
            catch(System.FormatException ex)
            {
                Console.WriteLine("В файле содержаться символы не числового формата ИЛИ в фалйе недостаточно данных. Проверьте данные в файле My_Data");
                count_x = -1;           
            }
            finally
            {
                string s_b = "";
                string s_c = "";
                switch (count_x)
                {
                    case 0:
                        if (b > 0) s_b = "+";
                        else s_b = "-";
                        if (c > 0) s_c = "+";
                        else s_c = "-";
                        Console.WriteLine("Уравнение: " + a + "x^2" + s_b + b + "x" + s_c + c + "=0");
                        Console.WriteLine("Корней нет");
                        break;
                    case 1:
                        if (b > 0) s_b = "+";
                        else s_b = "-";
                        if (c > 0) s_c = "+";
                        else s_c = "-";
                        Console.WriteLine("Уравнение: " + a + "x^2" + s_b + b + "x" + s_c + c + "=0");
                        Console.WriteLine("Корень: " + x_mas[0]);
                        break;
                    case 2:
                        if (b > 0) s_b = "+";
                        else s_b = "-";
                        if (c > 0) s_c = "+";
                        else s_c = "-";
                        Console.WriteLine("Уравнение: " + a + "x^2" + s_b + b + "x" + s_c + c + "=0");
                        Console.WriteLine("Первый корень: " + x_mas[0] + "\nВторой корень: " + x_mas[1]);
                        break;
                    case -1:
                        break;

                }
            }

        }
    }
}