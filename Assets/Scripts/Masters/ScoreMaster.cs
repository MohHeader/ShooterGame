using UnityEngine;
using System.Collections;

public class ScoreMaster : MonoBehaviour {
	public static readonly string HI_SCORE_PREFS_KEY = "HiScore";
	public int Score { get; protected set; }

	public static ScoreMaster Instance;

	void Awake(){
		Instance = this;
	}

	void Start () {
		GameStateMaster.Instance.OnGameStart += delegate() {
			SetScore (0);
		};

		GameStateMaster.Instance.OnGameEnd += delegate() {
			if(Score > GetHiScore()){
				SetHiScore(Score);
			}
		};
	}

	public void AddScore(int points){
		SetScore (Score + points);
	}

	void SetScore(int s){
		Score = s;

		if(OnScoreChange != null)
			OnScoreChange (Score);
	}

	public static int GetHiScore(){
		return PlayerPrefs.GetInt (HI_SCORE_PREFS_KEY, 0);
	}

	public static void SetHiScore(int score){
		int Hi = GetHiScore();

		if (score > Hi) {
			PlayerPrefs.SetInt (HI_SCORE_PREFS_KEY, score);
		}
	}

	public event System.Action<int> OnScoreChange;
}
