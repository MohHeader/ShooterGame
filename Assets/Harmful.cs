using UnityEngine;
using System.Collections;

public class Harmful : MonoBehaviour {
	public float Amount;
	public bool SelfDestroy;

	public string EnemyTag;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag (EnemyTag) == false)
			return;
		
		Health health = other.gameObject.GetComponent<Health> ();
		if (health != null) {
			health.ChangeHealthBy (-Amount);

			if (SelfDestroy)
				SimplePool.Despawn (gameObject);
		}
	}
}
