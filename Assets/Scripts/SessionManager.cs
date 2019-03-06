using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct SessionInfo {
	public string participantID;
	public string participantName;

	public int listID;
	public List<GameObject> giftPrefabList;
	public int listIndex;

	public List<Gift> giftsOpenedList;
}

public class SessionManager : MonoBehaviour {
	#region VARIABLES
	public static string sessionPath;

	public static SessionManager instance;
	public static SessionInfo session;

	public string participantID;
	public string participantName;

	public SessionInfo info;
	#endregion


	private void Start () {
		if (null == instance) {
			instance = this;
		} else {
			Destroy(gameObject);
		}

		if (participantID == "") {
			Quit("Could not start session. Please fill out Participant ID in the Session Manager!");
			return;
		}

		sessionPath = Application.dataPath + "/Resources/Sessions/" + participantID + ".json";
		LoadData();
	}


	#region SELECTION
	public static GameObject NextGiftPrefab () {
		//modded by array size to loop around if user finds too many gifts
		GameObject gift = session.giftPrefabList[session.listIndex % session.giftPrefabList.Count];
		session.listIndex++;
		SaveData();
		return gift;
	}

	public static void ChooseList () {
		GiftList[] lists = Resources.LoadAll<GiftList>("Lists");
		if (lists.Length == 0) {
			Quit("Cannot assign list. Make sure there is at least 1 list in Assets/Resources/Lists");
			return;
		}

		int index = UnityEngine.Random.Range(0, lists.Length);
		session.listIndex = index;
		session.giftPrefabList = lists[index].gifts;
		SaveData();
	}

	public static IEnumerator GuessSeen (GameObject prefab, Transform instance) {

		bool guessed = false;

		bool seenBeforeActual = false;
		int giftIndex = -1;
		for (int i = 0; i < session.listIndex; i++) {
			if (session.giftPrefabList[i] == prefab) {
				seenBeforeActual = true;
				giftIndex = i;
				break;
			}
		}

		bool seenBeforeGuess = false;
		while (!guessed) {
			//TODO: Cut off player movement

			if (Input.GetKeyDown(KeyCode.Y)) {
				seenBeforeGuess = true;
				guessed = true;
			} else if (Input.GetKeyDown(KeyCode.N)) {
				seenBeforeGuess = false;
				guessed = true;
			}
			yield return new WaitForEndOfFrame();
		}

		Gift gift = new Gift();
		gift.prefab = prefab;
		gift.name = prefab.name;

		gift.previouslySeenGuess = seenBeforeGuess;
		gift.previouslySeenActual = seenBeforeActual;
		gift.guessedCorrectly = seenBeforeGuess == seenBeforeActual;

		gift.locationFoundAt = instance.position;
		gift.siteIDFoundAt = -1;

		gift.timeFoundAt = Time.time;
		gift.giftIndexFoundAt = giftIndex;

		session.giftsOpenedList.Add(gift);
	}
	#endregion


	#region SERIALIZATION
	public static void SaveData () {
		instance.info = session;

		string dataAsJson = JsonUtility.ToJson(session);
		File.WriteAllText(sessionPath, dataAsJson);
		print("Saved session data to " + sessionPath);
	}

	private static void LoadData () {
		if (File.Exists(sessionPath)) {
			print("Successfully loaded existing Participant Data");
			string dataAsJson = File.ReadAllText(sessionPath);
			session = JsonUtility.FromJson<SessionInfo>(dataAsJson);
			instance.participantName = session.participantName;
		} else {
			print("Creating new Participant Data");
			session = new SessionInfo();
			session.participantID = instance.participantID;
			session.participantName = instance.participantName;
			ChooseList();
		}
		instance.info = session;
	}
	#endregion


	#region APPLICATION
	public static void Quit(string errorMessage) {
		Debug.LogError(errorMessage);
		Quit();
	}

	public static void Quit () {
        #if UNITY_EDITOR
		    UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
	}
	#endregion


	#region CONVERSION
	//TODO
	public static string JsonToCsv () {
		return "";
	}

	public static string CsvToJson () {
		return "";
	}
	#endregion
}
