using ErrorManagement.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErrorManagement.View
{
    public class ViewErrorMessageHandler : MonoBehaviour, IViewErrorMessageHandler
    {
        public GameObject panelWarning, QRCodeDisplay, editorPanel;
        public Text messageError;
        public Slider sliderRow, sliderColumn;
        private IPresenterErrorMessageHandler presenterErrorMessage;
        
        void Start()
        {
            presenterErrorMessage = new PresenterErrorMessageHandler();
            InitializeMapErrorMessage();
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

        public void InitializeMapErrorMessage()
        {
            int row = (int)sliderRow.value;
            int column = (int)sliderColumn.value;
            presenterErrorMessage.InitializeMap(row, column);
        }

    }
}