using UnityEngine;
using System.Collections;

public class EnemySpawnerMaster : MonoBehaviour {
	public GameObject[] prefabs;

	float toSpawn;

	void Start () {
		toSpawn = Random.Range (1f, 4f);
		Invoke ("Spawn", toSpawn);
	}
	
	void Spawn(){
		
		GameObject go = SimplePool.Spawn (prefabs [0], Vector3.zero, Quaternion.identity);
		EnemyShip ship =  go.GetComponent<EnemyShip>();

		if (ship == null) {
			Destroy (go);
		} else {
			go.transform.SetParent (transform);
			ship.SetPlayerShip (GameObject.FindObjectOfType<PlayerShip> ());
			ship.Reset ();
		}

		toSpawn = Random.Range (1f, 1f);
		Invoke ("Spawn", toSpawn);
	}
}
