using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.Model
{
    public interface ILogicEditor
    {
        void InitializeMap(int row, int column);
        void SetElementMatrix(int positionRow, int positionColumn, char typeElement);
        string GenerationMap();
        void SetRow(int row);
        void SetColumn(int column);
    }
}