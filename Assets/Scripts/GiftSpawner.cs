using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class GiftSpawner : MonoBehaviour {
	public static GameObject player;

	private SphereCollider collider;
	private float radius;

	private GiftHandler giftHandler;

	private float currentCooldownSeconds;
	private static float maxCooldownSeconds = 10f;

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
		radius = collider.radius;

		giftHandler = gameObject.GetComponentInChildren<GiftHandler>();

		currentCooldownSeconds = 0f;
	}

    // Update is called once per frame
    void Update () {
        if (currentCooldownSeconds < 0f) {
			currentCooldownSeconds = 0f;
		} else {
			currentCooldownSeconds -= Time.deltaTime;
		}
	}

	public void SpawnGift () {
		giftHandler.ActivateGift();
	}

	public void DespawnGift () {

	}

	public void OpenGift () {

	}

	private void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player") && currentCooldownSeconds == 0f) {
			print("Spawning gift");
			SpawnGift();
		}
	}

	private void OnTriggerStay (Collider other) {
		if (other.CompareTag("Player")) {
			//if ((transform.position - player.transform.position).sqrMagnitude < innerRadiusSqr) {
				//OpenGift();
			//}
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.CompareTag("Player")) {
			DespawnGift();
		}
	}
}
