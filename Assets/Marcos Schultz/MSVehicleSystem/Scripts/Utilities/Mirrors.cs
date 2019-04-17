using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirrors : MonoBehaviour {

	public bool enableMirrors = true;
	public Material standardMaterial;
	[Space(10)]
	public GameObject[] camerasArray;
	public GameObject[] mirrorsArray;

	void Start () {
		if (enableMirrors) {
			for (int x = 0; x < camerasArray.Length; x++) {
				camerasArray [x].gameObject.SetActive (true);
			}
		} else {
			for (int x = 0; x < mirrorsArray.Length; x++) {
				mirrorsArray [x].GetComponent<MeshRenderer> ().sharedMaterial = standardMaterial;
			}
		}
	}
}
