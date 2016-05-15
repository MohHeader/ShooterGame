using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class StretchParticleSsytem : MonoBehaviour {
	void Awake () {
		ParticleSystem particles = GetComponent<ParticleSystem> ();
		var shape = particles.shape;
		shape.radius = ScreenSize.Size.x;
	}
}
