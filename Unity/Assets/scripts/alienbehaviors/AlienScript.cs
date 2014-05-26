using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {

	// aca dejo funciones que son comunes para todos los aliens

	bool chequeado;

	public virtual void Awake()
	{
		chequeado = false;
	}

	public virtual void Update () {

		if (this.transform.position.y < Camera.main.orthographicSize/2 && !chequeado)
		{
			chequeado = true;
			if (Random.Range(1,40) == 1)
			{
				/* se vuelve kamikaze */
				AlienKamikazeScript kamikaze = this.GetComponent("AlienKamikazeScript") as AlienKamikazeScript;
				kamikaze.enabled = true;
			}
		}

		/* TODO: hacer que cuando llegue a cierto punto, se ponga en grilla */

		if (this.transform.position.y + this.renderer.bounds.size.y < -Camera.main.orthographicSize)
		{
			Destroy (this.gameObject);
		}

		BoxCollider2D coll = this.collider2D as BoxCollider2D;
		coll.size = this.renderer.bounds.size;
	}
}
