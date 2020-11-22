using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterEditor : IPresenterEditor
{
    private ILogicEditor logic;

    public PresenterEditor(int row, int column)
    {
        logic = new LogicEdtor(row, column);
    }
   
    public void InitializeMap(int row, int column)
    {
        logic.InitializeMap(row, column);
    }

    public void SetElementMatrix(int positionRow, int positionColumn, char typeElement)
    {
        logic.SetElementMatrix(positionRow, positionColumn, typeElement);
    }

    public bool ValidationMap()
    {
        return logic.ValidationMap();
    }

    public string GenerationMap(){
        return logic.GenerationMap();
    }
}
