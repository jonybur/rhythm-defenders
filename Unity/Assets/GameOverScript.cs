﻿using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	public GUIStyle estilo;
	
	PlayerScript player;

	void Awake()
	{		
		player = GameObject.Find("player").GetComponent("PlayerScript") as PlayerScript;
	}
	void Start()
	{
		Time.timeScale = 0;
	}
	void OnGUI () {
		// pixeles de iphone
		
		GUI.Label(new Rect(0, 500, 610, 50), "SCORE " + player.puntaje, estilo);
		
	}
}
