﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	[Range(1, 99)]
	[SerializeField]
	protected float MaxHealth 		=	1;

	public float CurrentHealth { get; protected set; }

	// Events
	public event System.Action<float> OnHealthChange;

	void Start(){
		GameStateMaster.Instance.OnGameStart += Reset;
		Reset ();
	}

	void Reset(){
		CurrentHealth = MaxHealth;
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
