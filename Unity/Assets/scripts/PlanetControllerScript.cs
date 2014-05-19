using UnityEngine;
using System.Collections;

public class PlanetControllerScript : MonoBehaviour {

	float timer; 
	public GameObject planeta;
	public Sprite[] imagenes;

	void Awake()
	{
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > 3)
		{
			InstanciarPlaneta(imagenes[Random.Range(0, imagenes.Length)]);

			timer = 0;
		}
	}

	void InstanciarPlaneta(Sprite sprite)
	{
		GameObject p = (GameObject)Instantiate(planeta);
		float altoPantalla = Camera.main.orthographicSize;
		float anchoPantalla = Camera.main.aspect * altoPantalla; 

		SpriteRenderer sRenderer = p.GetComponent("SpriteRenderer") as SpriteRenderer;
		sRenderer.sprite = sprite;

		p.transform.position = new Vector3(Random.Range (-anchoPantalla, anchoPantalla),
		                                   altoPantalla + p.renderer.bounds.size.y / 2,
		                                   0);
		
		PlanetaScript s = (PlanetaScript)p.GetComponent("PlanetaScript");
		s.TamanioInicial = Random.Range(.3f,1f);
		
		p.transform.parent = this.transform;
	}
}
