using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBoxSpawner : MonoBehaviour {
	#region VARIABLES
	[Header("Debug")]
	[SerializeField] private bool showGizmos;

	[Header("Gift Box Info")]
	[SerializeField] private float spawnRadius = 30f;
	[SerializeField] private float openRadius = 3f;
	[SerializeField] private float boxSecondsSpentDescending = 10f;

	[SerializeField] private float boxRotateDegreesPerSecond = 60f;
	[SerializeField] private float boxIdleOscillateAmplitude = 0.5f;
	[SerializeField] private float boxIdleOscillatePeriod = 2f;
	private float boxIdleOscillateFrequency;

	[SerializeField] private float cooldownSeconds = 500f;
	private float currentCooldownSeconds;

	[SerializeField] private float secondsSpentOpeningGift = 5f;


	[Header("Transforms")]
	[SerializeField] private Transform spawnLocation;
	[SerializeField] private Transform giftLocation;
	[SerializeField] private Transform giftBox;


	[Header("Line")]
	[SerializeField] private bool usingLineRenderer;
	[SerializeField] private float lineRendererWidth = 0.5f;
	[SerializeField] private Color lineRendererColor;
	[SerializeField] private float lineToggleTime = 1f;
	private LineRenderer line;
	private float lineT;
	private bool turningOn;


	[Header("SFX")]
	[SerializeField] private bool useSound;
	[SerializeField] private AudioClip pingClip;
	[SerializeField] private bool repeatSound;
	[SerializeField] private float secondsBetweenRepeats = 5f;


	private bool primed = false;
	private bool active = false;
	private bool open = false;

	private float oscillateT;
	private float rad;

	private SphereCollider col;
	#endregion


	#region EXECUTION
	private void Start () {
		giftBox.gameObject.SetActive(false);
		giftBox.transform.position = spawnLocation.position;

		primed = false;
		active = false;
		open = false;

		oscillateT = 0f;
		rad = Mathf.PI * 2f;
		boxIdleOscillateFrequency = 1 / boxIdleOscillatePeriod;

		col = gameObject.AddComponent<SphereCollider>();
		col.radius = spawnRadius;
		col.isTrigger = true;

		if (usingLineRenderer) {
			line = gameObject.AddComponent<LineRenderer>();
			line.widthMultiplier = lineRendererWidth;
			line.startColor = lineRendererColor;
			line.endColor = lineRendererColor;
			line.enabled = false;
			turningOn = false;
			line.material = new Material(Shader.Find("Particles/Standard Unlit"));
			line.numCapVertices = 16;
		}
	}

	private void Update () {
		giftBox.Rotate(Vector3.up, boxRotateDegreesPerSecond * Time.deltaTime);
		if (active) {
			giftBox.position += Vector3.up * Mathf.Sin(rad * boxIdleOscillateFrequency * oscillateT) * boxIdleOscillateAmplitude;
			oscillateT += Time.deltaTime;

			if (open) return;

			Collider[] thingsInside = Physics.OverlapSphere(giftLocation.position, openRadius);

			foreach (Collider thing in thingsInside) {
				if (thing.CompareTag("Player")) {
					StartCoroutine(OpenGift(thing.transform));
					break;
				}
			}
		}
	}

	private void OnTriggerEnter (Collider other) {
		if (!primed && other.CompareTag("Player")) {
			giftBox.gameObject.SetActive(true);
			StartCoroutine(Descend());

			if (useSound && pingClip) {
				if (repeatSound) {
					InvokeRepeating("Ping", 0f, secondsBetweenRepeats);
				} else {
					Invoke("Ping", 0f);
				}
			}
		}
	}

	private void OnDrawGizmos () {
		if (!showGizmos) return;

		Gizmos.color = new Color(0f, 1f, 1f, 1f);
		Gizmos.DrawWireSphere(transform.position, spawnRadius);
		Gizmos.DrawWireSphere(transform.position, openRadius);

		if (spawnLocation) {
			Gizmos.color = new Color(1f, 0f, 0f, 1f);
			Gizmos.DrawLine(transform.position, spawnLocation.position);
			Gizmos.DrawWireSphere(spawnLocation.position, 1f);
		}
	}
	#endregion


	#region COROUTINES
	private IEnumerator OpenGift (Transform player) {
		open = true;


		GameObject giftPrefab = SessionManager.NextGiftPrefab();
		print("Gift: " + giftPrefab.name);
		Transform giftInstance = Instantiate(giftPrefab).transform;
		giftInstance.position = giftBox.position;

		StartCoroutine(SessionManager.GuessSeen(giftPrefab, giftInstance));

		Vector3 maxBoxScale = giftBox.localScale;

		Vector3 maxGiftScale = giftInstance.localScale;
		giftInstance.localScale = Vector3.zero;

		StartCoroutine(OscillateGift(giftInstance));
		Vector3 targetDirection = player.position - giftInstance.position;
		targetDirection.y = giftInstance.position.y;
		giftInstance.LookAt(targetDirection, Vector3.up);

		float t = 0f;

		while (t < 1f) {
			giftInstance.position = giftBox.position;

			giftInstance.localScale = Vector3.Lerp(Vector3.zero, maxGiftScale, t);
			giftBox.localScale = Vector3.Lerp(maxBoxScale, Vector3.zero, t);

			t += Time.deltaTime / secondsSpentOpeningGift;
			yield return new WaitForEndOfFrame();
		}

		giftInstance.localScale = maxGiftScale;
		giftBox.localScale = Vector3.zero;
	}

	private IEnumerator OscillateGift (Transform gift) {
		while (gift != null) {
			gift.position += Vector3.up * Mathf.Sin(rad * boxIdleOscillateFrequency * oscillateT) * boxIdleOscillateAmplitude;
			oscillateT += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}

	private IEnumerator ToggleLine () {
		turningOn = !turningOn;
		line.enabled = true;
		line.SetPositions(new Vector3[] { spawnLocation.position, giftLocation.position });

		float start = 0f;
		float end = lineRendererWidth;
		float target = (turningOn ? 1f : 0f);
		while (Mathf.Abs(target - lineT) > Time.deltaTime) {
			line.widthMultiplier = Mathf.Lerp(start, end, lineT);

			if (turningOn) {
				lineT += Time.deltaTime / lineToggleTime;
			} else {
				lineT -= Time.deltaTime / lineToggleTime;
			}
			yield return new WaitForEndOfFrame();
		}

		if (turningOn) {
			lineT = 1f;
			line.widthMultiplier = end;
		} else {
			lineT = 0f;
			line.widthMultiplier = 0f;
			line.enabled = false;
		}
	}

	private IEnumerator Descend () {
		primed = true;

		if (usingLineRenderer) {
			StopCoroutine(ToggleLine());
			StartCoroutine(ToggleLine());
		}

		Vector3 start = spawnLocation.position;
		Vector3 end = giftLocation.position;
		float t = 0f;
		giftBox.position = start;
		while (t < 1f) {
			giftBox.position = Vector3.Lerp(start, end, t);
			t += Time.deltaTime / boxSecondsSpentDescending;
			yield return new WaitForEndOfFrame();
		}
		giftBox.position = end;

		if (usingLineRenderer) {
			StopCoroutine(ToggleLine());
			StartCoroutine(ToggleLine());
		}
		active = true;
	}
	#endregion


	#region MISC
	private void Ping () {
		if (pingClip != null && !active) {
			GameObject audioObject = new GameObject("PingAudio");
			audioObject.transform.SetParent(giftBox);
			AudioSource audioSource = audioObject.AddComponent<AudioSource>();
			audioSource.clip = pingClip;
			audioSource.spatialBlend = 0f;
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.dopplerLevel = 0f;
			audioSource.playOnAwake = false;
			audioSource.maxDistance = spawnRadius * 2f;
			audioSource.Play();
			Destroy(audioObject, pingClip.length + 0.25f);
		}
	}
	#endregion
}
