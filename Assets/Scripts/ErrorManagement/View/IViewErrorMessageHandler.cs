using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErrorManagement.View
{
    public interface IViewErrorMessageHandler{
        bool ErrorMessage();
        void SetElement(int row, int column, char element);
        void InitializeMapErrorMessage();
        void ShowMainPanel();
    }
}