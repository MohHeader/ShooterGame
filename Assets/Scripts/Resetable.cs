using UnityEngine;
using System.Collections;

public class Resetable : MonoBehaviour {

	public event System.Action OnReset;

	void Start(){
		GameStateMaster.Instance.OnGameStart += Reset;
	}

	public void Reset(){
		if (OnReset != null)
			OnReset ();
	}
}
