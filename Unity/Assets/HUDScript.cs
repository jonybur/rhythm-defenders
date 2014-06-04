using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	PlayerScript player;
	public GUIStyle estilo;

	// Update is called once per frame
	void Awake()
	{
		player = GameObject.Find("player").GetComponent("PlayerScript") as PlayerScript;
	}

	void OnGUI () {
		// pixeles de iphone

		GUI.Label(new Rect(0, 10, 610, 50), "SCORE " + player.puntaje, estilo);

	}
}
