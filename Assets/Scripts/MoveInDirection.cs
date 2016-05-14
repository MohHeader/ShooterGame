using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ShipMovment))]
public class MoveInDirection : MonoBehaviour {
	ShipMovment movment;
	Vector3 direction;

	void Awake(){
		movment = GetComponent<ShipMovment> ();
	}

	void Update () {
		movment.DirectionMove (direction);
	}

	public void SetDirection(Vector3 direction){
		this.direction = direction;
	}

	public void SetTarget(Transform target){
		SetDirection (target.position - transform.position);
	}
}
