using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicEdtor : ILogicEditor
{
    private char[,] boardLogic;
    private int row, column;
    private const char SEPARATOR = '#';
    private const char FLOOTCODE = 'f';
    private const char WALLCODE = 'w';
    private const char BALLCODE = 'b';
    private const char GOALCODE = 'g';

    public LogicEdtor(int row, int column)
    {
        InitializeMap(row, column);
    }


    public void InitializeMap(int row, int column)
    {
        this.row = row;
        this.column = column;

        boardLogic = new char[row, column];

        for (int i = 0; i <row; i++)
        {
            for (int j = 0; j <column; j++)
            {
                boardLogic[i, j] = FLOOTCODE;
            }
        }
    }

    public void SetElementMatrix(int positionRow, int positionColumn, char typeElement){
        boardLogic[positionRow,positionColumn] = typeElement;
    }

    public string GenerationMap(){
        string mapa = "";
        mapa+=row+""+SEPARATOR+""+column+""+SEPARATOR;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                mapa += boardLogic[i, j];
            }
        }
        Debug.Log(mapa);
        return mapa;
    }

    public bool CheckRowWall()
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

    public bool CheckColumnWall()
    {
        bool validColumn1 = true;
        bool validColumn2 = true;
        int rowAct = 1;

        while(rowAct < row && validColumn1 && validColumn2)
        {
            validColumn1 = boardLogic[rowAct, 0] == WALLCODE;
            validColumn2 = boardLogic[rowAct, column - 1] == WALLCODE;
            rowAct++;
        }

        return validColumn1 && validColumn2;
    }

    public bool ValidationMap(){
        bool isValid = false;
        int numberBall = 0;
        int numberGoal = 0;

        

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (boardLogic[i, j] == BALLCODE)
                    numberBall++;
                else
                    if (boardLogic[i, j] == GOALCODE)
                    numberGoal++;
            }
        }

        if (numberBall == 1 && numberGoal == 1 && CheckRowWall() && CheckColumnWall())
            isValid = true;

        return isValid;
    }

}
