namespace Parcial3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Se desea implementar un sistema de administración vial (SAV) que permita simular el proceso de reparación de las calles de acuerdo con las restricciones planteadas");
            Console.WriteLine("Se evaluarán tramos y se identificará cuántos metros de calle se pavimentaron por cada tipo de deterioro");
            int LosTramos = 100;
            int[] MetrosArregladosHundimiento = new int[LosTramos];

            int[] MetrosArregladosAgrietamientos = new int[LosTramos];

            int[] MetrosArregladosParaOndulamiento = new int[LosTramos];

            int[] longitudesParaLosTramos = new int[LosTramos];

            int TotalMPH = 0;

            int TotalMPA = 0;

            int TotalMPO = 0;

            int totalLongitudesTramos = 0;

            Random aleatorio = new Random();

            for (int i = 0; i < LosTramos; i++)
            {
                try
                {
                    Calle calle = new Calle();
                    calle.Longitud = aleatorio.Next(100, 501);
                    int longitudTramo = aleatorio.Next((int)(calle.Longitud * 0.2), (int)(calle.Longitud * 0.6));
                    longitudesParaLosTramos[i] = longitudTramo;

                    Console.WriteLine("Calle " + (i + 1));
                    Console.WriteLine("Longitud total de la calle: " + calle.Longitud);
                    Console.WriteLine("Longitud del tramo: " + longitudTramo);

                    if (longitudTramo >= (int)(calle.Longitud * 0.5))
                    {
                        MetrosArregladosHundimiento[i] = longitudTramo;
                        TotalMPH += longitudTramo;
                        Console.WriteLine("Metros pavimentados debid hundimientos: " + longitudTramo);
                    }
                    else if (longitudTramo >= (int)(calle.Longitud * 0.3))
                    {
                        MetrosArregladosAgrietamientos[i] = longitudTramo;
                        TotalMPA += longitudTramo;
                        Console.WriteLine("Metros pavimentados debido a los agrietamientos: " + longitudTramo);
                    }
                    else
                    {
                        MetrosArregladosParaOndulamiento[i] = longitudTramo;
                        TotalMPO += longitudTramo;
                        Console.WriteLine("Metros pavimentados debido a las ondulaciones: " + longitudTramo);
                    }

                    totalLongitudesTramos += longitudTramo;
                }
                catch (Exception Elerror)
                {
                    Console.WriteLine("Hubo una falla en el programa:) " + Elerror.Message);
                }

                Console.WriteLine();

                Console.WriteLine("Los metros pavimentados por hundimientos fueron: " + TotalMPH);
                Console.WriteLine("Los metros pavimentados por agrietamientos fueron: " + TotalMPA);
                Console.WriteLine("Los metros pavimentados por ondulaciones fueron: " + TotalMPO);

                double longitudPromedio = (double)totalLongitudesTramos / LosTramos;



            }
        }
    }
}

