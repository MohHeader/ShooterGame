using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Resetable))]
public class EnemyShip : MonoBehaviour {
	public PlayerShip player { get; protected set; }
	Resetable resetable;

	public event System.Action OnShipDestroyed;

	void Awake(){
		resetable = GetComponent<Resetable> ();

		Health health = GetComponent<Health> ();
		if (health != null) {
			health.OnHealthChange += delegate(float percentage) {
				if(percentage <= 0){
					if(OnShipDestroyed != null)
						OnShipDestroyed();
					SimplePool.Despawn(gameObject);
				}
			};
		}
	}

	public void SetPlayerShip(PlayerShip player){
		this.player = player;
	}

	public void Reset(){
		resetable.Reset ();
	}
}
