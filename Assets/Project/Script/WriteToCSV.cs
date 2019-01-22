using UnityEngine;
using System.Collections;
using System.IO;

public class WriteToCSV : MonoBehaviour {
	public string filePath = "";
	//public GameObject goFilePath;
	string _content = "";

	/*
	public void test () {
		ClearData ();
		for (int i=0; i<30; i++) {
			ImportData (string.Format ("Name: {0}, Score: {1}", i, (new System.Random ()).Next () % 100));
		}
		SaveData (string.Format ("WriteToCSV_{0}.csv", System.DateTime.Now.ToString ("yyyyMMddHHmmss")));
		Debug.Log (filePath);
		if (goFilePath != null) {
			goFilePath.GetComponent<UnityEngine.UI.Text> ().text = filePath;
		}
	}
	*/

	public void ClearData() {
		_content = "";
	}
	
	public void ImportData(string content) {
		_content += content + "\r\n";
	}
	
	public void SaveData(string fileName) {
		filePath = Path.Combine (GetAndExternalStorageDirectory (), "OldMan2019/" + fileName);
		if (Application.platform == RuntimePlatform.Android) {
			filePath = filePath.Replace (@"\", "/");
		}
		string folderPath = Path.GetDirectoryName (filePath);
		if (Directory.Exists (folderPath) == false) {
			Directory.CreateDirectory (folderPath);
		}
		if (File.Exists (filePath)) {
			File.SetAttributes (filePath, FileAttributes.Normal);
			File.Delete (filePath);
		}
		//File.AppendAllText (filePath, _content);
		File.AppendAllText (filePath, _content, System.Text.Encoding.UTF8);
	}
	
	string GetAndExternalStorageDirectory()
	{
		string path = "";
		if (Application.platform == RuntimePlatform.Android) {
			AndroidJavaClass androidEnvironment = new AndroidJavaClass ("android.os.Environment");
			using (AndroidJavaObject externalStorageDirectory = androidEnvironment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory")) {
				path = externalStorageDirectory.Call<string> ("getPath");
			}
		} else {
			//path = Path.GetTempPath();
			path = Application.persistentDataPath;
		}
		return path;
	}
}
