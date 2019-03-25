using System;
public class Celula<Dado> where Dado : IComparable<Dado>
{ 
    Dado info;
    Celula<Dado> prox;

    public Celula(Dado info, Celula<Dado> prox)
    {
        Info = info;
        Prox = prox;
    }

    public Dado Info
    {
        get { return info;  }
        set
        {
            if (value != null)
               info = value;
        }
    }

    public Celula<Dado> Prox
    {
        get => prox;
        set => prox = value;
    }
}

