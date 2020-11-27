﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogicErrorMessageHandler
{
    string CheckErrors();
    void InitializeMap(int row, int column);
    bool GetValidMap();
    void SetElement(int row, int column, char element);
}
