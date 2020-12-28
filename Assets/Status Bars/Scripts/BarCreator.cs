using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class BarCreator : MonoBehaviour {

	public enum Position{UpRight,UpLeft,DownRight,DownLeft};
	public string name = "Name of bar here";
	public Position position;
	public Color color;
	[Range(0.0f,100.0f)]
	public float startingValue;
	public Vector2 size = new Vector2(1,1);

	[HideInInspector]
	public List<GameObject> UpRight = new List<GameObject>();
	[HideInInspector]
	public List<GameObject> UpLeft = new List<GameObject>();
	[HideInInspector]
	public List<GameObject> DownRight = new List<GameObject>();
	[HideInInspector]
	public List<GameObject> DownLeft = new List<GameObject>();
	
	public void CreateBar(){
		if (name != "") {
			GameObject Bar = (GameObject)Instantiate (Resources.Load ("Bar") as GameObject, size, Quaternion.identity);
			Bar.transform.parent = gameObject.transform;
		} else if (name == "") {
			Debug.LogError("Name was not typed in. Add a name to create a proper bar.");
		}
	}
}
