using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textiktudasuda
{
    public class TextChanger
    {
        public void EditFigure(Figure selectedFigure)
        {
            Console.WriteLine("Выберите, что вы хотите изменить (число, под которым записан пункт):");
            Console.WriteLine("1. Изменить название фигуры");
            Console.WriteLine("2. Изменить ширину фигуры (число слева от крестика)");
            Console.WriteLine("3. Изменить высоту фигуры (число справа от крестика)");
            Console.WriteLine("4. Ничего не хочу менять, мне так нравится");

            int doing = Convert.ToInt32(Console.ReadLine());

            switch (doing)
            {
                case 1:
                    Console.WriteLine("Введите новое название фигуры: ");
                    selectedFigure.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Введите новую ширину фигуры:");
                    selectedFigure.Width = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Введите новую высоту фигуры:");
                    selectedFigure.Height = Convert.ToInt32(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("Принято");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Неверный выбор, такой чиселки нету, пробуй ещё раз!");
                    break;
            }
        }
    }
}
