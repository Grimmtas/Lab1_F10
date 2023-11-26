using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TriangleCalculator
{
    private static readonly string logFilePath = "triangle.log";

    public static void CalculateTriangleTypeAndCoordinates(string sideA, string sideB, string sideC)
    {
        try
        {
            float a = float.Parse(sideA);
            float b = float.Parse(sideB);
            float c = float.Parse(sideC);

            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Side lengths must be positive");
            }

            StreamWriter logFile = new StreamWriter(logFilePath, true);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                string triangleType = "не треугольник";
                List<Tuple<int, int>> coordinates = new List<Tuple<int, int>> { new Tuple<int, int>(-1, -1), new Tuple<int, int>(-1, -1), new Tuple<int, int>(-1, -1) };
                string logMessage = $"{timestamp} - Успешный запрос - Тип треугольника: {triangleType}, Координаты вершин: {string.Join(",", coordinates)}";
                Console.WriteLine(logMessage);
                logFile.WriteLine(logMessage);
            }
            else if (a == b && b == c)
            {
                string triangleType = "равносторонний";
                List<Tuple<int, int>> coordinates = new List<Tuple<int, int>> { new Tuple<int, int>(50, 0), new Tuple<int, int>(0, 100), new Tuple<int, int>(100, 100) };
                string logMessage = $"{timestamp} - Успешный запрос - Тип треугольника: {triangleType}, Координаты вершин: {string.Join(",", coordinates)}";
                Console.WriteLine(logMessage);
                logFile.WriteLine(logMessage);
            }
            else if (a == b || a == c || b == c)
            {
                string triangleType = "равнобедренный";
                List<Tuple<int, int>> coordinates = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0), new Tuple<int, int>(100, 0), new Tuple<int, int>(50, 100) };
                string logMessage = $"{timestamp} - Успешный запрос - Тип треугольника: {triangleType}, Координаты вершин: {string.Join(",", coordinates)}";
                Console.WriteLine(logMessage);
                logFile.WriteLine(logMessage);
            }
            else
            {
                string triangleType = "разносторонний";
                List<Tuple<int, int>> coordinates = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0), new Tuple<int, int>(100, 0), new Tuple<int, int>(50, 100) };
                string logMessage = $"{timestamp} - Успешный запрос - Тип треугольника: {triangleType}, Координаты вершин: {string.Join(",", coordinates)}";
                Console.WriteLine(logMessage);
                logFile.WriteLine(logMessage);
            }

            logFile.Close();
        }
        catch (Exception e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string errorMessage = $"{timestamp} - Неуспешный запрос - Ошибка: {e.Message}{Environment.NewLine}{e.StackTrace}";
            Console.WriteLine(errorMessage);
            File.AppendAllText(logFilePath, errorMessage + Environment.NewLine);
        }
    }
}
