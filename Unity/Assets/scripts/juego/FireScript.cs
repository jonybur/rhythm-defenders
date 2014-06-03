using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	GetSpectrumScript a;
	float startSize;
	float startLifetime;

	void Awake ()
	{
		try
		{
			a = (GetSpectrumScript) GameObject.Find ("audio").GetComponent("GetSpectrumScript");
		}
		catch
		{
			a = (GetSpectrumScript) GameObject.Find ("audio_debug").GetComponent("GetSpectrumScript");
		}
		this.particleSystem.renderer.sortingLayerName = "characters";
		startSize = this.particleSystem.startSize;
		startLifetime = this.particleSystem.startLifetime;
	}

	void Update()
	{
		this.particleSystem.startSize = startSize + a.curValues[0] * 0.1f;
		this.particleSystem.startLifetime = startLifetime + a.curValues[1] * 0.05f;
	}
}
