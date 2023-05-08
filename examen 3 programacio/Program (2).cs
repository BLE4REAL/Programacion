namespace Parcial3
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

            while (datoCorrecto == false)
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

                //Definimos las catacterísticas de las calles

                string[] losdeterioros = { "Hundida", "Agrietada", "Ondulada" };
                int[,] laslongitudes = new int[100, 500];
                float[,] lostramos = new float[20, 60];

                Random aleatorio = new Random();
                Calle[] calles = new Calle[cantidadCalles];

                for (int i = 0; i < calles.Length; i++)
                {
                    calles[i] = new Calle();
                    calles[i].Longitud = aleatorio.Next(100, 501);
                    calles[i].Tramo = aleatorio.Next(20, 61);
                    calles[i].Deterioro = losdeterioros[aleatorio.Next(losdeterioros.Length)];

                }

                VisualizaInformacionCalles(calles);

            }

            static void VisualizaInformacionCalles(Calle[] lascalles)
            {
                Console.WriteLine($"\n La cantidad de calles que hay en total {lascalles.Length} y se encuentran de la siguiente manera");

                int contador = 1;
                foreach (Calle unacalle in lascalles)
                {
                    Console.WriteLine($"\nCalle No. {contador}, \n" +
                        $"tiene una longitud de {unacalle.Longitud} " +
                        $"metros y un {unacalle.Tramo}% de esta " +
                        $"se encuentra {unacalle.Deterioro}");
                    contador++;

                }
            }

        }
    }
}
