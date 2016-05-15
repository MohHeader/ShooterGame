using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Resetable))]
public class Health : MonoBehaviour {
	[Range(1, 99)]
	public float MaxHealth;

	float CurrentHealth;
	Resetable resetable;

	// Events
	public event System.Action<float> OnHealthChange;

	void Awake(){
		resetable = GetComponent<Resetable> ();
	}

	void OnEnable(){
		resetable.OnReset += Reset;		
	}

	void OnDisable(){
		resetable.OnReset -= Reset;
	}

	void Reset(){
		CurrentHealth = MaxHealth;

		if (OnHealthChange != null)
			OnHealthChange (GetCurrentHealthPerecntage());
	}

	public void ChangeHealthBy(float delta){
		CurrentHealth += delta;
		CurrentHealth = Mathf.Max (CurrentHealth, 0);

		if (OnHealthChange != null)
			OnHealthChange (GetCurrentHealthPerecntage());
	}

	public float GetCurrentHealthPerecntage(){
		if (MaxHealth == 0) {
			Debug.LogError ("Max Health for Ship : " + gameObject.name + "is ZERO 0, that should never be" );
			return 0;
		}
		return CurrentHealth / MaxHealth;
	}
}
