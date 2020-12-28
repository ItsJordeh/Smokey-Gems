using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BarCreator))]
public class BarCreatorEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		BarCreator creator = (BarCreator)target;
		if (GUILayout.Button ("Create Bar")) 
		{
			creator.CreateBar();	
		}
	}
}