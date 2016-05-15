using UnityEngine;
using System.Collections;
/// <summary>
/// Stretch particle system to the full width.
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class StretchParticleSystem : MonoBehaviour {
	void Awake () {
		ParticleSystem particles = GetComponent<ParticleSystem> ();
		var shape = particles.shape;
		shape.radius = ScreenSize.Size.x;
	}
}
