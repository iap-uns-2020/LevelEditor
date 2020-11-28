using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErrorManagement.Model
{
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
            return "El mapa debe tener una salida. ";
        }
    }
}