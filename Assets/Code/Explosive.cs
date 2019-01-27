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
        Explode(coll);
	}

	void Explode(Collision coll) {
		foreach (ObjectDrag o in ObjectSpawner.draggableList) {
            ObjectDrag g = (ObjectDrag) o;

            Rigidbody collidingObject = coll.rigidbody;
            if (!(collidingObject.gameObject.name == "raindrop(Clone)")) {
                g.Exploder(explosionForce, transform.position, explosionRadius, upwardsModifier, mode);
                ObjectSpawner.draggableList.Remove(this.GetComponent<ObjectDrag>());
                Destroy(this.gameObject);
                Debug.Log("######## EXPLODING: " + g.gameObject.name);

            }
		}
		
	}
}
