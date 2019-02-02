using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftHandler : MonoBehaviour
{

	public static float startHeight = 20f;
	public static float descentSeconds = 10f;

	public bool activated = false;

	private Vector3 startPosition;
	private Vector3 targetPosition;

	private float descentT;
	private float hoverT;

	private GameObject box;
	private LineRenderer line;

	private void Start () {
		descentT = 0f;
		hoverT = 0f;
		targetPosition = transform.position;
		startPosition = targetPosition + Vector3.up * startHeight;
		box = transform.GetChild(0).gameObject;

		line = box.GetComponent<LineRenderer>();
		line.enabled = true;
		line.useWorldSpace = true;
		line.SetPositions(new Vector3[] { startPosition, targetPosition - Vector3.up * 2f });

		box.SetActive(false);
	}

	IEnumerator ToggleLine (bool turnOn = true) {
		if (turnOn) line.enabled = true;

		float width = line.widthMultiplier;
		float initial = (turnOn ? 0f : width);
		float final = (turnOn ? width : 0f);
		float velocity = 0f;

		float t = 0f;
		line.widthMultiplier = initial;
		while (Mathf.Abs(line.widthMultiplier - final) > 0.001f) {
			line.widthMultiplier = Mathf.SmoothDamp(line.widthMultiplier, final, ref velocity, 1f);
			yield return new WaitForEndOfFrame();
		}

		line.widthMultiplier = width;
		if (!turnOn) line.enabled = false;
	}

	// Update is called once per frame
	private void Update () {
		if (activated) {
			transform.eulerAngles += Vector3.up * 360f * 0.25f * Time.deltaTime;
			if (descentT < 1f) {
				transform.position = Vector3.Lerp(startPosition, targetPosition, descentT += Time.deltaTime / descentSeconds);
			} else {
				transform.position = targetPosition - Vector3.up * Mathf.Sin(2 * Mathf.PI * (hoverT += Time.deltaTime * 0.5f)) * 0.5f;
			}
		}

		if (Input.GetKeyDown(KeyCode.G)) {
			ActivateGift();
		}
	}

	public void ActivateGift () {
		activated = true;
		box.SetActive(true);
		StartCoroutine(ToggleLine(true));
	}

	public void ResetGift () {
		activated = false;
		box.SetActive(false);
		StartCoroutine(ToggleLine(false));
	}
}
