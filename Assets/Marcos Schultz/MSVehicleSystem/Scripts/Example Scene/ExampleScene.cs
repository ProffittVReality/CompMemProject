using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleScene : MonoBehaviour {

	public enum StartD {Day, Night};
	public StartD initialState = StartD.Day;

	public GameObject DirectionalLight;
	public Color dayColor = new Color(1,1,1);
	public Color nightColor = new Color(0.05f,0.05f,0.05f);
	public bool UIVisualizer = true;

	public bool enableStreetLampsOnNight = false;
	GameObject lightsObject;
	GameObject meshLightsOn;
	GameObject meshLightsOff;
	Light[] streetLamps;

	GameObject canvasScene;

	bool night;
	bool controllsIsNull;
	bool playerIsNull;
	MSSceneController controls;

	Button dayNightButton;
	Image backGround;
	Text controlsText;
	Text increaseText;
	Text decreaseText;
	Text enterAndExitText;
	Text startVehicleText;
	Text lightsText;
	Text reloadText;
	Text hornText;
	Text handBrakeText;
	Text switchCamerasText;
	Text pauseText;
	Text manualOrAutoGearsText;
	GameObject player;

	void Awake(){
		controllsIsNull = false;
		controls = GameObject.FindObjectOfType (typeof(MSSceneController))as MSSceneController;
		//
		canvasScene = transform.Find ("Canvas").gameObject;
		//
		backGround = transform.Find ("Canvas/Background").GetComponent<Image> ();
		controlsText = transform.Find ("Canvas/Background/ControlText").GetComponent<Text> ();
		increaseText = transform.Find ("Canvas/Background/IncreasedGear").GetComponent<Text> ();
		decreaseText = transform.Find ("Canvas/Background/DecreasedGear").GetComponent<Text> ();
		enterAndExitText = transform.Find ("Canvas/Background/Enter_ExitVehicle").GetComponent<Text> ();
		startVehicleText = transform.Find ("Canvas/Background/StartTheVehicle").GetComponent<Text> ();
		lightsText = transform.Find ("Canvas/Background/Lights").GetComponent<Text> ();
		reloadText = transform.Find ("Canvas/Background/ReloadScene").GetComponent<Text> ();
		hornText = transform.Find ("Canvas/Background/Horn").GetComponent<Text> ();
		handBrakeText = transform.Find ("Canvas/Background/HandBrake").GetComponent<Text> ();
		switchCamerasText = transform.Find ("Canvas/Background/SwitchCameras").GetComponent<Text> ();
		pauseText = transform.Find ("Canvas/Background/Pause").GetComponent<Text> ();
		manualOrAutoGearsText = transform.Find ("Canvas/Background/ManualOrAutoGears").GetComponent<Text> ();
		dayNightButton = transform.Find ("Canvas/DayNightButton").GetComponent<Button> ();
		if (dayNightButton) {
			dayNightButton.onClick = new Button.ButtonClickedEvent ();
			dayNightButton.onClick.AddListener (() => DayNightButton ());
		}

		//streetLights
		lightsObject = transform.Find ("Lights").gameObject;
		meshLightsOn = lightsObject.transform.Find ("Meshes/lightsOn").gameObject;
		meshLightsOff = lightsObject.transform.Find ("Meshes/lightsOff").gameObject;
		streetLamps = lightsObject.transform.GetComponentsInChildren <Light> ();
		//

		if (!controls) {
			UIVisualizer = false;
			controllsIsNull = true;
			EnableUI (false);
			canvasScene.SetActive (false);
			return;
		}
		canvasScene.SetActive (true);
		if (!UIVisualizer) {
			EnableUI (false);
		} else {
			EnableUI (true);
		}
		playerIsNull = false;
		player = controls.player;
		if (!player) {
			playerIsNull = true;
		}
		//
		increaseText.text = "Increased Gear: " + controls.controls.increasedGear.ToString ();
		decreaseText.text = "Decreased Gear: " + controls.controls.decreasedGear.ToString ();
		enterAndExitText.text = "Enter/Exit Vehicle: " + controls.controls.enterEndExit.ToString ();
		startVehicleText.text = "Start the vehicle: " + controls.controls.startTheVehicle.ToString ();
		reloadText.text = "Reload Scene: " + controls.controls.reloadScene.ToString ();
		hornText.text = "Horn: " + controls.controls.hornInput.ToString ();
		handBrakeText.text = "Hand Brake: " + controls.controls.handBrakeInput.ToString ();
		switchCamerasText.text = "Switch Cameras: " + controls.controls.switchingCameras.ToString ();
		pauseText.text = "Pause: " + controls.controls.pause.ToString ();
		manualOrAutoGearsText.text = "ManualOrAutoGears: " + controls.controls.manualOrAutoGears.ToString ();
		lightsText.text = "Lights = '" + controls.controls.mainLightsInput.ToString () + "', '" + controls.controls.warningLightsInput.ToString () + "', '" 
			+ controls.controls.headlightsInput.ToString () + "', '" + controls.controls.extraLightsInput.ToString () + "', '" 
			+ controls.controls.flashesLeftAlert.ToString () + "', '" + controls.controls.flashesRightAlert.ToString ();
	}

	void Start(){
		switch (initialState) {
		case StartD.Day:
			night = false;
			DirectionalLight.transform.localEulerAngles = new Vector3 (50, -30, 0);
			DirectionalLight.GetComponent<Light> ().intensity = 1;
			RenderSettings.reflectionIntensity = 1;
			RenderSettings.ambientSkyColor = dayColor;
			if (enableStreetLampsOnNight) {
				for (int x = 0; x < streetLamps.Length; x++) {
					if (streetLamps [x]) {
						streetLamps [x].enabled = false;
					}
				}
				meshLightsOn.SetActive (false);
				meshLightsOff.SetActive (true);
			}
			break;
		case StartD.Night:
			night = true;
			DirectionalLight.transform.localEulerAngles = new Vector3 (-70, -30, 0);
			DirectionalLight.GetComponent<Light> ().intensity = 0;
			RenderSettings.reflectionIntensity = 0;
			RenderSettings.ambientSkyColor = nightColor;
			if (enableStreetLampsOnNight) {
				for (int x = 0; x < streetLamps.Length; x++) {
					if (streetLamps [x]) {
						streetLamps [x].enabled = true;
					}
				}
				meshLightsOn.SetActive (true);
				meshLightsOff.SetActive (false);
			}
			break;
		}
		DirectionalLight.SetActive (true);
		RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
	}

	void Update(){
		if (!controllsIsNull) {
			if (!playerIsNull) {
				if (player.gameObject.activeInHierarchy) {
					EnableUI (false);
				} else {
					EnableUI (UIVisualizer);
				}
			} else {
				EnableUI (UIVisualizer);
			}
		}
	}

	void EnableUI(bool enable){
		if (backGround.gameObject.activeSelf != enable) {
			backGround.gameObject.SetActive(enable);
			dayNightButton.gameObject.SetActive (enable);
			controlsText.gameObject.SetActive (enable);
			increaseText.gameObject.SetActive (enable);
			decreaseText.gameObject.SetActive (enable);
			enterAndExitText.gameObject.SetActive (enable);
			startVehicleText.gameObject.SetActive (enable);
			lightsText.gameObject.SetActive (enable);
			reloadText.gameObject.SetActive (enable);
			hornText.gameObject.SetActive (enable);
			handBrakeText.gameObject.SetActive (enable);
			switchCamerasText.gameObject.SetActive (enable);
			pauseText.gameObject.SetActive (enable);
			manualOrAutoGearsText.gameObject.SetActive (enable);
		}
	}

	void DayNightButton(){
		night = !night;
		if (night) {
			DirectionalLight.transform.localEulerAngles = new Vector3 (-70, -30, 0);
			DirectionalLight.GetComponent<Light> ().intensity = 0;
			RenderSettings.ambientSkyColor = nightColor;
			RenderSettings.reflectionIntensity = 0;
			//
			if (enableStreetLampsOnNight) {
				for (int x = 0; x < streetLamps.Length; x++) {
					if (streetLamps [x]) {
						streetLamps [x].enabled = true;
					}
				}
				meshLightsOn.SetActive (true);
				meshLightsOff.SetActive (false);
			}
		} else {
			DirectionalLight.transform.localEulerAngles = new Vector3 (50, -30, 0);
			DirectionalLight.GetComponent<Light> ().intensity = 1;
			RenderSettings.ambientSkyColor = dayColor;
			RenderSettings.reflectionIntensity = 1;
			//
			if (enableStreetLampsOnNight) {
				for (int x = 0; x < streetLamps.Length; x++) {
					if (streetLamps [x]) {
						streetLamps [x].enabled = false;
					}
				}
				meshLightsOn.SetActive (false);
				meshLightsOff.SetActive (true);
			}
		}
	}
}
