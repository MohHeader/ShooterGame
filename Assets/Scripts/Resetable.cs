using UnityEngine;
using System.Collections;

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
