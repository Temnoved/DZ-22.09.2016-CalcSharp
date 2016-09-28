using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZCalcSharp
{
    class Calc
    {
        protected String[] strNums = null;//массив чисел из выражения
        protected char[] chSymbols = null;//массив символов из выражения
        protected double dResult = 0;//результат выражения
        protected String strEnterNum = "";//изночальнный ввод

        //конструктор  параметром по умолчанию
        public Calc(String strEntr = "")
        {
            this.strEnterNum = strEntr;

            //создаём массив строк содержащий цифры из введенного примера
            char [] chSep = { '*', '/', '+', '-' };
            this.strNums = this.strEnterNum.Split(chSep, StringSplitOptions.RemoveEmptyEntries);

            //создаём новый массив для знаков из премера(их всегда будет на один меньше чем цифр)
            chSymbols = new char[this.strNums.Length - 1];

            //складываем в массив знаки из премера
            for(int i = 0; i < chSymbols.Length; i++)
            {
                int j = strEntr.IndexOfAny(chSep);
                chSymbols[i] = strEntr[j];
                strEntr = strEntr.Remove(j, 1);
            }            
        }

        public double Result//для вывода результата
        {
            get { return this.dResult; }
        }

        public String Ishod//ддя вывода исходного выражения
        {
            get { return this.strEnterNum; }
        }

        public void Calculation()//подсчет результата
        {
            double dTempRes1 = 0, dTempRes2 = 0;//временные результаты промежуточных операций
            int i = 0;//индекс массивов
            
            //если знаков больше чем один и первый имеет меньший приоритет чем второй то вычисление начинается со второй операции
            if((i + 1) < this.chSymbols.Length && (this.chSymbols[i + 1] == '*' || this.chSymbols[i + 1] == '/') && (this.chSymbols[i] != '*' && this.chSymbols[i] != '/'))
            {
                if(this.chSymbols[i + 1] == '*')
                {
                    dTempRes2 = (double)((double.Parse(this.strNums[i + 1]) * (double.Parse(this.strNums[i + 2]))));
                }
                if (this.chSymbols[i + 1] == '/')
                {
                    if ((double.Parse((this.strNums[i + 2])) == 0))
                    {
                        throw new Exception("Деление на ноль");
                    }
                    else
                    {
                        dTempRes2 = (double)((double.Parse(this.strNums[i + 1]) / (double.Parse(this.strNums[i + 2]))));
                    }                    
                }
                if (this.chSymbols[i] == '+')
                {
                    dTempRes1 = (double)((double.Parse(this.strNums[i]) + dTempRes2));
                }
                if (this.chSymbols[i] == '-')
                {
                    dTempRes1 = (double)((double.Parse(this.strNums[i]) - dTempRes2));
                }
                this.dResult = dTempRes1;
            }
            //если приоритет операций не сдвинут - вы полняем последовательно справа на лево
            else
            {
                //блок вариантов для первого знака
                if(this.chSymbols[i] == '*')
                {
                    dTempRes1 = (double)((double.Parse(this.strNums[i]) * (double.Parse(this.strNums[i + 1]))));
                }
                if (this.chSymbols[i] == '/')
                {
                    if ((double.Parse(this.strNums[i + 1])) == 0)
                    {
                        throw new Exception("Деление на ноль");
                    }
                    else
                    {
                        dTempRes1 = (double)((double.Parse(this.strNums[i]) / (double.Parse(this.strNums[i + 1]))));
                    }                    
                }
                if (this.chSymbols[i] == '+')
                {
                    dTempRes1 = (double)((double.Parse(this.strNums[i]) + (double.Parse(this.strNums[i + 1]))));
                }
                if (this.chSymbols[i] == '-')
                {
                    dTempRes1 = (double)((double.Parse(this.strNums[i]) - (double.Parse(this.strNums[i + 1]))));
                }

                i++;//сдвигаемся в массивах чисел и знаков на один\
                //блок вариантов для второго знака
                if(i > this.chSymbols.Length - 1)
                {
                    this.dResult = dTempRes1;
                }

                if (this.chSymbols[i] == '*')
                {
                    dTempRes1 *= double.Parse(this.strNums[i + 1]);
                }
                if (this.chSymbols[i] == '/')
                {
                    if ((double.Parse(this.strNums[i + 1])) == 0)
                    {
                        throw new Exception("Деление на ноль");
                    }
                    else
                    {
                        dTempRes1 /= double.Parse(this.strNums[i + 1]);
                    }
                    
                }
                if (this.chSymbols[i] == '+')
                {
                    dTempRes1 += double.Parse(this.strNums[i + 1]);
                }
                if (this.chSymbols[i] == '-')
                {
                    dTempRes1 -= double.Parse(this.strNums[i + 1]);
                }
                this.dResult = dTempRes1;
            }
            
        }

    }
}
