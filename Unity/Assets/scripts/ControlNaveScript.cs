using UnityEngine;
using System.Collections;

public class ControlNaveScript : MonoBehaviour {

	public GameObject nave;

	void Update () {

		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			if (Input.GetMouseButton(0))
			{				
				AccionesNave(Input.mousePosition);
			}
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			foreach(Touch touch in Input.touches)
			{
				AccionesNave (touch.position);
			}
		}
	}
	
	void AccionesNave (Vector3 posicionTouch)
	{
		posicionTouch = Camera.main.ScreenToWorldPoint(posicionTouch);

		if (Vector2.Distance(posicionTouch,this.transform.position) < 1.5f)
		{
			nave.transform.position = new Vector3 (posicionTouch.x, 
			                                       posicionTouch.y + nave.renderer.bounds.size.y,
			                                       0);

		}
	}

}
