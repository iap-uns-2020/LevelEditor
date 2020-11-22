using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentadorEditor : IPresentadorEditor
{
    private ILogicaEditor logica;

    public PresentadorEditor(int fila, int columna)
    {
        logica = new LogicaEditor(fila, columna);
    }
   
    public void InicializarMapa(int fila, int columna)
    {
        logica.InicializarMapa(fila, columna);
    }

    public void EstablecerElementoMatriz(int posFila, int posColumna, char tipoDeElemento)
    {
        logica.EstablecerElementoMatriz(posFila, posColumna, tipoDeElemento);
    }

    public bool ValidoMapa()
    {
        return logica.ValidoMapa();
    }

    public string GenerarCadena(){
        return logica.GenerarCadena();
    }
}
