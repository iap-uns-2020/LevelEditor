using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicErrorMessageHandler
{
    private const char FREESLOTCODE = 'f';
    private List<MapValidation> validators;
    private int row, column;
    private char[,] boardLogic;

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

        foreach (MapValidation validator in validators)
            if (validator.CheckMap(row, column, boardLogic))
            {
                output += validator.GetErrorMessage();
            }

        return output;
    }

    public void InitializeMap(int row, int column)
    {
        Debug.Log("ADSAD");
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

        //mostrarMapa();


    }


    private void mostrarMapa()
    {
        string s = "";
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                s += boardLogic[i, j];
            }
        }
        Debug.Log("ERROR MANAGER: " + s);
    }

    public void SetElement(int row, int column, char element)
    {
        boardLogic[row, column] = element;
        mostrarMapa();

    }

   
}
