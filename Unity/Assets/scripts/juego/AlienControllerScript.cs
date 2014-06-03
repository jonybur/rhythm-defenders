using UnityEngine;
using System.Collections;

public class AlienControllerScript : MonoBehaviour {

	// cronometros
	float timerBatches; 
	float timerAliens;
	// tiempo tope de cronometros
	float tiempoEntreBatches;
	float tiempoEntreAliens;
	// bools que manejan a los batches
	bool lanzoBatch;
	bool lanzoAliens;
	// manejo de spawns
	int cantidadLanzada;
	int cantidadALanzar;
	// vector de posibilidades y elegido
	public GameObject[] aliens;
	GameObject alien;
	
	void Awake()
	{
		tiempoEntreBatches = 5;
		timerBatches = 0;
		lanzoBatch = true;
		cantidadLanzada = 0;
	}

	void Update () {
		timerAliens += Time.deltaTime;

		if (!lanzoBatch && !lanzoAliens)
		{
			timerBatches += Time.deltaTime;
		}

		if (timerBatches > tiempoEntreBatches)
		{
			// cada vez tarda menos en mandar al batch siguiente
			tiempoEntreBatches -= .2f;
			timerBatches = 0;
			lanzoBatch = true;
		}

		if (lanzoBatch)
		{
			LanzoBatch ();
		}

		// lanza a los aliens, de a uno, hasta que se cumplan las condiciones seteadas por el lanzador de batches

		if (lanzoAliens)
		{
			LanzoAliens();
		}

		// deberia ser cuando se acabo el batch actual
		// lanza al lanzador de batches
	}

	void LanzoAliens()
	{
		// si hay que mandar aliens...
		if (cantidadALanzar > cantidadLanzada)
		{
			// y cumple el tiempo de spawn...
			if (timerAliens > tiempoEntreAliens)
			{
				InstanciarAlien(alien);
				cantidadLanzada++;
				timerAliens = 0;
			}
		}
		else
		{
			cantidadLanzada = 0;
			lanzoAliens = false;
		}
	}

	void LanzoBatch()
	{
		// elige que batch manda, y setea las variables para que eso ocurra
		alien = aliens[Random.Range(0,aliens.Length)];

		switch (alien.name)
		{
			case "alien1":
				cantidadALanzar = 25;
				tiempoEntreAliens = .2f;
				break;
				
			case "alien2":
				cantidadALanzar = 25;
				tiempoEntreAliens = .2f;
				break;
				
			case "alien3":
				cantidadALanzar = 25;
				tiempoEntreAliens = .2f;
				break;
		}
		
		lanzoBatch = false;
		lanzoAliens = true;
	}

	void InstanciarAlien(GameObject alien)
	{
		// depende el alien, depende el timer
		// tambien se debe poner un tope de cantidad de aliens a spawnear

		GameObject p = (GameObject)Instantiate(alien);


		float altoPantalla = Camera.main.orthographicSize;

		p.transform.position = new Vector3(0,
		                                   altoPantalla + p.renderer.bounds.size.y / 2,
		                                   0);
		
		p.transform.parent = this.transform;
	}
}
