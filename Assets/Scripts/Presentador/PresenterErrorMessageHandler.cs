using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterErrorMessageHandler : IPresenterErrorMessageHandler
{
    private LogicErrorMessageHandler logicError;

    public PresenterErrorMessageHandler()
    {
       logicError = new LogicErrorMessageHandler();
    }

    public void InitializeMap(int row,int column)
    {
        logicError.InitializeMap(row, column);
    }

    public void SetElement(int row, int column, char element)
    {
        logicError.SetElement(row, column, element);
    }

    public string CheckErrors()
    {
        return logicError.CheckErrors();
    }
}
