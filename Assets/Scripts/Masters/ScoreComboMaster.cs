using UnityEngine;
using System.Collections;

public class ScoreComboMaster : MonoBehaviour {
	bool comboMode = false;
	int scoreStart;
	int Hits;

	void Start () {
		ScoreMaster.Instance.OnScoreChange += ScoreChange;
		GameStateMaster.Instance.OnGameStart += delegate() {
			CancelInvoke("CalculateCombo");
		};
	}
	
	void ScoreChange (int score) {
		if (comboMode == false) {
			Hits = 0;
			scoreStart = score;
			comboMode = true;
			Invoke ("CalculateCombo", 2);
		}
		Hits++;
	}

	void CalculateCombo(){
		comboMode = false;

		int delta = ScoreMaster.Instance.Score - scoreStart;
		ScoreMaster.Instance.AddScore (Hits * delta);
	}
}
