using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessageHandler : MonoBehaviour
{
    public GameObject panelWarning, QRCodeDisplay, editorPanel;
    public Text messageError;

    //private VistaEditor vistaEditor;

    //private int row;
    //private int column;
    //private char[,] matrix;

    private PresenterErrorMessageHandler presenterErrorMessage;

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
        bool valid = true;
        if (!message.Equals(""))
            QRCodeDisplay.SetActive(true);
        else
        {
            valid = false;
            Debug.Log("entreeeea");
            panelWarning.SetActive(true);
            messageError.text = "Mapa invalido: " + message;
        }
        return valid;
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
        Debug.Log("filas: " + row + "columnas: " + column);
        presenterErrorMessage.InitializeMap(row, column);
        
    }

}
