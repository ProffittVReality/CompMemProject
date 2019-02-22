using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gift List", menuName = "Gift List")]
public class GiftList : ScriptableObject {
	public List<GameObject> gifts;
}
