namespace Parcial3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa para totalizar la cantidad de calles que fueron pavimentadas");
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
                        Console.WriteLine("La cantidad tiene que ser un número positivo. Inténtelo nuevamente");
                }
                catch (FormatException elError)
                {
                    Console.WriteLine("La cantidad tiene que ser un número entero positivo. Inténtelo nuevamente");
                    Console.WriteLine(elError.Message);

                }
            }
            while (!datoCorrecto);

            //Definimos las catacterísticas de las calles

            string[] losdeterioros = { "Hundimiento", "Agrietamiento", "Ondulamiento" };
            int[,] laslongitudes = new int[100, 500];
            float[,] lostramos = new float[20, 60];

            Random aleatorio = new Random();
            Calle[] calles = new Calle[cantidadCalles];

            for (int i = 0; i < calles.Length; i++)
            {
                calles[i] = new Calle();
                calles[i].Longitud = aleatorio.Next(100, 501);
                calles[i].Tramo = 20f + (float)aleatorio.NextDouble() * (60f - 20f);
                calles[i].Deterioro = losdeterioros[aleatorio.Next(losdeterioros.Length)];
            }
            //Visualización de las carácterísticas de las calles

            Console.WriteLine("\n\n--RESULTADOS--\n");

            for (int i = 0; i < calles.Length; i++)
            {
                Console.WriteLine($"\nCalle No. {(i + 1)}: " +
                    $"\nLongitud de la calle: {calles[i].Longitud}, " +
                    $"tramo afectado: {calles[i].Tramo.ToString(".00")}%," +
                    $"Deterioro: {calles[i].Deterioro}, ");
            }

            //Visualización de los totales por cada tipo de deterioro

            int[] TotalAfectacionesPorDeterioro = TotalizaAfectacionesPorDeterioro(calles, losdeterioros);
            double[] CantidadPavimento = ObtieneCantidadCallePavimentadaPorDeterioro(calles, losdeterioros);
            double[] LongitudPromedio = ObtieneLongitudPromedioTramosPorDeterioro(calles, losdeterioros);

            Console.WriteLine("\n*-TOTALES POR CADA TIPO DE DETERIORO-*\n");

            for (int i = 0; i < losdeterioros.Length; i++)
            {
                Console.WriteLine($"\n{losdeterioros[i]}:\n" +
                    $"Total de afectaciones: {TotalAfectacionesPorDeterioro[i]}" +
                    $"Total de metros pavimentados: {CantidadPavimento[i].ToString(".00")} mts. " +
                    $"De una longitud promedio de {LongitudPromedio[i].ToString(".00")} mts.");
            }
        }

        static int[] TotalizaAfectacionesPorDeterioro(Calle[] calles, string[] losdeterioros)
        {
            int[] TotalAfectaciones = new int[losdeterioros.Length];

            for (int i = 0; i < calles.Length; i++)
                for (int j = 0; j < losdeterioros.Length; j++)
                    if (calles[i].Deterioro == losdeterioros[j])
                        TotalAfectaciones[j]++;

            return TotalAfectaciones;
        }


        static double[] ObtieneCantidadCallePavimentadaPorDeterioro(Calle[] calles, string[] losdeterioros)
        {
            double[] Cantidad = new double[losdeterioros.Length];

            for (int i = 0; i < calles.Length; i++)
                for (int j = 0; j < losdeterioros.Length; j++)
                    if (calles[i].Deterioro == losdeterioros[j])
                    {
                        Cantidad[j] += calles[i].Longitud * (calles[i].Tramo / 100);
                    }
            return Cantidad;
        }


        static double[] ObtieneLongitudPromedioTramosPorDeterioro(Calle[] calles, string[] losdeterioros)
        {
            int[] TotalAfectaciones = TotalizaAfectacionesPorDeterioro(calles, losdeterioros);
            double[] LongitudPromedio = new double[losdeterioros.Length];
            double[] CantidadPavimentoPorDeterioro = ObtieneCantidadCallePavimentadaPorDeterioro(calles, losdeterioros);

            for (int i = 0; i < losdeterioros.Length; i++)
                LongitudPromedio[i] = CantidadPavimentoPorDeterioro[i] / TotalAfectaciones[i];

            return LongitudPromedio;
        }
    }
}namespace Parcial3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa para totalizar la cantidad de calles que fueron pavimentadas");
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
                        Console.WriteLine("La cantidad tiene que ser un número positivo. Inténtelo nuevamente");
                }
                catch (FormatException elError)
                {
                    Console.WriteLine("La cantidad tiene que ser un número entero positivo. Inténtelo nuevamente");
                    Console.WriteLine(elError.Message);

                }
            }
            while (!datoCorrecto);

            //Definimos las catacterísticas de las calles

            string[] losdeterioros = { "Hundimiento", "Agrietamiento", "Ondulamiento" };
            int[,] laslongitudes = new int[100, 500];
            float[,] lostramos = new float[20, 60];

            Random aleatorio = new Random();
            Calle[] calles = new Calle[cantidadCalles];

            for (int i = 0; i < calles.Length; i++)
            {
                calles[i] = new Calle();
                calles[i].Longitud = aleatorio.Next(100, 501);
                calles[i].Tramo = 20f + (float)aleatorio.NextDouble() * (60f - 20f);
                calles[i].Deterioro = losdeterioros[aleatorio.Next(losdeterioros.Length)];
            }
            //Visualización de las carácterísticas de las calles

            Console.WriteLine("\n\n--RESULTADOS--\n");

            for (int i = 0; i < calles.Length; i++)
            {
                Console.WriteLine($"\nCalle No. {(i + 1)}: " +
                    $"\nLongitud de la calle: {calles[i].Longitud}, " +
                    $"tramo afectado: {calles[i].Tramo.ToString(".00")}%," +
                    $"Deterioro: {calles[i].Deterioro}, ");
            }

            //Visualización de los totales por cada tipo de deterioro

            int[] TotalAfectacionesPorDeterioro = TotalizaAfectacionesPorDeterioro(calles, losdeterioros);
            double[] CantidadPavimento = ObtieneCantidadCallePavimentadaPorDeterioro(calles, losdeterioros);
            double[] LongitudPromedio = ObtieneLongitudPromedioTramosPorDeterioro(calles, losdeterioros);

            Console.WriteLine("\n*-TOTALES POR CADA TIPO DE DETERIORO-*\n");

            for (int i = 0; i < losdeterioros.Length; i++)
            {
                Console.WriteLine($"\n{losdeterioros[i]}:\n" +
                    $"Total de afectaciones: {TotalAfectacionesPorDeterioro[i]}" +
                    $"Total de metros pavimentados: {CantidadPavimento[i].ToString(".00")} mts. " +
                    $"De una longitud promedio de {LongitudPromedio[i].ToString(".00")} mts.");
            }
        }

        static int[] TotalizaAfectacionesPorDeterioro(Calle[] calles, string[] losdeterioros)
        {
            int[] TotalAfectaciones = new int[losdeterioros.Length];

            for (int i = 0; i < calles.Length; i++)
                for (int j = 0; j < losdeterioros.Length; j++)
                    if (calles[i].Deterioro == losdeterioros[j])
                        TotalAfectaciones[j]++;

            return TotalAfectaciones;
        }


        static double[] ObtieneCantidadCallePavimentadaPorDeterioro(Calle[] calles, string[] losdeterioros)
        {
            double[] Cantidad = new double[losdeterioros.Length];

            for (int i = 0; i < calles.Length; i++)
                for (int j = 0; j < losdeterioros.Length; j++)
                    if (calles[i].Deterioro == losdeterioros[j])
                    {
                        Cantidad[j] += calles[i].Longitud * (calles[i].Tramo / 100);
                    }
            return Cantidad;
        }


        static double[] ObtieneLongitudPromedioTramosPorDeterioro(Calle[] calles, string[] losdeterioros)
        {
            int[] TotalAfectaciones = TotalizaAfectacionesPorDeterioro(calles, losdeterioros);
            double[] LongitudPromedio = new double[losdeterioros.Length];
            double[] CantidadPavimentoPorDeterioro = ObtieneCantidadCallePavimentadaPorDeterioro(calles, losdeterioros);

            for (int i = 0; i < losdeterioros.Length; i++)
                LongitudPromedio[i] = CantidadPavimentoPorDeterioro[i] / TotalAfectaciones[i];

            return LongitudPromedio;
        }
    }
}