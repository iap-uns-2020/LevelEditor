using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Compression{
	public interface IStringCompression{
		string Compress(string str);
		string Decompress(string str);
	}		
}

