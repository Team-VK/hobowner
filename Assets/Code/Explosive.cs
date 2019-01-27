using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

	private Rigidbody rb;

	public float explosionForce = 30000f;
	public float explosionRadius = 2000f;
	public float upwardsModifier = 10f;
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
		foreach (ObjectDrag o in ObjectSpawner.draggableList) {
            ObjectDrag g = (ObjectDrag) o;
			g.Exploder(explosionForce, transform.position, explosionRadius, upwardsModifier, mode);
		}
		ObjectSpawner.draggableList.Remove(this.GetComponent<ObjectDrag>());
		Destroy(this.gameObject);
	}
}
