using UnityEngine;
using System.Collections;

public class AlienKamikazeScript : AlienScript {

	public Transform posicionPlayer;
	float velocidad = 2f;

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
	}

	public override void Update(){
		base.Update();

		// TODO: agregar rotacion

		transform.position = Vector3.MoveTowards(this.transform.position, posicionPlayer.position, velocidad * Time.deltaTime);
	}
}
