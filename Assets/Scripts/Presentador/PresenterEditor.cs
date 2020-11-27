using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterEditor : IPresenterEditor
{
    private ILogicEditor logic;

    public PresenterEditor()
    {
        logic = new LogicEditor();
    }
 
    public void InitializeMap(int row, int column)
    {
        logic.InitializeMap(row, column);
    }

    public void SetElementMatrix(int positionRow, int positionColumn, char typeElement)
    {
        logic.SetElementMatrix(positionRow, positionColumn, typeElement);
    }

    public string GenerationMap(){
        return logic.GenerationMap();
    }

    public void SetColumn(int column)
    {
        logic.SetColumn(column);
    }

    public void SetRow(int row)
    {
        logic.SetRow(row);
    }
}
