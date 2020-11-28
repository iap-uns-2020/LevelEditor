using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErrorManagement.Model
{
    public class LogicErrorMessageHandler : ILogicErrorMessageHandler
    {
        private const char FREESLOTCODE = 'f';
        private List<MapValidation> validators;
        private int row, column;
        private char[,] boardLogic;
        private bool validMap;

        public LogicErrorMessageHandler()
        {
            validators = new List<MapValidation>();
            validators.Add(new CheckBall());
            validators.Add(new CheckGoal());
            validators.Add(new CheckPerimeter());
        }

        public string CheckErrors()
        {
            string output = "";
            validMap = true;
            foreach (MapValidation validator in validators)
                if (!validator.CheckMap(row, column, boardLogic))
                {
                    validMap = false;
                    output += validator.GetErrorMessage();
                }
            return output;
        }

        public void InitializeMap(int row, int column)
        {
            this.row = row;
            this.column = column;
            boardLogic = new char[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    boardLogic[i, j] = FREESLOTCODE;
                }
            }
        }

        public bool GetValidMap()
        {
            return validMap;
        }

        public void SetElement(int row, int column, char element)
        {
            boardLogic[row, column] = element;
        }


    }
}