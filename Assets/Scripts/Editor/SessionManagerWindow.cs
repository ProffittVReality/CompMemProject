using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SessionManagerWindow : EditorWindow {

	[MenuItem("Sessions/Open Session")]
	public static void Init () {
		SessionManagerWindow window = (SessionManagerWindow)EditorWindow.GetWindow(typeof(SessionManagerWindow));
	}

	private void OnGUI () {

	}
}
