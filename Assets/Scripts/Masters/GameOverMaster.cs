using UnityEngine;
using System.Collections;

public class GameOverMaster : MonoBehaviour {
	public Health Ship;

	void Awake () {
		Ship.OnHealthChange += delegate(float percentage) {
			if(percentage <= 0){
				GameStateMaster.Instance.EndGame();
			}
		};
	}
}
