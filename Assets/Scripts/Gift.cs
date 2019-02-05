using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gift", menuName = "Gift")]
public class Gift : ScriptableObject {

	[Header("Basic Info")]
	public new string name;
	public string description;

	public GameObject prefab;

	[Header("Spawn Criteria")]
	public Gift mustSpawnAfter;
	[Tooltip("false = can spawn at any time, true = can only spawn after above gift")]
	public bool exclusivelySpawnAfter;
	public List<Gift> temporallyAvoidList;
	[Tooltip("false = use number threshold, true = use seconds threshold")]
	public bool avoidBasedOnTime;
	[Tooltip("Number of in-between gifts to wait for before allowing this gift to spawn after one on the list")]
	public float numberThreshold;
	[Tooltip("Number of seconds to wait before allowing this gift to spawn after one on the list")]
	public float secondsThreshold;

	public List<Gift> geographicallyAvoidList;
	[Tooltip("Minimum distance this gift is allowed to spawn near any gift on the avoid list")]
	public float distanceThreshold;

	[Range(0, 5)]
	public int maxOccurences;
}
