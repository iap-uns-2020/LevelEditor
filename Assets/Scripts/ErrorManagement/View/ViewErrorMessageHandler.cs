using ErrorManagement.Presenter;
using PanelManager.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErrorManagement.View
{
    public class ViewErrorMessageHandler : MonoBehaviour, IViewErrorMessageHandler
    {
    	private const string MSGHEADER = "Mapa inválido: Cuidado! ";
    	private IPresenterErrorMessageHandler presenterErrorMessage;
        public GameObject IPanelManager;
        private IPanelManager panelManager;    
        public Text messageError;
        public Slider sliderRow, sliderColumn;
        
        
        void Start()
        {
            panelManager = IPanelManager.GetComponent<IPanelManager>();
            presenterErrorMessage = new PresenterErrorMessageHandler();
            InitializeMapErrorMessage();
        }

        public bool ErrorMessage()
        {
            string message = presenterErrorMessage.CheckErrors();
            bool validMap = presenterErrorMessage.GetValidMap();

            if (validMap)
                panelManager.ActivePanelQR();
            else
            {
                panelManager.ActivePanelWarning();
                messageError.text = MSGHEADER + message;
            }

            return validMap;
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