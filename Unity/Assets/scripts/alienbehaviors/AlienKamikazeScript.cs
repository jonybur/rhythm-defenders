using UnityEngine;
using System.Collections;

public class AlienKamikazeScript : MonoBehaviour {

	public Transform posicionPlayer;
	float velocidad = 5f;
	
	void Update(){
		transform.position = Vector3.MoveTowards(this.transform.position, posicionPlayer.position, velocidad * Time.deltaTime);
	}
}
