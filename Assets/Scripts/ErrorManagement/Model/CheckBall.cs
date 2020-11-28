using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErrorManagement.Model
{
    public class CheckBall : MapValidation
    {
        private const char BALLCODE = 'b';
        private int numberBall;
        public bool CheckMap(int row, int column, char[,] boardLogic)
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
            return "El mapa debe tener una bola. ";
        }
    }
}