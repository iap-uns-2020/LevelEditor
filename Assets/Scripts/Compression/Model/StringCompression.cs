using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;

namespace Compression.Model{
	public class StringCompression : IStringCompression{

		private const char WALLCODE = 'w';
		private const char BALLCODE = 'b';
		private const char FREECODE = 'f';
		private const char HOLECODE = 'h';
		private const char GOALCODE = 'g';
		private const char SEPARATOR = '#';

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
			string[] splitted = compressedStr.Split(SEPARATOR);
			compressedStr = splitted[2];
			
			while(i<compressedStr.Length){
				current = compressedStr[i];
				decompressedStr+=current;
				while(j<compressedStr.Length && InvalidChar(compressedStr[j])){
					toInt+=compressedStr[j];
					j++;
				}
				if(string.Compare(toInt,"")!=0){
					decompressedStr+= AddRepetitions(current,Int16.Parse(toInt));
					toInt = "";
				}
				
				i=j;
				j=i+1;
			}
			return splitted[0]+SEPARATOR+splitted[1]+SEPARATOR+decompressedStr;
		}

		private bool InvalidChar(char c){
			return c!=WALLCODE && c!=FREECODE && c!= HOLECODE && c!=BALLCODE && c!=GOALCODE;
		}

		private string AddRepetitions(char toAdd, int repetitions){
			string output = "";
			for(int i=0; i<repetitions;i++)
				output+=toAdd;
			return output;
		}
	}		
}

