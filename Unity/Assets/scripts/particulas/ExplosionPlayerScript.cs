using UnityEngine;
using System.Collections;

public class ExplosionPlayerScript : MonoBehaviour {
	
	void Awake()
	{
		particleSystem.renderer.sortingLayerName = "explosiones2";
	}
	
	void LateUpdate () {
		if (!particleSystem.IsAlive())
		{
			Destroy (this.gameObject);
		}
	}
}