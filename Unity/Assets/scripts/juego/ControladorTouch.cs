using UnityEngine;
using System.Collections;

public class ControladorTouch : MonoBehaviour {

	public GameObject nave;
	float separacionConNave;
	
	public GameObject bala;
	float rate;
	float index;

	public Sprite[] botones;
	SpriteRenderer rendererBoton;

	bool butPres;
	
	void Awake()
	{			
		rendererBoton = (SpriteRenderer)GameObject.Find("boton_disparo").GetComponent("SpriteRenderer");
		index = 0f;
		rate = 0.3f;
		butPres = false;
	}
	
	void Update () {
		index += Time.deltaTime;
		butPres = false;

		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			/* TODO: BORRAR LA PARTE DE DEBUG EN PC */
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			foreach(Touch t in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay(t.position);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit))
				{
					Acciones (hit, Camera.main.ScreenToWorldPoint (t.position));
				}
			}
		}

		if (butPres)
		{
			rendererBoton.sprite = botones[1];
		}else{
			
			rendererBoton.sprite = botones[0];
		}
			
	}

	void Acciones(RaycastHit hit, Vector3 posicion)
	{
		if (hit.transform.gameObject.name == "boton_disparo")
		{
			butPres = true;
			if (index > rate)
			{

				GameObject b = (GameObject)Instantiate(bala);
				b.transform.position = nave.transform.position + new Vector3(0,nave.renderer.bounds.size.y/2,0);
				index = 0; 
			}
		}

		else if (hit.transform.gameObject.name == "control_nave")
		{
			nave.transform.position = new Vector3 (posicion.x, 
			                                       posicion.y + 2f,
			                                       0);
		}
	}

}
