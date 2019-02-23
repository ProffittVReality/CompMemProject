using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gift : MonoBehaviour {
	public GameObject prefab;

	public bool previouslySeenActual;
	public bool previouslySeenGuess;
	public bool guessedCorrectly;

	public Vector3 locationFoundAt;
	public int siteIDFoundAt;

	public float timeFoundAt;
	public int giftIndexFoundAt;
}
