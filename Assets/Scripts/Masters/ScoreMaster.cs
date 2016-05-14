using UnityEngine;
using System.Collections;

public class ScoreMaster : MonoBehaviour {
	public int Score { get; protected set; }

	public static ScoreMaster Instance;

	void Awake(){
		Instance = this;
	}

	void Start () {
		GameStateMaster.Instance.OnGameStart += delegate() {
			SetScore (0);
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

	public event System.Action<int> OnScoreChange;
}
