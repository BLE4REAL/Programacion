﻿namespace Parcial3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa para totalizar la cantidad de calles que gueron pavimentadas");
            Console.WriteLine("Se encuentran casos de hundimientos, agrietamientos y ondulamientos por tramos");
            Console.WriteLine("La longitud relativa de los tramos abarca entre [20%, 60%]");
            Console.WriteLine("La longitud total de las calles está entre [100 mts, 500 mts]\n\n");

            int cantidadCalles = 0;
            bool datoCorrecto = false;

            do
            {
                try
                {
                    Console.WriteLine("\nIntroduzca la cantidad de calles que hay");
                    cantidadCalles = int.Parse(Console.ReadLine()!);

                    if (cantidadCalles > 0)
                        datoCorrecto = true;
                    else
                        Console.WriteLine("La cantidad tiene que ser un número positivo. Intenetelo nuevamente");
                }
                catch (FormatException elError)
                {
                    Console.WriteLine("La cantidad tiene que ser un número entero positivo. Intentelo nuevamente");
                    Console.WriteLine(elError.Message);

                }
            }
            while (!datoCorrecto);

                //Definimos las catacterísticas de las calles

            string[] losdeterioros = { "Hundimiento", "Agrietamiento", "Onduladamiento" };
            int[,] laslongitudes = new int[100, 500];
            float[,] lostramos = new float[20, 60];

                Random aleatorio = new Random();
                Calle[] calles = new Calle[cantidadCalles];

            for (int i = 0; i < calles.Length; i++)
            {
                calles[i] = new Calle();
                calles[i].Longitud = aleatorio.Next(100, 501);
                calles[i].Tramo = 20 + aleatorio.NextDouble() * (60 - 20);
                calles[i].Deterioro = losdeterioros[aleatorio.Next(losdeterioros.Length)];

            }
                //Visualización de las carácterísticas de las calles
                
                Console.WriteLine("\n\n--RESULTADOS--\n");

            for (int i = 0; i <calles.Length; i++)
            {
                Console.WriteLine($"\nCalle No. {(i + 1)}: " +
                    $"\nLongitud de la calle: {calles[i].Longitud}, " +
                    $"tramo afectado: {calles[i].Tramo.ToString(".00")}%," +
                    $"Longitud de la calle: {calles[i].Longitud}, " +
                    $"Deterioro: {calles[i].Deterioro}, ");

            }

            //Visualización de los totales por cada tipo de deterioro

            int[] TotalAfectacionesPorDeterioro = TotalizaAfectacionesPorDeterioro(calles, losdeterioros);
            double[] CantidadPavimento = ObtieneCantidadCallePavimentadaPorDeterioro(calles, losdeterioros);
            double[] LongitudPromedio = ObtieneLongitudPronedioTramosPorDeterioro(calles, losdeterioros);

            Console.WriteLine("\n**-TOTALES POR CADA TIPO DE DETERIORO-**\n");
            
            for (int i = 0; i < losdeterioros.Length; i++)
            {
                Console.WriteLine($"\n{losdeterioros[i]}:\n" +
                    $"Total de afectaciones: {TotalAfectacionesPorDeterioro[i]}"+
                    $"Total de metros pavimentados: {CantidadPavimento[i].ToString(".00")} mts. "+
                    $"De una longitud promedio de {LongitudPromedio[i].ToString(".00")} mts.");

            }
        }

    }
}
