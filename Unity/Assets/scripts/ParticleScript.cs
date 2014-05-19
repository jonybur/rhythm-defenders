using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	void Start ()
	{
		particleSystem.renderer.sortingLayerName = "stars";
	}
}
