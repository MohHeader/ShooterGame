using UnityEngine;
using System.Collections;

public class ScoreComboMaster : MonoBehaviour {
	bool comboMode = false;
	int scoreStart;
	int Hits;

	void Start () {
		ScoreMaster.Instance.OnScoreChange += ScoreChange;
	}
	
	void ScoreChange (int score) {
		if (comboMode == false) {
			Hits = 0;
			scoreStart = score;
			comboMode = true;
			Invoke ("StopComboMode", 2);
		}
		Hits++;
	}

	void StopComboMode(){
		comboMode = false;

		int delta = ScoreMaster.Instance.Score - scoreStart;
		ScoreMaster.Instance.AddScore (Hits * delta);
	}
}
