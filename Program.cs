//написать калькулятор, который должен принимать с командной строки при запуске(вспоминайте наше 1е занятие и параметр в методе Main ) математический
//пример: 2 + 2 * 3, вычисляет результат и выводит на консоль в:
//1) десятичном виде
//2) Hex
//3) двоичном виде.
//Заранее известно, что математических операций в примере не может быть более двух, но може быть одно: 2 * 2. Калькулятор должен уметь вычислять: */+-. 
//Если программа запускается без параметров, тогда должна вывестись справка на консоль, версия программы и имя разработчика.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZCalcSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)//в случае если программа запускается без параметров выводим справку
                {
                    Console.WriteLine("Program: CalcSharp v0.1_alpfa (2016)\nDevelop: Podoplelov Alexander");
                    Console.WriteLine("Для использования программы после имени исполняемого файла\nвведите выражение (например:DZ(22.09.2016)CalcSharp.exe 1+2*3)");
                    Console.WriteLine("ВНИМАНИЕ! Программа работает только с операциями *, /, + и -");
                    Console.WriteLine("ВНИМАНИЕ! Программа работает только с целыми числами");
                    Console.WriteLine("Результат будет выведен в форматах:\nDEC - десятичный; HEX - шестнадцатиричный; BIN - двоичный;");
                    Console.WriteLine("\nДля продолжения нажмите Enter");
                    Console.Read();
                    return;
                }

                Calc cTest = new Calc(args[0]);//создаём объект класса с параметрами запуска
                cTest.Calculation();//вычесляем результат

                Console.WriteLine(cTest.Ishod + " = ");//показываем исходное выражение
                Console.WriteLine("DEC: " + (int)cTest.Result);//показываем результат в десятичной форме



                //два варианта перевода результата в шестнадцатиричную форму
                //Console.WriteLine("HEX: " + (Convert.ToString((int)cTest.Result, 16)));
                Console.WriteLine("HEX: " + ((int)cTest.Result).ToString("X"));

                //cTest.toBin();
                //перевод результата в двоичную форму
                Console.WriteLine("BIN: " + Convert.ToString((int)cTest.Result, 2));


                Console.Read();//пауза
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }

        }//конецMain
    }//конец class Program
}//конецnamespace DZ2016CalcSharp
