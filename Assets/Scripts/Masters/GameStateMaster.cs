using UnityEngine;
using System.Collections;

public enum GameState {
	NotStarted,
	Playing,
	Pause,
	GameOver
}

public class GameStateMaster : MonoBehaviour {

	public static GameStateMaster Instance;
	GameState state;

	void Awake () {
		Instance = this;
	}

	void Start(){
//		state = GameState.NotStarted;
		Invoke("StartGame", 1);
	}

	void OnDestroy(){
		Instance = null;
	}

	void StartGame(){
		print ("Game Started");
		state = GameState.Playing;
		if (OnGameStart != null)
			OnGameStart ();
	}

	void PauseGame(){
		state = GameState.Pause;
		if (OnGamePause != null)
			OnGamePause ();
	}

	public void EndGame(){
		state = GameState.GameOver;
		print ("GameOver");

		if (OnGameEnd != null)
			OnGameEnd ();
	}


	public static bool IsPlaying(){
		if (Instance != null) {
			return Instance.state == GameState.Playing;
		}
		return false;
	}

	public event System.Action OnGameStart;
	public event System.Action OnGamePause;
	public event System.Action OnGameEnd;
}
