using ErrorManagement.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErrorManagement.Presenter
{
    public class PresenterErrorMessageHandler : IPresenterErrorMessageHandler
    {
        private ILogicErrorMessageHandler logicError;

        public PresenterErrorMessageHandler()
        {
            logicError = new LogicErrorMessageHandler();
        }

        public void InitializeMap(int row, int column)
        {
            logicError.InitializeMap(row, column);
        }

        public void SetElement(int row, int column, char element)
        {
            logicError.SetElement(row, column, element);
        }

        public string CheckErrors()
        {
            return logicError.CheckErrors();
        }

        public bool GetValidMap()
        {
            return logicError.GetValidMap();
        }
    }
}
