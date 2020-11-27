using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPresenterEditor
{
    void InitializeMap(int row, int column);
    void SetElementMatrix(int positionRow, int positionColumn, char typeElement);
    string GenerationMap();
    void SetColumn(int column);
    void SetRow(int row);

 }
