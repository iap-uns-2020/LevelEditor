using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEditor : ILogicaEditor
{
    private char[,] tableroLogica;
    private int fila, columna;
    private const char STARTENDSYMBOL = '#';
    private const char MATRIXDIMENSIONSEPARATOR = '-';
    public LogicaEditor(int fila, int columna)
    {
        InicializarMapa(fila, columna);
    }


    public void InicializarMapa(int fila, int columna)
    {
        this.fila = fila;
        this.columna = columna;

        tableroLogica = new char[fila, columna];

        for (int i = 0; i <fila; i++)
        {
            for (int j = 0; j <columna; j++)
            {
                tableroLogica[i, j] = 'l';
            }
        }
    }

    public void EstablecerElementoMatriz(int posFila, int posColumna, char tipoDeElemento){
        tableroLogica[posFila,posColumna] = tipoDeElemento;
    }

    public string GenerarCadena(){
        string mapa = "";
        mapa+=STARTENDSYMBOL+""+fila+""+MATRIXDIMENSIONSEPARATOR+""+columna+""+STARTENDSYMBOL;
        for (int i = 0; i < fila; i++)
        {
            for (int j = 0; j < columna; j++)
            {
                mapa += tableroLogica[i, j];
            }
        }
        return mapa;
    }

    public bool ValidoMapa(){
        bool valido = false;
        int cantidadPelota = 0;
        int cantidadMeta = 0;

        for (int i = 0; i < fila; i++)
        {
            for (int j = 0; j < columna; j++)
            {
                if (tableroLogica[i, j] == 'p')
                    cantidadPelota++;
                else
                    if (tableroLogica[i, j] == 's')
                    cantidadMeta++;
            }
        }

        if (cantidadPelota == 1 && cantidadMeta == 1)
            valido = true;

        return valido;
    }

}
