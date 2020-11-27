using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewErrorMessageHandler : MonoBehaviour, IViewErrorMessageHandler
{
    public GameObject panelWarning, QRCodeDisplay, editorPanel;
    public Text messageError;
    private IPresenterErrorMessageHandler presenterErrorMessage;

    void Start()
    {       
        
    }

    public void CreatePreseterErrorMesaage()
    {
        presenterErrorMessage = new PresenterErrorMessageHandler();
    }

   public bool ErrorMessage()
    {
        string message = presenterErrorMessage.CheckErrors();
        bool validMap = presenterErrorMessage.GetValidMap();

        if (validMap)
            QRCodeDisplay.SetActive(true);
        else
        {
            panelWarning.SetActive(true);
            messageError.text = "Mapa invalido: Cuidado! " + message;
        }

        return validMap;

    }

    public void PanelMain()
    {
        QRCodeDisplay.SetActive(false);
        panelWarning.SetActive(false);
        editorPanel.SetActive(true);
    }

    public void SetElement(int row, int column, char element)
    {
        presenterErrorMessage.SetElement(row, column, element);
    }

    public void InitializeMapErrorMessage(int row, int column)
    {
      presenterErrorMessage.InitializeMap(row, column);      
    }

}
