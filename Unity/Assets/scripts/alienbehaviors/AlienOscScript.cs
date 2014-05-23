using UnityEngine;
using System.Collections;

public class AlienOscScript : AlienScript {
	
	float amplitude;
	float omega;
	float index;
	float oscilacion;
		
	void Awake()
	{
		amplitude = 7f;
		omega = 5f;
		index = 0;
		oscilacion = 0;
	}

	public override void Update()
	{
		base.Update();
		index += Time.deltaTime;
		oscilacion=amplitude*(Mathf.Cos(omega*index))*Time.deltaTime;
		transform.Translate (oscilacion, -2*Time.deltaTime,0, Space.World);
	}
}