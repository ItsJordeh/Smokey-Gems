using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AdvancedBarManager : MonoBehaviour {

	public enum Position{UpRight,UpLeft,DownRight,DownLeft};
	public string name;
	public Position position;
	public Vector2 defaultPosition;
	public bool useAdvancedPosition = false;
	public Vector2 advancedPosition;
	public Color color;
	public bool useTextures = false;
	public Texture2D fullTexture;
	public Texture2D backgroundTexture;
	[Range(0.0f,100.0f)]
	public float value;
	public Vector2 size;

	//Hidden
	[HideInInspector]
	public float hiddenvalue;
	[HideInInspector]
	public bool assigned=false;
	[HideInInspector]
	public Texture2D colorTex;
	[HideInInspector]
	public Texture2D backgroundColorTex;
	[HideInInspector]
	public bool aligned=false;
	[HideInInspector]
	public string lastPos;
	[HideInInspector]
	public string currentPos;
	[HideInInspector]
	public bool ListAdded = false;

	void Update () {
		if (Application.isEditor && !Application.isPlaying) {
			if (gameObject.transform.parent.name == "Status Bars Manager" && !assigned) {
				Debug.Log ("Added");
				assigned = true;
				name = GetComponentInParent<BarCreator> ().name;
				position = (Position)GetComponentInParent<BarCreator> ().position;
				color = new Color (GetComponentInParent<BarCreator> ().color.r, GetComponentInParent<BarCreator> ().color.g, GetComponentInParent<BarCreator> ().color.b, 255);
				value = GetComponentInParent<BarCreator> ().startingValue;
				size = GetComponentInParent<BarCreator> ().size;
			}
			gameObject.name = name;

			colorTex = (Texture2D)Resources.Load ("Bar(NoTexture)");
			backgroundColorTex = (Texture2D)Resources.Load ("EmptyBar");
			if (useAdvancedPosition) {
				defaultPosition = advancedPosition;
			}
			if (position == Position.UpRight && currentPos != "UpRight") {
				if (currentPos != null) {
					lastPos = currentPos;
					if (lastPos == "UpLeft")
						GetComponentInParent<BarCreator> ().UpLeft.Remove (gameObject);
					else if (lastPos == "DownRight")
						GetComponentInParent<BarCreator> ().DownRight.Remove (gameObject);
					else if (lastPos == "DownLeft")
						GetComponentInParent<BarCreator> ().DownLeft.Remove (gameObject);
				}
				for(int i = 0;i<GetComponentInParent<BarCreator> ().UpRight.Count;i++){
					if(GetComponentInParent<BarCreator> ().UpRight[i] == gameObject){
						ListAdded = true;
					}
				}
				if(!ListAdded)
					GetComponentInParent<BarCreator> ().UpRight.Add (gameObject);
				currentPos = "UpRight";
				if (lastPos == null)
					lastPos = currentPos;
			} else if (position == Position.UpLeft && currentPos != "UpLeft") {
				if (currentPos != null) {
					lastPos = currentPos;
					if (lastPos == "UpRight")
						GetComponentInParent<BarCreator> ().UpRight.Remove (gameObject);
					else if (lastPos == "DownRight")
						GetComponentInParent<BarCreator> ().DownRight.Remove (gameObject);
					else if (lastPos == "DownLeft")
						GetComponentInParent<BarCreator> ().DownLeft.Remove (gameObject);
				}
				for(int i = 0;i<GetComponentInParent<BarCreator> ().UpLeft.Count;i++){
					if(GetComponentInParent<BarCreator> ().UpLeft[i] == gameObject){
						ListAdded = true;
					}
				}
				if(!ListAdded)
					GetComponentInParent<BarCreator> ().UpLeft.Add (gameObject);
				currentPos = "UpLeft";
				if (lastPos == null)
					lastPos = currentPos;
			} else if (position == Position.DownRight && currentPos != "DownRight") {
				if (currentPos != null) {
					lastPos = currentPos;
					if (lastPos == "UpLeft")
						GetComponentInParent<BarCreator> ().UpLeft.Remove (gameObject);
					else if (lastPos == "UpRight")
						GetComponentInParent<BarCreator> ().UpRight.Remove (gameObject);
					else if (lastPos == "DownLeft")
						GetComponentInParent<BarCreator> ().DownLeft.Remove (gameObject);
				}
				for(int i = 0;i<GetComponentInParent<BarCreator> ().DownRight.Count;i++){
					if(GetComponentInParent<BarCreator> ().DownRight[i] == gameObject){
						ListAdded = true;
					}
				}
				if(!ListAdded)
					GetComponentInParent<BarCreator> ().DownRight.Add (gameObject);
				currentPos = "DownRight";
				if (lastPos == null)
					lastPos = currentPos;
			} else if (position == Position.DownLeft && currentPos != "DownLeft") {
				if (currentPos != null) {
					lastPos = currentPos;
					if (lastPos == "UpLeft")
						GetComponentInParent<BarCreator> ().UpLeft.Remove (gameObject);
					else if (lastPos == "DownRight")
						GetComponentInParent<BarCreator> ().DownRight.Remove (gameObject);
					else if (lastPos == "UpRight")
						GetComponentInParent<BarCreator> ().UpRight.Remove (gameObject);
				}
				for(int i = 0;i<GetComponentInParent<BarCreator> ().DownLeft.Count;i++){
					if(GetComponentInParent<BarCreator> ().DownLeft[i] == gameObject){
						ListAdded = true;
					}
				}
				if(!ListAdded)
					GetComponentInParent<BarCreator> ().DownLeft.Add (gameObject);
				currentPos = "DownLeft";
				if (lastPos == null)
					lastPos = currentPos;
			}

			if (position == Position.UpRight && !useAdvancedPosition) {
				if (GetComponentInParent<BarCreator> ().UpRight [0] == gameObject) {
					defaultPosition = new Vector2 (0.5f, -0.9f);
				} else {
					for (int i = 1; i<GetComponentInParent<BarCreator>().UpRight.Count; i++) {
						if (GetComponentInParent<BarCreator> ().UpRight [i] == gameObject) {
							defaultPosition = new Vector2 (0.5f, (-0.9f) + (0.2f * i));
						}
					}
				}
			} else if (position == Position.UpLeft && !useAdvancedPosition) {
				if (GetComponentInParent<BarCreator> ().UpLeft [0] == gameObject) {
					defaultPosition = new Vector2 (-1f, -0.9f);
				} else {
					for (int i = 1; i<GetComponentInParent<BarCreator>().UpLeft.Count; i++) {
						if (GetComponentInParent<BarCreator> ().UpLeft [i] == gameObject) {
							defaultPosition = new Vector2 (-1f, (-0.9f) + (0.2f * i));
						}
					}
				}
			} else if (position == Position.DownRight && !useAdvancedPosition) {
				if (GetComponentInParent<BarCreator> ().DownRight [0] == gameObject) {
					defaultPosition = new Vector2 (0.5f, 0.75f);
				} else {
					for (int i = 1; i<GetComponentInParent<BarCreator>().DownRight.Count; i++) {
						if (GetComponentInParent<BarCreator> ().DownRight [i] == gameObject) {
							defaultPosition = new Vector2 (0.5f, 0.75f - (0.2f * i));
						}
					}
				}
			} else if (position == Position.DownLeft && !useAdvancedPosition) {
				if (GetComponentInParent<BarCreator> ().DownLeft [0] == gameObject) {
					defaultPosition = new Vector2 (-1f, 0.75f);
				} else {
					for (int i = 1; i<GetComponentInParent<BarCreator>().DownLeft.Count; i++) {
						if (GetComponentInParent<BarCreator> ().DownLeft [i] == gameObject) {
							defaultPosition = new Vector2 (-1f, 0.75f - (0.2f * i));
						}
					}
				}
			}
		}
		hiddenvalue = value / 100;
	}
	void OnGUI () {
		if (!useAdvancedPosition && !useTextures) {
			if (currentPos == "UpRight" || currentPos == "DownRight") {
				GUI.BeginGroup (new Rect ((Screen.width / 2) + ((Screen.width / 2) * defaultPosition.x), (Screen.height / 2) + ((Screen.height / 2) * defaultPosition.y), (Screen.width / 2) * size.x, (Screen.height / 2) * size.y));
				GUI.color = color;
				GUI.DrawTexture (new Rect (0, 0, (Screen.width / 2) * size.x, (Screen.height / 2) * size.y), colorTex);
				GUI.BeginGroup (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y));
				GUI.DrawTexture (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y), backgroundColorTex);
				GUI.EndGroup ();
				GUI.EndGroup ();
			} else {
				GUI.BeginGroup (new Rect ((Screen.width / 2) + ((Screen.width / 2) * defaultPosition.x), (Screen.height / 2) + ((Screen.height / 2) * defaultPosition.y), (Screen.width / 2) * size.x, (Screen.height / 2) * size.y));
				GUI.color = color;
				GUI.DrawTexture (new Rect (0, 0, (Screen.width / 2) * size.x, (Screen.height / 2) * size.y), backgroundColorTex);
				GUI.BeginGroup (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y));
				GUI.DrawTexture (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y), colorTex);
				GUI.EndGroup ();
				GUI.EndGroup ();
			}
		}
		if (!useAdvancedPosition && useTextures) {
			GUI.BeginGroup (new Rect ((Screen.width / 2) + ((Screen.width / 2) * defaultPosition.x), (Screen.height / 2) + ((Screen.height / 2) * defaultPosition.y), (Screen.width / 2) * size.x, (Screen.height / 2) * size.y));
			GUI.DrawTexture (new Rect (0, 0, (Screen.width / 2) * size.x, (Screen.height / 2) * size.y), backgroundTexture);
			GUI.BeginGroup (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y));
			GUI.DrawTexture (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y), fullTexture);
			GUI.EndGroup ();
			GUI.EndGroup ();
		}
		if (useAdvancedPosition && !useTextures) {
			if (currentPos == "UpRight" || currentPos == "DownRight") {
				GUI.BeginGroup (new Rect ((Screen.width / 2) + ((Screen.width / 2) * advancedPosition.x), (Screen.height / 2) + ((Screen.height / 2) * advancedPosition.y), (Screen.width / 2) * size.x, (Screen.height / 2) * size.y));
				GUI.color = color;
				GUI.DrawTexture (new Rect (0, 0, (Screen.width / 2) * size.x, (Screen.height / 2) * size.y), colorTex);
				GUI.BeginGroup (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y));
				GUI.DrawTexture (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y), backgroundColorTex);
				GUI.EndGroup ();
				GUI.EndGroup ();
			} else {
				GUI.BeginGroup (new Rect ((Screen.width / 2) + ((Screen.width / 2) * advancedPosition.x), (Screen.height / 2) + ((Screen.height / 2) * advancedPosition.y), (Screen.width / 2) * size.x, (Screen.height / 2) * size.y));
				GUI.color = color;
				GUI.DrawTexture (new Rect (0, 0, (Screen.width / 2) * size.x, (Screen.height / 2) * size.y), backgroundColorTex);
				GUI.BeginGroup (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y));
				GUI.DrawTexture (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y), colorTex);
				GUI.EndGroup ();
				GUI.EndGroup ();
			}
		}
		if (useAdvancedPosition && useTextures) {
			GUI.BeginGroup (new Rect ((Screen.width / 2) + ((Screen.width / 2) * advancedPosition.x), (Screen.height / 2) + ((Screen.height / 2) * advancedPosition.y), (Screen.width / 2) * size.x, (Screen.height / 2) * size.y));
			GUI.DrawTexture (new Rect (0, 0, (Screen.width / 2) * size.x, (Screen.height / 2) * size.y), backgroundTexture);
			GUI.BeginGroup (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y));
			GUI.DrawTexture (new Rect (0, 0, ((Screen.width / 2) * size.x) * hiddenvalue, (Screen.height / 2) * size.y), fullTexture);
			GUI.EndGroup ();
			GUI.EndGroup ();
		}

	}
	// void OnDestroy(){
	// 	if (currentPos == "UpRight") {
	// 		GetComponentInParent<BarCreator>().UpRight.Remove(gameObject);
	// 	}else if (currentPos == "UpLeft") {
	// 		GetComponentInParent<BarCreator>().UpLeft.Remove(gameObject);
	// 	}else if (currentPos == "DownRight") {
	// 		GetComponentInParent<BarCreator>().DownRight.Remove(gameObject);
	// 	}else if (currentPos == "DownLeft") {
	// 		GetComponentInParent<BarCreator>().DownLeft.Remove(gameObject);
	// 	}
	// }
}
