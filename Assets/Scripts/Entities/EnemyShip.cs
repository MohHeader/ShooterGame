using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Resetable))]
public class EnemyShip : MonoBehaviour {
	public PlayerShip player { get; protected set; }
	Resetable resetable;

	void Awake(){
		resetable = GetComponent<Resetable> ();
	}

	public void SetPlayerShip(PlayerShip player){
		this.player = player;
	}

	public void Reset(){
		resetable.Reset ();
	}
}
