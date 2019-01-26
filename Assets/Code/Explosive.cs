using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

	private Rigidbody rb;

	private static float explosionForce = 300f;
	private static float explosionRadius = 20f;
	private static float upwardsModifier = 10f;
	private static ForceMode mode = ForceMode.Force;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		if (Input.GetMouseButton(1)) {
			Explode();
		}
	}

    // When explosive hits anything - explode
	void OnCollisionEnter(Collision coll) {
        //Explode();
	}

	void Explode() {
		object[] obj = GameObject.FindObjectsOfType(typeof (TomikTesting));
		foreach (object o in obj) {
			Debug.Log(transform.position);
			TomikTesting g = (TomikTesting) o;
			g.Exploder(explosionForce, transform.position, explosionRadius, upwardsModifier, mode);
		}
		Destroy(this.gameObject);
	}
}
