using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;

namespace Compression{
	public class StringCompression : IStringCompression{

		public string Compress(string str){
			string compressed = "";
			int consecutives=0;
			int i=0;
			int j=1;
			char current;
			while(i<str.Length){
				current = str[i];
				compressed+=current;
				while(j<str.Length && str[j]==current){
					consecutives++;
					j++;
				}
				if(consecutives!=0){
					compressed+=consecutives;
					consecutives=0;
				}

				i=j;
				j=i+1;
			}
			return compressed;
		}

		public string Decompress(string compressedStr){
			int i=0;
			int j=1;
			char current;
			string decompressedStr="";
			string toInt = "";
			while(i<compressedStr.Length){
				current = compressedStr[i];
				decompressedStr+=current;
				while(j<compressedStr.Length && InvalidChar(compressedStr[j])){
					toInt+=compressedStr[j];
					j++;
				}
				if(string.Compare(toInt,"")!=0)
					decompressedStr+= AddRepetitions(current,Int16.Parse(toInt));
				toInt = "";
				i=j;
				j=i+1;
			}
			return decompressedStr;
		}

		private bool InvalidChar(char c){
			return c!='m' && c!='l' && c!= 'h' && c!='p' && c!='s';
		}

		private string AddRepetitions(char toAdd, int repetitions){
			string output = "";
			for(int i=0; i<repetitions;i++)
				output+=toAdd;
			return output;
		}
	}		
}

