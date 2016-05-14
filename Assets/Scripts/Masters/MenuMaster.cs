using UnityEngine;
using System.Collections;

public class MenuMaster : MonoBehaviour {
	public GameObject PausePanel;

	void Start(){
		GameStateMaster.Instance.OnGamePause += delegate() {
			PausePanel.SetActive(true);
		};

		GameStateMaster.Instance.OnGameStart += delegate() {
			PausePanel.SetActive(false);
		};

		GameStateMaster.Instance.OnGameResume += delegate() {
			PausePanel.SetActive(false);
		};
	}

	public void Pause(){
		GameStateMaster.Instance.PauseGame ();
	}

	public void Resume(){
		GameStateMaster.Instance.ResumeGame ();
	}

	public void Restart(){
		GameStateMaster.Instance.StartGame ();

	}
}
