/*Текстовый файл содержит координаты точек, разделённые между собой «;». Сами
координаты перечислены через «,». Точки произвольные и не принадлежат никакой 
функциональной зависимости. Считать исходный файл и записать точки в новый файл 
построчно, без разделителей в порядке увеличения их удалённости от начала координат.*/

/* Код считывает координаты точек из файла input.txt, создает объекты Point для каждой точки и добавляет их в список points. 
 * Затем точки сортируются по удаленности от начала координат и записываются в новый файл output.txt по одной точке в строке. 
 * Класс Point содержит методы для вычисления расстояния от точки до начала координат и преобразования точки в строку.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Чтение координат точек из файла
        string filePath = "input.txt";
        string[] lines = File.ReadAllLines(filePath);
        string[] coords = lines[0].Split(';');
        List<Point> points = new List<Point>();
        foreach (string coord in coords)
        {
            string[] doubleCoord = coord.Split(',');

            double x = double.Parse(doubleCoord[0]);
            double y = double.Parse(doubleCoord[1]);
            points.Add(new Point(x, y));
        }

        // Сортировка точек по удаленности от начала координат
        List<Point> sortedPoints = points.OrderBy(p => p.DistanceFromOrigin()).ToList();

        // Запись точек в новый файл
        string outputFilePath = "output.txt";
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (Point point in sortedPoints)
            {
                writer.WriteLine(point.ToString());
            }
        }
    }
}

class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Расстояние от точки до начала координат
    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    // Преобразование точки в строку
    public override string ToString()
    {
        return $"{X},{Y}";
    }
}

