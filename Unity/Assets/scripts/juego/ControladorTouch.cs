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

	public GameObject menuPausa;
	public GameObject botonPausa;
	public GameObject menuGameOver;

	bool butPres;

	AudioSource a;

	void Awake()
	{			
		botonPausa = Instantiate(botonPausa) as GameObject;
		menuPausa = Instantiate(menuPausa) as GameObject;
		menuPausa.SetActive(false);
		menuGameOver = Instantiate(menuGameOver) as GameObject;
		menuGameOver.SetActive(false);

		rendererBoton = (SpriteRenderer)GameObject.Find("boton_disparo").GetComponent("SpriteRenderer");
		index = 0f;
		rate = 0.3f;
		butPres = false;

		
		try
		{
			a = (AudioSource) GameObject.Find ("audio").GetComponent("AudioSource");
		}
		catch
		{
			a = (AudioSource) GameObject.Find ("audio_debug").GetComponent("AudioSource");
		}
	}
	
	void Update () {
		GameObject[] combos = GameObject.FindGameObjectsWithTag("combo");
		foreach(GameObject c in combos)
		{
			ComboSignalScript css = c.GetComponent("ComboSignalScript") as ComboSignalScript;
			if (css.enabled == false)
			{
				css.enabled = true;
			}
		}

		index += Time.deltaTime;
		butPres = false;
		
		if (!a.isPlaying || (nave.GetComponent("PlayerScript") as PlayerScript).vidas < 0)
		{
			a.Pause();
			menuGameOver.SetActive(true);
		}

		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			/* TODO: BORRAR LA PARTE DE DEBUG EN PC */

			if (Input.GetMouseButton(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit))
				{
					Acciones (hit, Camera.main.ScreenToWorldPoint(Input.mousePosition));
				}
			}
			
			if (Input.GetKeyDown(KeyCode.Space))
			{
				butPres = true;
				if (index > rate)
				{
					
					GameObject b = (GameObject)Instantiate(bala);
					b.transform.position = nave.transform.position + new Vector3(0,nave.renderer.bounds.size.y/2,0);
					index = 0; 
				}
			}
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
		Debug.Log(hit.transform.gameObject.name);
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

		else if (hit.transform.gameObject.name == "pause_menu(Clone)")
		{
			botonPausa.SetActive(true);
			menuPausa.SetActive(false);
			
			a.Play();          

			Time.timeScale = 1;
		}

		else if (hit.transform.gameObject.name == "pause_button(Clone)")
		{		
			// TODO: sacar el puntaje y la botonera también
			
			a.Pause();
			botonPausa.SetActive(false);
			menuPausa.SetActive(true);
			Time.timeScale = 0;
		}

		else if (hit.transform.gameObject.name == "gameover_menu(Clone)")
		{	
			menuGameOver.SetActive(false);
			Application.LoadLevel("IntroScene");
		}
	}

}
