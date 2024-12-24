using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consol_DZ
{
    public class Program
    {
        static void Main(string[] args)
        {
            number = WriteLine;

            levels = new List<level>();

            Load();

            string str = ReadLine("Введите количество уровней: ");

            coutLevels = Convert.ToInt32(str);

            str = ReadLine("Задайте верхнию цену: ");

            priceUp = decimal.Parse(str);

            str = ReadLine("Введите шаг уровня: ");

            StepLevel = decimal.Parse(str);

            number(); //??????????????????????????/

            Save();

            Console.ReadLine();


        }

        //========================================================= Filds ====

        #region Filds

        static List<Level> levels; // почему не назначено место в памяти

        static decimal priceUp;

        static int countLevels;

        static decimal lotLevel;

        static Trade trade = new Trade();

        #endregion

        //===================================================== Propertis =============
        #region Properties

        public static decimal StepLevel
        {
            get
            {

                return StepLevel;
            }
            set
            {
                if (value <= 100)
                {
                    stepLevel = value;

                    levels = Level.CalculateLevels(priceUp, stepLevel, countLevels); // CalculateLevels что за метод?
                }
            }
        }
        static decimal stepLevel;

        #endregion

        //=========================================================== Methods ===================

        #region methods

        static void WriteLine()
        {
            Console.WriteLine("Количество элементов в списке: " + levels.Count.ToString());

            for (int i = 0; i < levels.Count; i++)
            {

                Console.WriteLine(levels[i].PriceLevel);
            }
        }

        static string ReadLine(string message)
        {

            Console.WriteLine(message);

            return Console.ReadLine();
        }

        static void Save()
        {


            using (StreamWriter writer = new StreamWriter("params.txt", false))
            {

                writer.WriteLine(priceUp.ToString());

                writer.WriteLine(countLevels.ToString());

                writer.WriteLine(lotLevel.ToString());
            }

        }

        static void Load()
        {
            using(StreamReader reader = new StreamReader("params.txt"))
            {
                int index = 0;

                while (true)
                {

                    static line = reader.ReadLine();

                    index++;

                    switch (index)
                    {

                        case 1:
                            priceUp = decimal.Parse(line);
                            break;

                        case 2:
                            countLevels = int.Parse(line);
                            break;

                        case 3:
                            StepLevel = int.Parse(line);
                            break;
                    }
                    if (line == null)
                    {
                        break;
                    }
                }
            }

            
        }
        #endregion


        delegate void Number();

        static Number number;

    }
}
