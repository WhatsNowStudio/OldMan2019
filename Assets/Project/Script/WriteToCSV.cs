using UnityEngine;
using System.Collections;
using System.IO;

public class WriteToCSV : MonoBehaviour {
	public string filePath = "";
	string _c = "";

	public void ClearData() {
		_c = "";
	}
	
	public void ImportData(string c) {
		_c += c + "\r\n";
	}
	
	public void SaveData(string f) {
		filePath = Path.Combine (GetAndExternalStorageDirectory (), "OldmanVR/" + f);
		string d = Path.GetDirectoryName (filePath);
		if (Directory.Exists (d) == false)  Directory.CreateDirectory (d);
		if (File.Exists (filePath)) {
			File.SetAttributes (filePath, FileAttributes.Normal);
			File.Delete (filePath);
		}
		File.AppendAllText (filePath, _c, System.Text.Encoding.UTF8);
		if (Directory.Exists(f)) Application.OpenURL(f);
	}
	
	string GetAndExternalStorageDirectory()
	{
		return Application.dataPath;
	}
}
