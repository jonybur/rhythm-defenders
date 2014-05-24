using UnityEngine;
using System.Collections;

public class AlienCircleScript : AlienScript {
	
	float amplitude;
	float maxAmplitude;
	float index;
	float variacion;
	float movCos;
	float movSin;
	float primerTamY;

	void Awake()
	{
		primerTamY = this.renderer.bounds.size.y;
		index = 1f;
		variacion = .3f;
		amplitude = .6f;

		movCos = 0;
		movSin = 0;
	}
	
	public override void Update()
	{
		base.Update();
		index += Time.deltaTime;

		amplitude += Time.deltaTime * variacion;

		movCos = -amplitude * Mathf.Cos(index * Mathf.PI); 
		movSin =  amplitude * Mathf.Sin(index * Mathf.PI);

		this.transform.position = new Vector3(movCos, primerTamY + Camera.main.orthographicSize + movSin, 0);

		

		if (this.transform.position.x > 0)
		{
			this.transform.eulerAngles = new Vector3(0,0,Mathf.Rad2Deg * Mathf.Atan(movSin/movCos));
		}
		else
		{
			this.transform.eulerAngles = new Vector3(0,0,Mathf.Rad2Deg * Mathf.Atan(movSin/movCos) - 180);
		}

	}
}