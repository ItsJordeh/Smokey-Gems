using UnityEngine;
using UnityEditor;
using System.Collections;

public class MenuToolManager : MonoBehaviour 
{
	[MenuItem("Status Bars/Add Manager")]
	private static void AddManager()
	{
		Object Manager = Instantiate (Resources.Load ("Status Bars Manager"));
		Manager.name = "Status Bars Manager";
	}
//	[MenuItem("Status Bars/Tutorial")]
//	private static void Tutorial()
//	{
		//Application.OpenURL ();
//	}
	[MenuItem("Status Bars/Document (Includes How-to)")]
	private static void Document()
	{
		Selection.activeObject=AssetDatabase.LoadMainAssetAtPath("Assets/Status Bars/"+"Read Me"+".txt");
	}
	[MenuItem("Status Bars/Our Twitter")]
	private static void Twitter()
	{
		Application.OpenURL ("https://twitter.com/LowEyedStudios");
	}
}