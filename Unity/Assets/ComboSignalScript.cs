using UnityEngine;
using System.Collections;

public class ComboSignalScript : MonoBehaviour {
		
	public Sprite[] combos;
	PlayerScript player;
	SpriteRenderer spriteRenderer;
	float tiempoVida;

	void Awake () {
		tiempoVida = 2f;
		// genera un combo prefab en la posicion del alien
		player = GameObject.Find("player").GetComponent("PlayerScript") as PlayerScript;
		spriteRenderer = this.GetComponent("SpriteRenderer") as SpriteRenderer;
		spriteRenderer.sprite = combos[player.combo - 1];
	}

	void Update () {	
		tiempoVida-=Time.deltaTime;
		if (tiempoVida > 0)
		{
			this.transform.localScale = new Vector3 (tiempoVida,tiempoVida,tiempoVida);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
