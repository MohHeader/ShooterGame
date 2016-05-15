using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyShip))]
[RequireComponent(typeof(MoveInDirection))]
[RequireComponent(typeof(RotateToTarget))]
[RequireComponent(typeof(Resetable))]
public class Kamikaze : MonoBehaviour {

	EnemyShip ship;
	MoveInDirection movement;
	RotateToTarget rotate;
	Resetable resetable;

	void Awake () {
		ship		= GetComponent<EnemyShip> ();
		movement	= GetComponent<MoveInDirection> ();
		rotate		= GetComponent<RotateToTarget> ();
		resetable	= GetComponent<Resetable> ();
	}

	void OnEnable(){
		resetable.OnReset += Reset;
	}

	void OnDisable(){
		resetable.OnReset -= Reset;
	}

	void Reset(){
		if(ship.player == null){
			Debug.LogError("Enemy Ship with no Target Player !");
			return;
		}

		transform.position = SpawnerHelper.WideTop() + Vector3.up;
		movement.SetTarget(ship.player.transform);
		rotate.SetTarget(ship.player.transform);
	}
}
