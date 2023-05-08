using System;

class Calle
{
    //atributos de la clase
    private string deteriroro;
    private int longitud;
    private float tramo;

    //constructor de la clase

    public Calle()
    {
        longitud = 0;
        tramo = 0;
        deteriroro = string.Empty;
    }

    //Porpiedades de acceso de los atributos

    public int Longitud
    {
        get { return longitud; }
        set { longitud = value; }
    }

    public float Tramo
    {
        get { return tramo; }
        set { tramo = value; }
    }

    public string Deterioro
    {
        get { return deteriroro; }
        set { deteriroro = value; }
    }
}
}