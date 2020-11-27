using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGoal : MapValidation
{
    private const char GOALCODE = 'g';

    private int numberGoal;

    public bool CheckMap(int row, int column, char[,] boardLogic)
    {
        numberGoal = 0;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {                
                if (boardLogic[i, j] == GOALCODE)
                    numberGoal++;
            }
        }
 
        return numberGoal == 1;
    }

    public string GetErrorMessage()
    {
        string message = "";

        if (numberGoal > 1)
            message = "Muchas salidas. ";
        else
            message = "No hay salida. ";

        return message;
    }
}
