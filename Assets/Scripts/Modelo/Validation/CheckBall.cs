using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBall : MapValidation
{
    private const char BALLCODE = 'b';
    private int numberBall;
    public bool CheckMap(int row,int column, char[,] boardLogic)
    {
        numberBall = 0;
        
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (boardLogic[i, j] == BALLCODE)
                    numberBall++;
            }
        }

        return numberBall == 1;
    }

    public string GetErrorMessage()
    {
        string message =""
            ;

        if (numberBall > 1)
            message += "Muchas pelotas. ";
        else
            message += "No hay pelota. ";

        return message;
    }
}
