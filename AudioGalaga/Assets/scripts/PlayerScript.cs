using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			AccionesNave(Input.GetMouseButton(0), Input.mousePosition);
		}
		else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			AccionesNave(Input.touches.Length > 0, (Input.touches.Length > 0) ? (Vector3)Input.touches[0].position : new Vector3());
		}
	}

	void AccionesNave (bool toca, Vector3 posicionTouch)
	{
		posicionTouch = Camera.main.ScreenToWorldPoint(posicionTouch);

		if (toca)
		{
			this.transform.position = new Vector3 (posicionTouch.x, 
			                                       posicionTouch.y + this.renderer.bounds.size.y,
			                                       0);
		}
	}
}
