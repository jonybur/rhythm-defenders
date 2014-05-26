using UnityEngine;
using System.Collections;

public class AlienControllerScript : MonoBehaviour {

	float timerBatches; 
	float timerIndividuales;
	bool lanzoBatch;
	public GameObject[] aliens;
	float tiempoEntreBatches;
	GameObject alien;

	// regulan la cantidad y la frecuencia de creacion de alien, dependiendo el alien

	int cantidad;
	int cantidadALanzar;
	float periodo;
	
	void Awake()
	{
		tiempoEntreBatches = 5;
		timerBatches = 0;
		lanzoBatch = true;
		cantidad = 0;
	}

	void Update () {
		timerIndividuales += Time.deltaTime;

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

		LanzoAliens();

		// deberia ser cuando se acabo el batch actual
		// lanza al lanzador de batches

	}

	void LanzoAliens()
	{
		// si hay aliens para mandar...
		if (cantidadALanzar > cantidad)
		{
			// y cumple el tiempo de spawn...
			if (timerIndividuales > periodo)
			{
				// manda aliens
				InstanciarAlien(alien);
				cantidad++;
				timerIndividuales = 0;
			}
		}
		else
		{
			// no manda aliens (resetea variables)
			cantidadALanzar = -1;
			cantidad = 0;
			
			timerBatches += Time.deltaTime;
		}
	}

	void LanzoBatch()
	{
		// elige que batch manda, y setea las variables para que eso ocurra
		alien = aliens[Random.Range(0,aliens.Length)];


		// TODO: ver como arreglar esto
		switch (alien.name)
		{
		case "alien1":
			cantidadALanzar = 50;
			periodo = .2f;
			break;
			
		case "alien2":
			cantidadALanzar = 50;
			periodo = .2f;
			break;
			
		case "alien3":
			cantidadALanzar = 50;
			periodo = .2f;
			break;
		}
		
		lanzoBatch = false;
	}

	void InstanciarAlien(GameObject alien)
	{
		// depende el alien, depende el timer
		// tambien se debe poner un tope de cantidad de aliens a spawnear

		GameObject p = (GameObject)Instantiate(alien);
		AlienKamikazeScript kamikaze = p.GetComponent("AlienKamikazeScript") as AlienKamikazeScript;
		kamikaze.posicionPlayer = GameObject.Find("player").transform as Transform;


		float altoPantalla = Camera.main.orthographicSize;

		p.transform.position = new Vector3(0,
		                                   altoPantalla + p.renderer.bounds.size.y / 2,
		                                   0);
		
		p.transform.parent = this.transform;
	}
}
