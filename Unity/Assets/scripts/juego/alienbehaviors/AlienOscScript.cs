using UnityEngine;
using System.Collections;

public class AlienOscScript : AlienScript {
	
	float amplitude;
	float omega;
	float index;
	float oscilacion;
		
	public override void Awake()
	{
		base.Awake();

		amplitude = 8f;
		omega = 5f;
		index = 0;
		oscilacion = 0;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void Update()
	{
		base.Update();
		index += Time.deltaTime;
		oscilacion = amplitude * (Mathf.Cos(omega*index)) * Time.deltaTime;
		transform.Translate (oscilacion, -2*Time.deltaTime, 0, Space.World);

		this.transform.Rotate(new Vector3(0,0,oscilacion* -60));
	}

	
	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);
	}

}