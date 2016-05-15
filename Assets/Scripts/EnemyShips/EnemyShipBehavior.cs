using UnityEngine;
using System.Collections;

public enum ShipBehavior {
	None,
	Kamikaze
}

[RequireComponent(typeof(EnemyShip))]
[RequireComponent(typeof(Resetable))]
public abstract class EnemyShipBehavior : MonoBehaviour {
	protected EnemyShip ship;
	Resetable resetable;

	protected virtual void Awake(){
		ship		= GetComponent<EnemyShip> ();
		resetable	= GetComponent<Resetable> ();
	}

	void OnEnable(){
		resetable.OnReset += Reset;
	}

	void OnDisable(){
		resetable.OnReset -= Reset;
	}

	protected abstract void Reset();
}
