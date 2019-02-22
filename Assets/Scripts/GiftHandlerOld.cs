using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class GiftHandler : MonoBehaviour
{

	//public static float startHeight = 20f;
	//public static float descentSeconds = 10f;

	//public bool showDebug = false;
	//public bool activated = false;

	//public bool grounded;
	//private bool groundedLF;

	//public bool isOpen;

	//private Vector3 startPosition;
	//private Vector3 targetPosition;

	//private float radius;

	//private float descentT;
	//private float hoverT;

	//private Vector3 initialScale;

	//private GameObject box;
	//private LineRenderer line;

	//private GameObject giftInstance;

	//private void Start () {
	//	descentT = 0f;
	//	hoverT = 0f;
	//	targetPosition = transform.position;
	//	startPosition = targetPosition + Vector3.up * startHeight;
	//	box = transform.GetChild(0).gameObject;

	//	line = box.GetComponent<LineRenderer>();
	//	line.enabled = true;
	//	line.useWorldSpace = true;
	//	line.SetPositions(new Vector3[] { startPosition, targetPosition - Vector3.up * 2f });

	//	radius = GetComponent<SphereCollider>().radius;

	//	box.SetActive(false);

	//	grounded = false;
	//	groundedLF = false;

	//	isOpen = false;

	//	initialScale = transform.localScale;
	//}

	//IEnumerator ToggleLine (bool turnOn = true) {
	//	if (turnOn) line.enabled = true;

	//	float width = line.widthMultiplier;
	//	float initial = (turnOn ? 0f : width);
	//	float final = (turnOn ? width : 0f);
	//	float velocity = 0f;

	//	float t = 0f;
	//	line.widthMultiplier = initial;
	//	while (Mathf.Abs(line.widthMultiplier - final) > 0.001f) {
	//		line.widthMultiplier = Mathf.SmoothDamp(line.widthMultiplier, final, ref velocity, 1f);
	//		yield return new WaitForEndOfFrame();
	//	}

	//	line.widthMultiplier = width;
	//	if (!turnOn) line.enabled = false;
	//}

	//// Update is called once per frame
	//private void Update () {
	//	if (activated) {
	//		transform.eulerAngles += Vector3.up * 360f * 0.25f * Time.deltaTime;
	//		if (descentT < 1f) {
	//			transform.position = Vector3.Lerp(startPosition, targetPosition, descentT += Time.deltaTime / descentSeconds);
	//			grounded = false;
	//		} else {
	//			transform.position = targetPosition - Vector3.up * Mathf.Sin(2 * Mathf.PI * (hoverT += Time.deltaTime * 0.5f)) * 0.5f;
	//			grounded = true;

	//			if (grounded && !groundedLF) {
	//				//StartCoroutine(ToggleLine(false));
	//			}

	//			if (Input.GetKeyDown(KeyCode.P)) {
	//				StartCoroutine(ResetGift());
	//			}
	//		}

	//		groundedLF = grounded;
	//	}

	//	if (Input.GetKeyDown(KeyCode.G)) {
	//		ActivateGift();
	//	}
	//}

	//public void ActivateGift () {
	//	if (!activated) {
	//		activated = true;
	//		box.SetActive(true);
	//		StartCoroutine(ToggleLine(true));
	//	}
	//}

	//public IEnumerator OpenGift () {
	//	if (!isOpen) {
	//		isOpen = true;

	//		GameObject gift = PickGift();

	//		if (gift != null && gift.prefab != null) {
	//			//TODO replace this with SessionManager.player reference
	//			Transform player = GameObject.FindWithTag("Player").transform;

	//			//Gift will always spawn looking at player
	//			giftInstance = Instantiate(gift.prefab, transform.position,
	//										 Quaternion.LookRotation(player.position - transform.position, Vector3.up)) as GameObject;

	//			//Assumes both objects have uniform scale across 3 axes
	//			float initialBoxScale = transform.localScale.x;
	//			float initialGiftScale = giftInstance.transform.localScale.x;

	//			float t = 0f;
	//			while (t < 1f) {
	//				transform.localScale = Vector3.Lerp(Vector3.one * initialBoxScale, Vector3.zero, t);
	//				giftInstance.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * initialGiftScale, t);
	//				t += Time.deltaTime * 0.25f;
	//				yield return new WaitForEndOfFrame();
	//			}
	//			transform.localScale = Vector3.zero;
	//			giftInstance.transform.localScale = Vector3.one * initialGiftScale;
	//		} else {
	//			Debug.LogError("Gift or Gift Prefab is null!");
	//		}
	//		yield return null;
	//	}
	//}

	////TODO: Andrew this is all you.
	//public GameObject PickGift () {
	//	return SessionManager.NextGiftPrefab();
	//}

	//public IEnumerator ResetGift () {
	//	StartCoroutine(ToggleLine(false));

	//	if (giftInstance) {
	//		float t = 0f;
	//		while(giftInstance.transform.localScale.x > 0f) {
	//			giftInstance.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t += Time.deltaTime / 2f);
	//			yield return new WaitForEndOfFrame();
	//		}
	//	}
	//	Destroy(giftInstance);
	//	activated = false;
	//	isOpen = false;
	//	transform.position = startPosition;
	//	box.SetActive(false);
	//	transform.localScale = initialScale;
	//	descentT = 0f;
	//	hoverT = 0f;
	//}

	//private void OnTriggerEnter (Collider other) {
	//	if (other.CompareTag("Player") && grounded) {
	//		StartCoroutine(OpenGift());
	//	}
	//}

	//private void OnDrawGizmos () {
	//	if (!showDebug) return;

	//	Gizmos.color = Color.yellow;
	//	Gizmos.DrawLine(transform.position, transform.position + Vector3.up * startHeight);
	//}
}
