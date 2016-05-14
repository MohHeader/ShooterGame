using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public Health Ship;

	Image image;

	void Awake () {
		Ship.OnHealthChange += UpdateHealthBar;
		image = GetComponent<Image> ();
	}
	
	void UpdateHealthBar (float percentage) {
		image.fillAmount = percentage;
	}
}
