using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {
	Text ScoreText;

	void Awake(){
		ScoreText = GetComponent<Text> ();
	}

	void Start(){
		ScoreMaster.Instance.OnScoreChange += SetScore;
	}

	public void SetScore(int score){
		ScoreText.text = score.ToString ();
	}
}
