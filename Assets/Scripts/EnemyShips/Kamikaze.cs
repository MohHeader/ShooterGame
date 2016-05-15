using UnityEngine;
using System.Collections;

/// <summary>
/// Kamikaze ( def : were suicide attacks by military aviators from the Empire of Japan against Allied naval vessels )
/// https://en.wikipedia.org/wiki/Kamikaze
/// 
/// The Behavior :: 
/// On Spawn, the ship rotates toward the player, & move forward in its direction.
/// 
/// </summary>

[RequireComponent(typeof(MoveInDirection))]
[RequireComponent(typeof(RotateToTarget))]
public class Kamikaze : EnemyShipBehavior {
	MoveInDirection movement;
	RotateToTarget rotate;

	protected override void Awake () {
		base.Awake ();
		movement	= GetComponent<MoveInDirection> ();
		rotate		= GetComponent<RotateToTarget> ();
	}

	protected override void Reset(){
		if(ship.player == null){
			Debug.LogError("Enemy Ship with no Target Player !");
			return;
		}

		transform.position = SpawnerHelper.WideTop() + Vector3.up;
		movement.SetTarget(ship.player.transform);
		rotate.SetTarget(ship.player.transform);
	}
}
