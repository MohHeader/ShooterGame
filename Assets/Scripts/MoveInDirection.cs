using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movment))]
public class MoveInDirection : MonoBehaviour {
	Movment movment;
	Vector3 direction = Vector3.up;

	void Awake(){
		movment = GetComponent<Movment> ();
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
