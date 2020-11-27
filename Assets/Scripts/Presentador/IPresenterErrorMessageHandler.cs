using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPresenterErrorMessageHandler
{
    void InitializeMap(int row, int column);
    void SetElement(int row, int column, char element);
    string CheckErrors();
    bool GetValidMap();
}
