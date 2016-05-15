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
		state = GameState.NotStarted;
		Invoke("StartGame", 1);
	}

	void OnDestroy(){
		Instance = null;
	}

	public void StartGame(){
		Time.timeScale = 1f;
		state = GameState.Playing;
		if (OnGameStart != null)
			OnGameStart ();
	}

	public void PauseGame(){
		Time.timeScale = 0f;
		state = GameState.Pause;
		if (OnGamePause != null)
			OnGamePause ();
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		state = GameState.Playing;
		if (OnGameResume != null)
			OnGameResume ();
	}

	public void EndGame(){
		Time.timeScale = 0f;
		state = GameState.GameOver;

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
	public event System.Action OnGameResume;
	public event System.Action OnGameEnd;
}
