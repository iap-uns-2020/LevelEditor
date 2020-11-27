using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicEditor : ILogicEditor
{
    private char[,] boardLogic;
    private int row, column;
    private const char SEPARATOR = '#';
    private const char FREESLOTCODE = 'f';
    private const char WALLCODE = 'w';
    private const char BALLCODE = 'b';
    private const char GOALCODE = 'g';
   // private MapValidation checkGoal, checkBall, checkPerimeter;

    public LogicEditor()
    {
       // InitializeMap(row, column);
     
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
                boardLogic[i, j] = FREESLOTCODE;
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

   
    public void SetRow(int row)
    {
        this.row = row;
        //Debug.Log(this.row);
    }

    public void SetColumn(int column)
    {
        this.column = column;
    }

    public int GetRow()
    {
        return row;
    }

    public int GetColumn()
    {
        return column;
    }

    public char[,] GetMatrix()
    {
        return boardLogic;
    }
}
