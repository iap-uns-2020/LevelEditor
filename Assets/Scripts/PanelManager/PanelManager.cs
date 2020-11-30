using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanelManager.View
{
    public class PanelManager : MonoBehaviour, IPanelManager
    {
        public GameObject panelWarning, QRCodeDisplay, editorPanel;

        public void ActivePanelQR()
        {
            QRCodeDisplay.SetActive(true);
            editorPanel.SetActive(false);
        }

        public void ActivePanelWarning()
        {
            panelWarning.SetActive(true);
            editorPanel.SetActive(false);
        }

        public void ShowMainPanelWarning()
        {
            panelWarning.SetActive(false);
            editorPanel.SetActive(true);
        }

        public void ShowMainPanelQR()
        {
            QRCodeDisplay.SetActive(false);
            editorPanel.SetActive(true);
        }
    }
}