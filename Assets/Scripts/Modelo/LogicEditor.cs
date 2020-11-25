﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicEdtor : ILogicEditor
{
    private char[,] boarLogic;
    private int row, column;
    private const char SEPARATOR = '#';

    public LogicEdtor(int row, int column)
    {
        InitializeMap(row, column);
    }


    public void InitializeMap(int row, int column)
    {
        this.row = row;
        this.column = column;

        boarLogic = new char[row, column];

        for (int i = 0; i <row; i++)
        {
            for (int j = 0; j <column; j++)
            {
                boarLogic[i, j] = 'f';
            }
        }
    }

    public void SetElementMatrix(int positionRow, int positionColumn, char typeElement){
        boarLogic[positionRow,positionColumn] = typeElement;
    }

    public string GenerationMap(){
        string mapa = "";
        mapa+=row+""+SEPARATOR+""+column+""+SEPARATOR;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                mapa += boarLogic[i, j];
            }
        }
        Debug.Log(mapa);
        return mapa;
    }

    public bool ValidationMap(){
        bool isValid = false;
        int numberBall = 0;
        int numberGoal = 0;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (boarLogic[i, j] == 'b')
                    numberBall++;
                else
                    if (boarLogic[i, j] == 'g')
                    numberGoal++;
            }
        }

        if (numberBall == 1 && numberGoal == 1)
            isValid = true;

        return isValid;
    }

}
