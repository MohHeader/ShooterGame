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
		state = GameState.Playing;
	}

	void OnDestroy(){
		Instance = null;
	}

	void StartGame(){
		if (OnGameStart != null)
			OnGameStart ();
	}

	void PauseGame(){
		if (OnGamePause != null)
			OnGamePause ();
	}

	void EndGame(){
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
