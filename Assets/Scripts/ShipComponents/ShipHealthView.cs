using UnityEngine;
using System.Collections;

public class ShipHealthView : MonoBehaviour {
	public Sprite[] HealthLevelsSprites;
	int SpriteIndex = -1;

	SpriteRenderer spriteRenderer;
	void Awake () {
		Health health = GetComponentInParent<Health> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		if (health == null) {
			Debug.LogError ("A ship that has no Health component attached to it");
			return;
		}

		health.OnHealthChange += UpdateShipSprite;
	}
	
	void UpdateShipSprite(float percentage){
		if (HealthLevelsSprites.Length == 0)
			return;
		
		int index = Mathf.FloorToInt((1 - Mathf.Clamp01(percentage)) * (HealthLevelsSprites.Length - 1));

		if (index == SpriteIndex)
			return;

		SpriteIndex = index;
		spriteRenderer.sprite = HealthLevelsSprites [SpriteIndex];
	}
}
