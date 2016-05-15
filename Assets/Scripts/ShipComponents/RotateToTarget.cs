using UnityEngine;
using System.Collections;

/// <summary>
/// Component Used by some EnemyShipBehavior to make the ship rotate toward the target.
/// </summary>
public class RotateToTarget : MonoBehaviour {
	public void SetTarget(Transform target){
		transform.up = target.position - transform.position;
	}
}
