using Examen03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebaTramos
{
    [TestClass]
    public class CalleTests
    {
        [TestMethod]
        public void TestTotalizaAfectacionesPorDeterioro()
        {
            Calle[] calles = new Calle[4];
            calles[0] = new Calle { Longitud = 200, Tramo = 25, Deterioro = "Hundimiento" };
            calles[1] = new Calle { Longitud = 150, Tramo = 40, Deterioro = "Agrietamiento" };
            calles[2] = new Calle { Longitud = 300, Tramo = 60, Deterioro = "Ondulamiento" };
            calles[3] = new Calle { Longitud = 120, Tramo = 30, Deterioro = "Hundimiento" };

            string[] losdeterioros = { "Hundimiento", "Agrietamiento", "Ondulamiento" };

            int[] expected = { 2, 1, 1 };
            int[] actual = Parcial3.Program.TotalizaAfectacionesPorDeterioro(calles, losdeterioros);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestObtieneCantidadCallePavimentadaPorDeterioro()
        {
            Calle[] calles = new Calle[4];
            calles[0] = new Calle { Longitud = 200, Tramo = 25, Deterioro = "Hundimiento" };
            calles[1] = new Calle { Longitud = 150, Tramo = 40, Deterioro = "Agrietamiento" };
            calles[2] = new Calle { Longitud = 300, Tramo = 60, Deterioro = "Ondulamiento" };
            calles[3] = new Calle { Longitud = 120, Tramo = 30, Deterioro = "Hundimiento" };

            string[] losdeterioros = { "Hundimiento", "Agrietamiento", "Ondulamiento" };

            double[] expected = { 1372.50, 840.00, 1320.00 };
            double[] actual = Parcial3.Program.ObtieneCantidadCallePavimentadaPorDeterioro(calles, losdeterioros);

            CollectionAssert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod]
        public void TestObtieneLongitudPromedioTramosPorDeterioro()
        {
            Calle[] calles = new Calle[4];
            calles[0] = new Calle { Longitud = 200, Tramo = 25, Deterioro = "Hundimiento" };
            calles[1] = new Calle { Longitud = 150, Tramo = 40, Deterioro = "Agrietamiento" };
            calles[2] = new Calle { Longitud = 300, Tramo = 60, Deterioro = "Ondulamiento" };
            calles[3] = new Calle { Longitud = 120, Tramo = 30, Deterioro = "Hundimiento" };
        }

    }
}
