using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Celula
{
    Celula direita, abaixo;
    int linha, coluna;
    double? info;
    
    public Celula(int l, int co, double? i, Celula d, Celula a)
    {
        info = i;
        linha = l;
        coluna = co;
        direita = d;
        abaixo = a;
    }

    public Celula Direita
    {
        get => direita;

        set => direita = value;
    }
    public Celula Abaixo
    {
        get => abaixo;

        set => abaixo = value;
    }
    public int Linha
    {
        get => linha;

        set => linha = value;
    }
    public int Coluna
    {
        get => coluna;

        set => coluna = value;
    }
    public double? Info
    {
        get => info;
    }
}

