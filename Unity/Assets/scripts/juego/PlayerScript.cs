using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
		
	public int vidas;
	public bool parpadeo;
	float timerParpadeo;
	float tiempoAParpadear;
	float tiempoParpadeo;
	public int puntaje;

	bool huboAsesinato;

	float timerParaCombo;
	float tiempoParaCombo;
	SpriteRenderer s;

	int comboAux;
	public int combo;

	public GameObject comboSignal;
	
	void Awake () {
		tiempoAParpadear = .7f;
		tiempoParpadeo = 0;
		vidas = 4;
		timerParpadeo = 0;
		puntaje = 0;
		tiempoParaCombo = .5f;
		timerParpadeo = 0;
		huboAsesinato = false;
		combo = 0;

		s = this.GetComponent("SpriteRenderer") as SpriteRenderer;
		
		BoxCollider2D coll = this.collider2D as BoxCollider2D;
		coll.size = this.renderer.bounds.size;
	}

	public void Mata(int puntajeAlien, Vector3 posAlien)
	{
		Debug.Log (combo);
		puntaje += puntajeAlien * (combo+1);

		huboAsesinato = true;

		if (combo > 0)
		{
			GameObject g = (GameObject)Instantiate(comboSignal,posAlien,Quaternion.identity);
		}
	}
	
	void Update()
	{
		timerParaCombo += Time.deltaTime;
		if (huboAsesinato)
		{
			if (timerParaCombo <= tiempoParaCombo)
			{
				/* otorgo combo */
				if (comboAux < 25)
					comboAux++;
			}
			else
			{
				comboAux = 0;
			}
			combo = comboAux/5;

			timerParaCombo = 0;
			huboAsesinato = false;
		}

		if (parpadeo)
		{
			timerParpadeo += Time.deltaTime;
			tiempoParpadeo += Time.deltaTime;
			
			if (timerParpadeo > tiempoAParpadear)
			{
				if (tiempoAParpadear > .2f)
				    tiempoAParpadear -= .05f;
				s.enabled = !s.enabled;
				timerParpadeo = 0;
			}
			
			if (tiempoParpadeo > 6f)
			{
				parpadeo = false;
				s.enabled = true;
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
				/* TODO: GameOver (pasarlo del controladortouch a acá) */
			}
			
			Instantiate(Resources.Load("explosion_player", typeof(GameObject)), this.transform.position, Quaternion.identity);
		}
	}
}
