using UnityEngine;
using System.Collections;

public enum ShipBehavior {
	None,
	Kamikaze
}

public class EnemyShipBehaviourComponents : MonoBehaviour {
	public void SetShip(EnemyShipData data){
		switch (data.shipBehavior) {
		case ShipBehavior.Kamikaze:
			gameObject.AddComponent<Kamikaze> ();
			break;
		case ShipBehavior.None:			
		default:
			break;
		}
	}
}
