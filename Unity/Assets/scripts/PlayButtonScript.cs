using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {

	AudioSource audioSource;
	SpriteRenderer menuRenderer;

	public AudioClip[] songs; 
	public Sprite[] menus;

	void Awake () {
		audioSource = (AudioSource)GameObject.Find("audio").GetComponent("AudioSource");
		menuRenderer = (SpriteRenderer)GameObject.Find("menu").GetComponent("SpriteRenderer");
	}
	

	void Update () {
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			/* TODO: BORRAR LA PARTE DE DEBUG EN PC */

			if (Input.GetMouseButton(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray, out hit))
				{
					Acciones (hit);
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
					Acciones (hit);
				}
			}
		}
	}

	void Acciones(RaycastHit hit)
	{
		switch (hit.transform.gameObject.name)
		{
		case "song1":
			audioSource.clip = songs[0];
			menuRenderer.sprite = menus[0];
			break;
		case "song2":
			audioSource.clip = songs[1];
			menuRenderer.sprite = menus[1];
			break;
		case "song3":
			audioSource.clip = songs[2];
			menuRenderer.sprite = menus[2];
			break;
		case "song4":
			audioSource.clip = songs[3];
			menuRenderer.sprite = menus[3];
			break;
		case "play_button":
			if (audioSource.clip != null)
			{
				audioSource.Play();
				Application.LoadLevel("AudioTest");
			}
			break;
		}
	}
}
