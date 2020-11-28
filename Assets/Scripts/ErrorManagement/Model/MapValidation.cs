using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErrorManagement.Model
{
    public interface MapValidation
    {
        bool CheckMap(int row, int column, char[,] boardLogic);
        string GetErrorMessage();
    }
}