﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class MoveInDirection : MonoBehaviour {
	Movement movment;
	Vector3 direction = Vector3.up;

	void Awake(){
		movment = GetComponent<Movement> ();
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
