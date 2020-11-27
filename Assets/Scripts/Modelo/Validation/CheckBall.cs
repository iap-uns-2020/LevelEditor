using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBall : MapValidation
{
    private const char BALLCODE = 'b';

    public bool CheckMap(int row,int column, char[,] boardLogic)
    {
        int numberBall = 0;
        
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
        return "d";
    }
}
