using UnityEngine;
using System.Collections;

public class EffectScript : MonoBehaviour {
	
	GetSpectrumScript a;
	
	// Use this for initialization
	void Awake () {		
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
		
		switch (this.name)
		{
			case "efecto1":
				this.transform.localScale = new Vector2(1 + a.curValues[0] * 0.2f,
				                                        1 + a.curValues[0] * 0.2f);
				break;
			case "efecto2":
				this.transform.localScale = new Vector2(1 + a.curValues[1] * 0.2f,
				                                        1 + a.curValues[1] * 0.2f);
				break;
			case "efecto3":
				this.transform.localScale = new Vector2(1 + a.curValues[2] * 0.2f,
				                                        1 + a.curValues[2] * 0.2f);
				break;
		}
	}
}
