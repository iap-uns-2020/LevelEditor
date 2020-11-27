﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPresenterEditor
{
    void InitializeMap(int fila, int columna);
    void SetElementMatrix(int posFila, int posColumna, char tipoDeElemento);
    bool ValidationMap();
    string GenerationMap();
    void SetColumn(int column);
    void SetRow(int row);
    int GetRow();
    int GetColumn();
    char[,] GetMatrix();


}
