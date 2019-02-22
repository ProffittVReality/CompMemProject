using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour {
	public GameObject prefab;

	public bool previouslySeenActual;
	public bool previouslySeenGuess;

	public Vector3 locationFoundAt;
	public int siteIDFoundAt;

	public float timeFoundAt;
	public int giftIndexFoundAt;
}
