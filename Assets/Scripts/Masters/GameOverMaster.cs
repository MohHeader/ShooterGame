using UnityEngine;
using System.Collections;

public class GameOverMaster : MonoBehaviour {
	public Health Ship;
	public GameOverUI UI;

	void Awake () {
		Ship.OnHealthChange += delegate(float percentage) {
			if(percentage <= 0){
				Invoke("GameOver", 0.25f);
			}
		};
	}

	void GameOver(){
		GameStateMaster.Instance.EndGame();
		UI.Show();
	}
}
