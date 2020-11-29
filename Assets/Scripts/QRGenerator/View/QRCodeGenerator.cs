using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using Compression;
using Compression.Model;

namespace QRGenerator.View{
	public class QRCodeGenerator : MonoBehaviour, IQRCodeGenerator{
        private const int TEXTUREHEIGHT = 256;
        private const int TEXTUREWIDTH = 256;       
        public RawImage rawImage;
        private IStringCompression stringCompressor;

		public void GenerateQR(string qrData){
			stringCompressor = new StringCompression();
			if(String.Compare(qrData,"")!=0){
				Debug.Log(qrData);
				rawImage.texture = GenerateTexture(stringCompressor.Compress(qrData));
			}
		}

		private Color32[] Encode(string textForEncoding,int width, int height){
			var writer = new BarcodeWriter{
				Format = BarcodeFormat.QR_CODE,
				Options = new QrCodeEncodingOptions {
					Height = height,
					Width = width
				}
			};
			return writer.Write(textForEncoding);
		}

		private Texture2D GenerateTexture(string text) {
		  	var encoded = new Texture2D (TEXTUREWIDTH, TEXTUREHEIGHT);
		  	var color32 = Encode(text, encoded.width, encoded.height);
		  	encoded.SetPixels32(color32);
		  	encoded.Apply();
	  		return encoded;
		}
	}	
}

