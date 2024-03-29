﻿using UnityEngine;
using System.Collections;

public class PlanetaScript : MonoBehaviour {	
	GetSpectrumScript a;
	public float TamanioInicial;
	
	// Use this for initialization
	void Awake() {
		try
		{
			a = (GetSpectrumScript) GameObject.Find ("audio").GetComponent("GetSpectrumScript");
		}
		catch
		{
			a = (GetSpectrumScript) GameObject.Find ("audio_debug").GetComponent("GetSpectrumScript");
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = new Vector2(TamanioInicial + a.curValues[3] * 0.2f,
		                                        TamanioInicial + a.curValues[3] * 0.2f);

		this.transform.Translate(0,-1*Time.deltaTime, 0);


		if (this.transform.position.y + this.renderer.bounds.size.y < -Camera.main.orthographicSize)
		{
			Destroy (this.gameObject);
		}
	}

}
