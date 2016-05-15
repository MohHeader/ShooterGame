using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUI : MonoBehaviour {
	public Text HiScoreText;
	public Text ScoreText;

	void Start(){
		GameStateMaster.Instance.OnGameStart += delegate() {
			gameObject.SetActive (false);
		};
	}

	public void Show(){
		gameObject.SetActive (true);
		StartCoroutine (ShowScore ());
		HiScoreText.text = ScoreMaster.GetHiScore ().ToString ();
	}

	IEnumerator ShowScore(){
		int from = 0;
		ScoreText.text = from.ToString();
		while (from < ScoreMaster.Instance.Score) {
			from = Mathf.Min (ScoreMaster.Instance.Score, from + 1);
			ScoreText.text = from.ToString ();
			yield return new WaitForEndOfFrame ();
		}
	}
}
