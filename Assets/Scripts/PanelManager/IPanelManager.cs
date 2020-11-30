using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanelManager.View
{
    public interface IPanelManager
    {
        void ActivePanelQR();
        void ActivePanelWarning();
        void ShowMainPanelWarning();
        void ShowMainPanelQR();
    }
}