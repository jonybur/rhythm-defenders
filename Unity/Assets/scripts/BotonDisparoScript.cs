using UnityEngine;
using System.Collections;

public class BotonDisparoScript : MonoBehaviour {

	public GameObject bala;
	public GameObject nave;
	float rate;
	float index;

	void Awake()
	{
		index = 0f;
		rate = 0.3f;
	}

	void Update () {
		index += Time.deltaTime;
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			if (Input.GetMouseButton(0))
			{				
				AccionDisparo(Input.mousePosition);
			}
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			foreach(Touch touch in Input.touches)
			{
				AccionDisparo (touch.position);
			}
		}
	}
	
	void AccionDisparo (Vector3 posicionTouch)
	{
		posicionTouch = Camera.main.ScreenToWorldPoint(posicionTouch);
		
		if (Vector2.Distance(posicionTouch,this.transform.position) < 1f && 
		    index > rate)
		{
			GameObject b = (GameObject)Instantiate(bala);
			b.transform.position = nave.transform.position + new Vector3(0,nave.renderer.bounds.size.y/2,0);
			b.transform.parent = this.transform;
			index = 0;
		}
	}
}
