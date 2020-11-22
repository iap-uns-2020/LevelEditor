using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogicaEditor
{
    void InicializarMapa(int fila, int columna);
    void EstablecerElementoMatriz(int posFila, int posColumna, char tipoDeElemento);
    bool ValidoMapa();
    string GenerarCadena();

}
