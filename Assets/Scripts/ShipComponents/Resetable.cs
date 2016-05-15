using UnityEngine;
using System.Collections;

/// <summary>
/// Resetable. is a Component used per GameObjects to have it's own LifeCyecle, beside the GameStateMaster LifeCycle
/// Useful for GameObjects Spawned through Object Pool.
/// </summary>

public class Resetable : MonoBehaviour {

	public event System.Action OnReset;

	void OnEnable(){
		GameStateMaster.Instance.OnGameStart += Reset;
	}

	void OnDisable(){
		if(GameStateMaster.Instance != null)
			GameStateMaster.Instance.OnGameStart -= Reset;
	}

	public void Reset(){
		if (OnReset != null)
			OnReset ();
	}
}
