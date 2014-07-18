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

    int flag;
    bool huboTouch;
	bool disparoPres;

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
		disparoPres = false;
		
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
		disparoPres = false;

        //////////////////////////////////////////////////////////
        // WINDOWS Y OSX (ESCRITORIO) ////////////////////////////
        //////////////////////////////////////////////////////////

		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			if (Input.GetMouseButton(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit))
				{
					Acciones (hit, Camera.main.ScreenToWorldPoint(Input.mousePosition), out flag);
				}
			}
            else if (huboTouch)
            {
                huboTouch = false;
                AccionesTap(flag);
            }
			
			if (Input.GetKeyDown(KeyCode.Space))
			{
				disparoPres = true;
				if (index > rate)
				{					
					GameObject b = (GameObject)Instantiate(bala);
					b.transform.position = nave.transform.position + new Vector3(0,nave.renderer.bounds.size.y/2,0);
					index = 0; 
				}
			}
		}

        //////////////////////////////////////////////////////////
        // IPHONE Y ANDROID (MOVIL) //////////////////////////////
        //////////////////////////////////////////////////////////
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			foreach(Touch t in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay(t.position);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit))
				{
					Acciones (hit, Camera.main.ScreenToWorldPoint (t.position), out flag);
				}
			}

            if (huboTouch && Input.touches.Length == 0)
            {
                huboTouch = false;
                AccionesTap(flag);
            }

		}

		if (disparoPres)
		{ rendererBoton.sprite = botones[1]; }
        else 
        { rendererBoton.sprite = botones[0]; }			
	}

	void Acciones(RaycastHit hit, Vector3 posicion, out int accion)
	{
        huboTouch = true;
        accion = -1;
        switch (hit.transform.gameObject.name)
        {
            case "boton_disparo":
                disparoPres = true;
			    if (index > rate)
			    {
				    GameObject b = (GameObject)Instantiate(bala);
				    b.transform.position = nave.transform.position + new Vector3(0,nave.renderer.bounds.size.y/2,0);
				    index = 0; 
			    }
                break;

            case "control_nave":
                nave.transform.position = new Vector3(posicion.x,
                                       posicion.y + 2f,
                                       0);
                break;

            // los tres menues mandan flag, porque la interaccion ocurre cuando se suelta el dedo
            case "pause_menu(Clone)":
                accion = 0;
                break;

            case "pause_button(Clone)":
                // TODO: sacar el puntaje y la botonera también
                accion = 1;
                break;

            case "gameover_menu(Clone)":
                accion = 2;
                break;
        }
	}

    void AccionesTap(int accion)
    {
        switch (accion)
        {
            // pause_menu(Clone)
            case 0:
                botonPausa.SetActive(true);
                menuPausa.SetActive(false);
                a.Play();
                Time.timeScale = 1;
                break;

            // pause_button(Clone)
            case 1:
                // TODO: sacar el puntaje y la botonera también
                a.Pause();
                botonPausa.SetActive(false);
                menuPausa.SetActive(true);
                Time.timeScale = 0;
                break;

            // gameover_menu(Clone)
            case 2:
                menuGameOver.SetActive(false);
                Application.LoadLevel("IntroScene");
                break;
        }
    }
}
