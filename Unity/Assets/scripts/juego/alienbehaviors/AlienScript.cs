using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {

	// aca dejo funciones que son comunes para todos los aliens
	bool chequeado;
	GameObject explosion;
	bool explota;
	PlayerScript player;

	public int puntaje;

	public virtual void Awake()
	{
		puntaje = 10;
		explota = false;
		player = GameObject.Find("player").gameObject.GetComponent("PlayerScript") as PlayerScript;
		
		BoxCollider2D coll = this.collider2D as BoxCollider2D;
		coll.size = this.renderer.bounds.size;

		// hay 1 en 40 de probabilidad que este alien se convierta en un kamikaze
		if (Random.Range(1,30) == 1 && GameObject.Find("player") != null)
		{
			gameObject.tag = "kamikaze";
		}
	}

	public virtual void OnDestroy()
	{
		if (explota)
		{
			GameObject a = (GameObject)Instantiate(Resources.Load("explosion_alien", typeof(GameObject)),
			                                       this.transform.position, Quaternion.identity);
		}
	}

	public virtual void Update () {
		if (this.transform.position.y < Camera.main.orthographicSize/2 &&
		    this.gameObject.tag == "kamikaze")
		{	
			AlienKamikazeScript kamikaze = this.GetComponent("AlienKamikazeScript") as AlienKamikazeScript;
			kamikaze.enabled = true;
		}

		if (this.transform.position.y + this.renderer.bounds.size.y < -Camera.main.orthographicSize)
		{
			Destroy (this.gameObject);
		}

	}

	public virtual void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "bala")
		{	
			explota = true;
			player.Mata(puntaje, this.transform.position);
			Destroy(this.gameObject);
		}

		if (other.gameObject.name == "player" && !player.parpadeo)
		{
			this.gameObject.tag = "asesino";

			// destruye a todos los kamikazes también

			GameObject[] vec = GameObject.FindGameObjectsWithTag("kamikaze");
			foreach (GameObject g in vec)
			{
				Destroy (g.gameObject);
			}
			
			player.Destruir();		
			Destroy(this.gameObject);
		}
	}
}
