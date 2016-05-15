using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class ShipExplosion : MonoBehaviour {

	Health health;

	void Awake(){
		health = GetComponent<Health> ();
	}

	void OnEnable () {
		health.OnHealthChange += Explode;
	}

	void OnDisable () {
		health.OnHealthChange -= Explode;
	}

	void Explode(float percentage) {
		if(percentage <= 0)
			SimplePool.Spawn(Resources.Load<GameObject>("Explosion"), transform.position, transform.rotation);
	}
}
