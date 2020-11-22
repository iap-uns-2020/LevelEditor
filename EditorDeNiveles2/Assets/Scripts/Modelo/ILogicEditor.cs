using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogicEditor
{
    void InitializeMap(int row, int column);
    void SetElementMatrix(int positionRow, int positionColumn, char typeElement);
    bool ValidationMap();
    string GenerationMap();

}
