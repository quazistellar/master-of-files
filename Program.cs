using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;
using Newtonsoft.Json;

namespace textiktudasuda
{
    public class Figure
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Figure()
        {
        }

        public Figure(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }
    }

    public class Program
    {
        public static void Main()
        {
            FileHandler fh = new FileHandler();
            TextChanger tch = new TextChanger();
            Console.WriteLine(" >>> ТЕКСТОВЫЙ КОНВЕРТЕР <<< ");
            Console.WriteLine("Введите путь до вашего файла:");

            string filePath = Console.ReadLine();

            string firstLine = fh.readFirstLine(filePath);
            List<Figure> figures = fh.readfigures(filePath);

            if (int.TryParse(firstLine, out _))
            {
                figures.Add(new Figure("Неизвестная фигура", 0, 0));
            }
            if (figures.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"Загруженные фигуры из файла:");
                Console.WriteLine();

                for (int i = 0; i < figures.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Фигура: {figures[i].Name}, {figures[i].Width}x{figures[i].Height}");
                }

                while (true)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Выберите, какую фигуру вы хотите изменить (число, под которым она записана):");
                    Console.WriteLine();

                    for (int i = 0; i < figures.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Фигура: {figures[i].Name}, {figures[i].Width}x{figures[i].Height}");
                    }
                    Console.WriteLine("0. Ничего не хочу менять");
                    Console.WriteLine("------------------------------------------");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 0)
                    {
                        Console.WriteLine("Как скажете");
                        break;
                    }

                    if (choice >= 1 && choice <= figures.Count)
                    {
                        Figure selectedFigure = figures[choice - 1];
                        tch.EditFigure(selectedFigure);
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор, такой чиселки нету, пробуй ещё раз!");
                    }
                }

                Console.WriteLine("Нажмите F1 для сохранения фигур в одном из трех форматов: txt, xml, json или Escape, чтобы выйти");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.F1)
                {
                    Console.WriteLine("\nВыберите формат сохранения (txt, xml, json):");
                    string format = Console.ReadLine();

                    Console.WriteLine("Введите путь для сохранения файла:");
                    string savePath = Console.ReadLine();
                    fh.savefigures(savePath, figures);

                    Console.WriteLine("Ваш файл успешно сохранен в указанном вами пути!");
                }
                
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                }
            }
                ending();
        }

        private static void ending()
        {
            Console.WriteLine("Нажмите Escape для выхода или Z для работы с ещё одним файлом");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("Вы завершили работу с программой!");
                    break;
                }
                else if (key.Key == ConsoleKey.Z)
                {
                    Console.Clear();
                    Main();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Неверная клавиша, попробуй ещё раз (escape - выход/z - поработать с ещё одним файлом)");
                }
            }
        }

    }
}