﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyShip))]
public class AddScoreOnHit : MonoBehaviour {
	public int ScoreToAdd;

	void OnEnable () {
		GetComponent<EnemyShip> ().OnShipDestroyed += Hit;
	}

	void OnDisable () {
		GetComponent<EnemyShip> ().OnShipDestroyed -= Hit;
	}

	void Hit () {
		ScoreMaster.Instance.AddScore (ScoreToAdd);
	}
}
