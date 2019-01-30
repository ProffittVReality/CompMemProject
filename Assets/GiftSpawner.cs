using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
	public static float innerRadius;
	private static float innerRadiusSqr;
	public static float outerRadius;
	public static GameObject player;

	public bool showDebug = false;

	private SphereCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        if (null == player) {
			player = GameObject.FindWithTag("Player");
		}

		if (null == collider) {
			if (null == (collider = GetComponent<SphereCollider>())) {
				collider = gameObject.AddComponent<SphereCollider>();
			}
		}

		collider.isTrigger = true;
		collider.radius = outerRadius;
		innerRadiusSqr = innerRadius * innerRadius;
	}

    // Update is called once per frame
    void Update () {
        
    }

	public void SpawnGift () {

	}

	public void DespawnGift () {

	}

	public void OpenGift () {

	}

	private void OnDrawGizmosSelected () {
		if (!showDebug) return;

		Gizmos.color = new Color(0f, 1f, 1f, 0.5f);
		Gizmos.DrawSphere(transform.position, 10f);
	}

	private void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")) {
			SpawnGift();
		}
	}

	private void OnTriggerStay (Collider other) {
		if (other.CompareTag("Player")) {
			if ((transform.position - player.transform.position).sqrMagnitude < innerRadiusSqr) {
				OpenGift();
			}
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.CompareTag("Player")) {
			DespawnGift();
		}
	}
}
