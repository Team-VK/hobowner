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
		//if (Input.GetMouseButton(1)) {
		//	Explode();
		//}
	}

    // When explosive hits anything - explode
	void OnCollisionEnter(Collision coll) {
        Explode();
	}

	void Explode() {
		object[] obj = GameObject.FindObjectsOfType(typeof (ObjectDrag));
		foreach (object o in ObjectSpawner.draggableList) {
			Debug.Log(transform.position);
            ObjectDrag g = (ObjectDrag) o;
			g.Exploder(explosionForce, transform.position, explosionRadius, upwardsModifier, mode);
		}
		Destroy(this.gameObject);
	}
}
