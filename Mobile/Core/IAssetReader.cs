using System;
using System.Threading.Tasks;
using System.IO;
using Android;

namespace Core
{
	public interface IAssetReader
	{
		string ReadFileAsString(string fileName);
	}

}

