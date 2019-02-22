using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct SessionInfo {
	public string participantID;
	public string participantName;

	public int listID;
	public List<GameObject> giftPrefabList;
	public int listIndex;

	public List<Gift> giftsOpenedList;
}

public class SessionManager : MonoBehaviour {
	public static string sessionPath;

	public static SessionManager instance;
	public static SessionInfo session;

	public string participantID;
	public string participantName;

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

	public static GameObject NextGiftPrefab () {
		session.listIndex++;
		SaveData();
		return session.giftPrefabList[session.listIndex % session.giftPrefabList.Count]; //modded by array size to loop around if user finds too many gifts
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

	public static void SaveData () {
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
	}

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

	//TODO
	public static string JsonToCsv () {
		return "";
	}

	public static string CsvToJson () {
		return "";
	}
}
