using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class SessionManager : MonoBehaviour
{
	public static SessionManager instance;

	public static System.DateTime sessionStartTime;
	public static System.TimeSpan sessionDuration;
	public static System.DateTime sessionEndTime;

	public static string participantName;
	public static string participantID;

	private static string filePath;
	private static int listID;

	public static List<Gift> giftList;
	public static List<Gift> giftInstanceList;
	private static int instanceIndex;

	// private static void SetupTest(){
	// 	participantName = "Andrew Shi";
	// 	participantID = "as4ac";
	// }

	private void Start () {
		if (null == instance) {
			instance = this;
		} else {
			Destroy(gameObject);
		}

        StartSession();
	}

	public static void StartSession () {
		// SetupTest();

    	filePath = Application.dataPath+"/Resources/Sessions/"+participantID+".txt";
        if(Resources.Load<TextAsset>("Sessions/"+participantID) == null)
        	CreateSessionList();
        else 
        	ResumeSessionList();

		giftList = new List<Gift>(Resources.LoadAll<Gift>("Gifts"));
		Dictionary<String, Gift> giftTable = new Dictionary<String, Gift>();
		foreach(Gift g in giftList){
			giftTable.Add(g.name, g);
		}
		
		giftInstanceList = new List<Gift>();
		foreach(String s in Resources.Load<TextAsset>("Lists/"+listID).ToString().Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries)){
			giftInstanceList.Add(giftTable[s]);
		}
	}

	public static void EndSession () {
		sessionEndTime = System.DateTime.Now;
		sessionDuration = sessionEndTime - sessionStartTime;

		SaveData();
	}

	public static void ResetSession () {

	}

	public static Gift NextGift () {
		instanceIndex++;
		return giftInstanceList[instanceIndex];
	}

	public static int ChooseList (){
		return 1;
	}

	public static void CreateSessionList () {
        listID = ChooseList();
        instanceIndex = -1;
		StreamWriter writer = new StreamWriter(filePath, true);
		writer.WriteLine(""+listID);
		writer.WriteLine(-1);
		writer.WriteLine(participantName);
		writer.WriteLine(participantID);
		writer.Close();
	}

	public static void ResumeSessionList () {
		StreamReader reader = new StreamReader(filePath);
        listID = Int32.Parse(reader.ReadLine());
        instanceIndex = Int32.Parse(reader.ReadLine());
        participantName = reader.ReadLine();
        participantID = reader.ReadLine();
        reader.Close();
	}

	public static void SaveData () {

	}
}
