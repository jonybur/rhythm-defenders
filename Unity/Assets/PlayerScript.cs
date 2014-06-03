using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	int vidas;
	public bool parpadeo;
	float timer;
	float tiempoAParpadear;
	float tiempoParpadeo;

	SpriteRenderer s;

	void Awake () {
		tiempoAParpadear = .7f;
		tiempoParpadeo = 0;
		vidas = 4;
		timer = 0;

		s = this.GetComponent("SpriteRenderer") as SpriteRenderer;

		BoxCollider2D coll = this.collider2D as BoxCollider2D;
		coll.size = this.renderer.bounds.size;
	}

	void Update()
	{
		Debug.Log (vidas);
		if (parpadeo)
		{
			timer += Time.deltaTime;
			tiempoParpadeo += Time.deltaTime;

			if (timer > tiempoAParpadear)
			{
				tiempoAParpadear -= .05f;
				s.enabled = !s.enabled;
				timer = 0;
			}

			if (tiempoParpadeo > 5f)
			{
				parpadeo = false;
				tiempoAParpadear = .7f;
				tiempoParpadeo = 0;
			}
		}
	}

	public void Destruir()
	{
		if (!parpadeo)
		{			
			vidas --;
			s.enabled = !s.enabled;

			if (vidas >= 0)
			{			
				parpadeo = true;
			}else{
				/* TODO: GameOver */
			}

			Instantiate(Resources.Load("explosion_player", typeof(GameObject)), this.transform.position, Quaternion.identity);
		}
	}
}
