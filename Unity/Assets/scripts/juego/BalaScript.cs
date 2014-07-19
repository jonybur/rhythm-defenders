using UnityEngine;
using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour {

	BoxCollider2D collider;
	
	void Awake()
	{
		collider = this.collider2D as BoxCollider2D;

        /* pequeño fix, en caso de que la imagen de la bala sea muy pequeña, se ajusta el collider para ser de un tamaño aceptable */
	    collider.size = new Vector2(this.renderer.bounds.size.x > .04f ? this.renderer.bounds.size.x : .05f,
                                    this.renderer.bounds.size.y > .04f ? this.renderer.bounds.size.y : .05f);
	}
	
	void Update () {
		
		if (this.transform.position.y < Camera.main.orthographicSize)
		{
			this.transform.Translate(0,3f * Time.deltaTime, 0);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
