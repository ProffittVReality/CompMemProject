using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
	public static SessionManager instance;

	public static System.DateTime sessionStartTime;
	public static System.TimeSpan sessionDuration;
	public static System.DateTime sessionEndTime;

	public static string participantName;
	public static string participantID;

	private static string fileName;

	public static List<Gift> giftList;
	public static List<GameObject> giftInstanceList;
	private static int instanceIndex;

	private void Start () {
		if (null == instance) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public static void StartSession () {
		sessionStartTime = System.DateTime.Now;

		fileName = sessionStartTime.Year.ToString() + "-" +
				   sessionStartTime.Month.ToString() + "-" +
				   sessionStartTime.Day.ToString() + "-" +
				   participantID;

		giftList = new List<Gift>(Resources.LoadAll<Gift>("Gifts"));
		giftInstanceList = new List<GameObject>();
		instanceIndex = -1;
	}

	public static void EndSession () {
		sessionEndTime = System.DateTime.Now;
		sessionDuration = sessionEndTime - sessionStartTime;

		SaveData();
	}

	public static void ResetSession () {

	}

	public static void SaveData () {

	}

	//public static Gift DecideNextGift () {
	//	List<Gift> allowedGifts = new List<Gift>();

	//	foreach (Gift gift in giftList) {
	//		bool allowed = true;

	//		//TODO
	//		if (null != gift.mustSpawnAfter) {
	//			if (gift.exclusivelySpawnAfter) {
	//				if (gift.mustSpawnAfter != giftInstanceList[instanceIndex]) {
	//					allowed = false;
	//				}
	//			} else {

	//			}
	//		}


	//	}
	//}
}
