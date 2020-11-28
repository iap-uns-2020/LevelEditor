using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErrorManagement.Model
{
    public interface ILogicErrorMessageHandler
    {
        string CheckErrors();
        void InitializeMap(int row, int column);
        bool GetValidMap();
        void SetElement(int row, int column, char element);
    }
}