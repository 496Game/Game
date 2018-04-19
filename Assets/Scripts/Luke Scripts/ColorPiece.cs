using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : MonoBehaviour {

	public enum ColorType{
		YELLOW,
		PURPLE,
		RED,
		BLUE,
		GREEN,
		PINK,
		ANY,
		COUNT
	};

	[System.Serializable]
	public struct colorPiece
	{
		public ColorType color;
		public GameObject thePiece;
	}
	private GameObject thePiecee;
	public colorPiece[] colorPieces;
	private ColorType color;

	public int numColors{
		get{return colorPieces.Length;}
	}

	private ColorType Color{
		get{ return Color; }
		set{ SetColor(value);}
	}

	private Dictionary<ColorType, GameObject> colorPieceDict;
	// Use this for initialization

	void Awake(){
		thePiecee = gameObject;
		//Material mat = thePiecee.AddComponent<Material> () as Material;
		Destroy (thePiecee.GetComponent<Rigidbody> ());
		Destroy (thePiecee.GetComponent<BoxCollider> ());
		colorPieceDict = new Dictionary<ColorType, GameObject> ();
		for (int i = 0; i < colorPieces.Length; i++) {
			if (!colorPieceDict.ContainsKey (colorPieces [i].color)) {
				colorPieceDict.Add (colorPieces [i].color, colorPieces [i].thePiece);
			}
		}
	}

	public void SetColor(ColorType newColor){
		color = newColor;

		if (colorPieceDict.ContainsKey (newColor)) {

			thePiecee.GetComponent<Material>().color.Equals(colorPieceDict[newColor]);
		}
		//= colorPieceDict [newColor];
	}
}
