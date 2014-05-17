using UnityEngine;
using System.Collections;

public class PlanetControllerScript : MonoBehaviour {

	float timer; 
	public GameObject planetaA;
	public GameObject planetaB;

	void Awake()
	{
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > 3)
		{
			switch (Random.Range(0,2))
			{
				case 0:
					InstanciarPlaneta(planetaA);
					break;
				case 1:
					InstanciarPlaneta(planetaB);
					break;
			}


			timer = 0;
		}
	}

	void InstanciarPlaneta(GameObject p)
	{
		p = (GameObject)Instantiate(p);
		float altoPantalla = Camera.main.orthographicSize;
		float anchoPantalla = Camera.main.aspect * altoPantalla; 
		
		p.transform.position = new Vector3(Random.Range (-anchoPantalla, anchoPantalla),
		                                   altoPantalla + p.renderer.bounds.size.y/2,
		                                   0);
		
		PlanetaScript s = (PlanetaScript)p.GetComponent("PlanetaScript");
		s.TamanioInicial = Random.Range(.3f,1f);
		
		p.transform.parent = this.transform;
	}
}
