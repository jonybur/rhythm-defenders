﻿using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {

	// aca dejo funciones que son comunes para todos los aliens

	public virtual void Update () {
		if (this.transform.position.y + this.renderer.bounds.size.y < -Camera.main.orthographicSize)
		{
			Destroy (this.gameObject);
		}

		BoxCollider2D coll = this.collider2D as BoxCollider2D;
		coll.size = this.renderer.bounds.size;
	}
}
