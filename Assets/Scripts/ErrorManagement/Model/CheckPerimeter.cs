using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErrorManagement.Model
{
    public class CheckPerimeter : MapValidation
    {
        private const char WALLCODE = 'w';

        public bool CheckMap(int row, int column, char[,] boardLogic)
        {
            bool validMap = CheckRowWall(row, column, boardLogic) && CheckColumnWall(row, column, boardLogic);

            return validMap;
        }

        public string GetErrorMessage()
        {
            return "Perimetro no cerrado";
        }


        private bool CheckRowWall(int row, int column, char[,] boardLogic)
        {
            bool validRow1 = true;
            bool validRow2 = true;

            for (int j = 0; j < column && validRow1 && validRow2; j++)
            {
                validRow1 = boardLogic[0, j] == WALLCODE;
                validRow2 = boardLogic[row - 1, j] == WALLCODE;
            }

            return validRow1 && validRow2;
        }

        private bool CheckColumnWall(int row, int column, char[,] boardLogic)
        {
            bool validColumn1 = true;
            bool validColumn2 = true;
            int rowAct = 1;

            while (rowAct < row && validColumn1 && validColumn2)
            {
                validColumn1 = boardLogic[rowAct, 0] == WALLCODE;
                validColumn2 = boardLogic[rowAct, column - 1] == WALLCODE;
                rowAct++;
            }

            return validColumn1 && validColumn2;
        }
    }
}