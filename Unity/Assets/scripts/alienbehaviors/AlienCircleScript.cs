using UnityEngine;
using System.Collections;

public class AlienCircleScript : AlienScript {
	
	float amplitude;
	float index;
	float variacion;
	float movCos;
	float movSin;
	float primerTamY;

	void Awake()
	{
		primerTamY = this.renderer.bounds.size.y;
		index = 1f;
		variacion = .2f;

		amplitude = .5f;

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

	
	/*public override void Update()
	{
		base.Update();
		index += Time.deltaTime;
		amplitude += Time.deltaTime * variacion;
		
		movCos = -amplitude * Mathf.Cos(index * Mathf.PI); 
		movSin = this.renderer.bounds.size.y + Camera.main.orthographicSize + amplitude * Mathf.Sin(index * Mathf.PI);
		
		this.transform.position = new Vector3(movCos, movSin, 0);
		
		
		
		if (this.transform.position.x > 0)
		{
			this.transform.eulerAngles = new Vector3(0,0,Mathf.Rad2Deg * Mathf.Atan(this.transform.position.y/this.transform.position.x));
		}
		else
		{
			this.transform.eulerAngles = new Vector3(-0,0,Mathf.Rad2Deg * Mathf.Atan(this.transform.position.y/this.transform.position.x) - 180);
		}
		
	}*/
}