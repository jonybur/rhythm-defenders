using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	void Awake()
	{
		particleSystem.renderer.sortingLayerName = "explosiones";
	}

	void LateUpdate () {
		if (!particleSystem.IsAlive())
		{
			Destroy (this.gameObject);
		}
	}
}
