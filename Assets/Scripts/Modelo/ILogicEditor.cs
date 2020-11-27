using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogicEditor
{
    void InitializeMap(int row, int column);
    void SetElementMatrix(int positionRow, int positionColumn, char typeElement);
    string GenerationMap();
   // string CheckPerimeter();
    //string CheckGoal();
    //string CheckBall();
    int GetRow();
    int GetColumn();
    char[,] GetMatrix();
    void SetRow(int row);
    void SetColumn(int column);
}