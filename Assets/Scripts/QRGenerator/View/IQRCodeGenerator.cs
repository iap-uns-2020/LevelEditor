using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QRGenerator.View
{
    public interface IQRCodeGenerator
    {
        void GenerateQR(string qrData);
    }
}