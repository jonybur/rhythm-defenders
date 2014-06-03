using UnityEngine;
using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour {

	BoxCollider2D collider;
	
	void Awake()
	{

		collider = this.collider2D as BoxCollider2D;
		collider.size = (Vector2)this.renderer.bounds.size;
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
