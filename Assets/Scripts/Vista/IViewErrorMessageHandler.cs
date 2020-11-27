using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IViewErrorMessageHandler
{
    void CreatePreseterErrorMesaage();
    bool ErrorMessage();
    void PanelMain();
    void SetElement(int row, int column, char element);
    void InitializeMapErrorMessage(int row, int column);
}
