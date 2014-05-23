using UnityEngine;
using System.Collections;

public class AlienControllerScript : MonoBehaviour {

	float timer; 
	public GameObject[] aliens;
	
	void Awake()
	{
		timer = 0;
	}

	void Update () {
		timer += Time.deltaTime;
		
	
	}

	// crea aliens de a batches
	void InstanciarAliens(GameObject alien)
	{
		// depende el alien, depende el timer
		// tambien se debe poner un tope de cantidad de aliens a spawnear
		if (timer > .2f)
		{
			InstanciarAliens(aliens[0]);
			
			timer = 0;
		}

		GameObject p = (GameObject)Instantiate(alien);
		float altoPantalla = Camera.main.orthographicSize;

		p.transform.position = new Vector3(0,
		                                   altoPantalla + p.renderer.bounds.size.y / 2,
		                                   0);
		
		p.transform.parent = this.transform;
	}
}
