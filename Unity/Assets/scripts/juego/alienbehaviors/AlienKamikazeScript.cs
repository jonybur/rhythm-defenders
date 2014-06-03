using UnityEngine;
using System.Collections;

public class AlienKamikazeScript : AlienScript {

	public Transform posicionPlayer;
	public Sprite sprite;
	float velocidad = 1.5f;

	void Start()
	{
		// este mismo script desactiva cualquier otro script de movimiento que haya activo

		switch (this.name)
		{
			case "alien1(Clone)":
				AlienCircleScript acs = this.GetComponent("AlienCircleScript") as AlienCircleScript;
				acs.enabled = false;
				break;

			case "alien2(Clone)":
				AlienOscScript aos = this.GetComponent("AlienOscScript") as AlienOscScript;
				aos.enabled = false;
				break;

			case "alien3(Clone)":
				AlienSpiralScript ass = this.GetComponent("AlienSpiralScript") as AlienSpiralScript;
				ass.enabled = false;
				break;
		}

		
		this.renderer.sortingLayerName = "kamikaze";
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
	}

	
	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);
	}


	public override void Update(){
		base.Update();

		Vector3 diff = posicionPlayer.position - this.transform.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

		transform.position = Vector3.MoveTowards(this.transform.position, posicionPlayer.position, velocidad * Time.deltaTime);
	}
}
