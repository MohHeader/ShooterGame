using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnerMaster : MonoBehaviour {
	public GameObject EnemyShipBasePrefab;
	public EnemySpawnerData shipsData;

	public float MinTimeToSpawn = 1f;
	public float MaxTimeToSpawn = 2f;

	public PlayerShip TargetPlayer;

	float ToSpawnTimer;
	float SpawntimeLeft;

	// ProtoType Pattern ( Based on Ship Behaviors )
	// i.e. Each Unique behavior would have it's own special prototype ( Data fields are easily resetable )
	Dictionary<ShipBehavior, GameObject> PrototypeDict;

	void Awake(){
		if (TargetPlayer == null) {
			TargetPlayer = GameObject.FindObjectOfType<PlayerShip> ();
		}

		PrototypeDict = new Dictionary<ShipBehavior, GameObject> ();
		foreach (var ship in shipsData.ships) {
			if (PrototypeDict.ContainsKey (ship.shipBehavior) == false) {
				GameObject go = Instantiate<GameObject> (EnemyShipBasePrefab);
				go.SetActive (false);
				go.name = "Proto_" + ship.shipBehavior;
				go.transform.SetParent (transform);
				go.AddComponent<EnemyShip> ();
				go.AddComponent<EnemyShipBehaviourComponents> ().SetShip (ship);
				go.AddComponent<EnemyShipDataComponents> ();
				PrototypeDict [ship.shipBehavior] = go;
			}
		}
	}

	void Spawn(EnemyShipData data){
		if (PrototypeDict.ContainsKey (data.shipBehavior) == false) {
			Debug.LogError ("Trying to Spawn a ship with a behavior not listed in the Spawner data list");
			return;
		}

		GameObject go = SimplePool.Spawn (PrototypeDict[data.shipBehavior], Vector3.zero, Quaternion.identity);
		go.transform.SetParent (transform);
		go.name = "Ship_" + data.shipBehavior;

		EnemyShip ship =  go.GetComponent<EnemyShip>();

		if (ship == null) {
			Destroy (go);
		} else {
			ship.SetPlayerShip (TargetPlayer);
			go.GetComponent<EnemyShipDataComponents> ().SetShip (data);
			ship.Reset ();
		}
	}

	void Update(){
		if (GameStateMaster.IsPlaying () == false)
			return;
		
		SpawntimeLeft += Time.deltaTime;

		if (SpawntimeLeft >= ToSpawnTimer) {
			SpawntimeLeft = 0;
			ToSpawnTimer = Random.Range (MinTimeToSpawn, MaxTimeToSpawn);

			if (shipsData.ships.Length == 0) {
				Debug.LogError ("Enemy Ship spawner has empty data set");
				return;
			}

			Spawn (shipsData.ships[Random.Range(0, shipsData.ships.Length)]);
		}
	}
}
