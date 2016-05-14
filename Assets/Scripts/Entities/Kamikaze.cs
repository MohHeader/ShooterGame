using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveInDirection))]
[RequireComponent(typeof(EnemyShip))]
[RequireComponent(typeof(Resetable))]
public class Kamikaze : MonoBehaviour {

	void Awake () {
		EnemyShip ship = GetComponent<EnemyShip> ();
		MoveInDirection movement = GetComponent<MoveInDirection> ();
		RotateToTarget rotate = GetComponent<RotateToTarget> ();

		GetComponent<Resetable>().OnReset += delegate() {
			transform.position = SpawnerHelper.WideTop() + Vector3.up;
			movement.SetTarget(ship.player.transform);
			rotate.SetTarget(ship.player.transform);
		};
	}
}
