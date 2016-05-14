using UnityEngine;
using System.Collections;

public class EnemySpawnerMaster : MonoBehaviour {
	public GameObject prefab;

	float toSpawnTimer;
	float timer;

	void Spawn(){
		GameObject go = SimplePool.Spawn (prefab, Vector3.zero, Quaternion.identity);
		EnemyShip ship =  go.GetComponent<EnemyShip>();

		if (ship == null) {
			Destroy (go);
		} else {
			go.transform.SetParent (transform);
			ship.SetPlayerShip (GameObject.FindObjectOfType<PlayerShip> ());
			ship.Reset ();
		}
	}

	void Update(){
		if (GameStateMaster.IsPlaying () == false)
			return;
		
		timer += Time.deltaTime;

		if (timer >= toSpawnTimer) {
			timer = 0;
			toSpawnTimer = Random.Range (1f, 2f);

			Spawn ();
		}
	}
}
