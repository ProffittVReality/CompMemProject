using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_VehicleInformation : MonoBehaviour {

	MSSceneController controls; //main scene Controller
	bool error;

	GameObject myCanvasOBJ;

	Button nextVehicle;
	Button previousVehicle;
	Text gearText;
	Text kmhText;
	Text mphText;
	Text rpmText;
	Text damageText; 
	Text fuelText;
	Text handBrakeText;
	Text automaticGearsText;
	Text pauseText;
	Slider heightVehicleSlider;

	float timerStringsOnScreen = 0;
	int clampGear;
	bool playerIsNull;
	int nextVehicleInt;
	int nextIndex;

	void Start () {
		controls = GameObject.FindObjectOfType (typeof(MSSceneController))as MSSceneController;
		if (!controls) {
			Debug.LogError ("There must be an object with the 'MSSceneController' component so that vehicles can be managed.");
			error = true;
			this.transform.gameObject.SetActive (false);
			return;
		}
		if (controls.error) {
			error = true;
			this.transform.gameObject.SetActive (false);
			return;
		}
		//
		myCanvasOBJ = transform.Find ("Canvas").gameObject;
		// UI.Find interactive
		nextVehicle = transform.Find ("Canvas/Default/nextVehicle").GetComponent<Button> ();
		previousVehicle = transform.Find ("Canvas/Default/previousVehicle").GetComponent<Button> ();
		heightVehicleSlider = transform.Find ("Canvas/Default/heightSlider").GetComponent<Slider> ();
		// UI.Find strings
		gearText = transform.Find ("Canvas/Strings/gearText").GetComponent<Text> ();
		kmhText = transform.Find ("Canvas/Strings/kmhText").GetComponent<Text> ();
		mphText = transform.Find ("Canvas/Strings/mphText").GetComponent<Text> ();
		rpmText = transform.Find ("Canvas/Strings/rpmText").GetComponent<Text> ();
		damageText = transform.Find ("Canvas/Strings/damageText").GetComponent<Text> ();
		fuelText = transform.Find ("Canvas/Strings/fuelText").GetComponent<Text> ();
		handBrakeText = transform.Find ("Canvas/Strings/handBrakeText").GetComponent<Text> ();
		automaticGearsText = transform.Find ("Canvas/Strings/automaticGearsText").GetComponent<Text> ();
		pauseText = transform.Find ("Canvas/Strings/pauseText").GetComponent<Text> ();

		//
		if (heightVehicleSlider) {
			heightVehicleSlider.value = 0.0f;
		}

		if (nextVehicle) {
			nextVehicle.onClick = new Button.ButtonClickedEvent ();
			nextVehicle.onClick.AddListener (() => NextVehicle ());
		}
		if (previousVehicle) {
			previousVehicle.onClick = new Button.ButtonClickedEvent ();
			previousVehicle.onClick.AddListener (() => PreviousVehicle ());
		}
		if (controls.vehicles.Length < 2) {
			nextVehicle.gameObject.SetActive(false);
			previousVehicle.gameObject.SetActive (false);
		} else {
			nextVehicle.gameObject.SetActive(true);
			previousVehicle.gameObject.SetActive (true);
		}

		timerStringsOnScreen = 0.0f;
		playerIsNull = false;
		if (!controls.player) {
			playerIsNull = true;
		}
		EnableUI (true);
	}

	void Update () {
		timerStringsOnScreen += Time.fixedDeltaTime;
		if (timerStringsOnScreen >= 0.1f) {//Update 10Hz (Is sufficient and reduces GC.Collect)
			timerStringsOnScreen = 0;
			EnableUI (controls.vehicleCode.isInsideTheCar);
			//
			if (controls.vehicles.Length > 0 && controls.currentVehicle < controls.vehicles.Length && controls.vehicleCode) {
				if (controls.vehicleCode.isInsideTheCar) {
					clampGear = Mathf.Clamp (controls.vehicleCode.currentGear, -1, 1);
					if (clampGear == 0) {
						clampGear = 1;
					}

					gearText.text = "Gear: " + controls.vehicleCode.currentGear;
					kmhText.text = "Velocity(km/h): " + (int)(controls.vehicleCode.KMh * clampGear);
					mphText.text = "Velocity(mp/h): " + (int)(controls.vehicleCode.KMh * 0.621371f * clampGear);
					rpmText.text = "RPM: " + (int)controls.vehicleCode._vehicleSettings.vehicleRPMValue;
					damageText.text = "Damage: " + (int)((1 - (controls.vehicleCode.vehicleLife / controls.vehicleCode._damage.damageSupported)) * 100) + "%";
					fuelText.text = "Fuel: " + (int)((controls.vehicleCode.currentFuelLiters / controls.vehicleCode._fuel.capacityInLiters) * 100) + "%";
					handBrakeText.text = "HandBreak: " + controls.vehicleCode.handBrakeTrue;
					automaticGearsText.text = "AutomaticGears: " + controls.vehicleCode.automaticGears;
					pauseText.text = "Pause: " + controls.pause;

					controls.vehicleCode.SetSuspensionExtraHeight (heightVehicleSlider.value);
				}
			}
		}
		if (controls.blockedInteraction) {
			timerStringsOnScreen = 0.0f;
			EnableUI (controls.vehicleCode.isInsideTheCar);
		}
	}

	void EnableUI(bool enable){
		myCanvasOBJ.SetActive (enable);
		if (controls.vehicles.Length < 2) {
			nextVehicle.gameObject.SetActive(false);
			previousVehicle.gameObject.SetActive (false);
		} else {
			nextVehicle.gameObject.SetActive(true);
			previousVehicle.gameObject.SetActive (true);
		}
	}

	public void PreviousVehicle(){
		if (!error) {
			if (playerIsNull) {
				if (controls.vehicles.Length > 1) {
					controls.currentVehicle--;
					EnableVehicle (controls.currentVehicle + 1);
				}
			} else {
				if (controls.vehicles.Length > 1 && !controls.player.gameObject.activeInHierarchy) {
					controls.currentVehicle--;
					EnableVehicle (controls.currentVehicle + 1);
				}
			}
		}
	}

	public void NextVehicle(){
		if (!error) {
			if (playerIsNull) {
				if (controls.vehicles.Length > 1) {
					controls.currentVehicle++;
					EnableVehicle (controls.currentVehicle - 1);
				}
			} else {
				if (controls.vehicles.Length > 1 && !controls.player.gameObject.activeInHierarchy) {
					controls.currentVehicle++;
					EnableVehicle (controls.currentVehicle - 1);
				}
			}
		}
	}

	void EnableVehicle(int index){
		controls.currentVehicle = Mathf.Clamp (controls.currentVehicle, 0, controls.vehicles.Length-1);
		if (index != controls.currentVehicle) {
			if (controls.vehicles [controls.currentVehicle]) {
				if (controls.vehicles [controls.currentVehicle].activeInHierarchy) {
					//change vehicle
					for (int x = 0; x < controls.vehicles.Length; x++) {
						controls.vehicles [x].GetComponent<MSVehicleController> ().ExitTheVehicle ();
					}
					controls.vehicles [controls.currentVehicle].GetComponent<MSVehicleController> ().EnterInVehicle ();
					//
					//reset heightVehicleSlider 
					controls.vehicleCode = controls.vehicles [controls.currentVehicle].GetComponent<MSVehicleController> ();
					heightVehicleSlider.value = controls.vehicleCode._wheels.leftFrontWheel.wheelCollider.suspensionDistance - controls.vehicleCode._suspension.constVehicleHeightStart;
				} else {
					nextVehicleInt = controls.currentVehicle - index;
					nextIndex = -1;
					// 
					if (nextVehicleInt > 0) { //next Vehicle
						for (int x = controls.currentVehicle; x < controls.vehicles.Length; x++) {
							if (controls.vehicles [x].activeInHierarchy) {
								nextIndex = x;
								break;
							}
						}  
					} else { //previous Vehicle
						for (int x = controls.currentVehicle; x >= 0; x--) { 
							if (controls.vehicles [x].activeInHierarchy) {
								nextIndex = x; 
								break;
							}
						}
					}
					//

					//enable vehicle in nextIndex element of array
					if (nextIndex >= 0) { 
						if (controls.vehicles [controls.currentVehicle]) {
							controls.currentVehicle = nextIndex;
							//change vehicle
							for (int x = 0; x < controls.vehicles.Length; x++) {
								controls.vehicles [x].GetComponent<MSVehicleController> ().ExitTheVehicle ();
							}
							controls.vehicles [controls.currentVehicle].GetComponent<MSVehicleController> ().EnterInVehicle ();
							//
							//reset heightVehicleSlider 
							controls.vehicleCode = controls.vehicles [controls.currentVehicle].GetComponent<MSVehicleController> ();
							heightVehicleSlider.value = controls.vehicleCode._wheels.leftFrontWheel.wheelCollider.suspensionDistance - controls.vehicleCode._suspension.constVehicleHeightStart;
						}
					} else {
						controls.currentVehicle = index;
						//change vehicle
						for (int x = 0; x < controls.vehicles.Length; x++) {
							controls.vehicles [x].GetComponent<MSVehicleController> ().ExitTheVehicle ();
						}
						controls.vehicles [controls.currentVehicle].GetComponent<MSVehicleController> ().EnterInVehicle ();
						//
						//reset heightVehicleSlider 
						controls.vehicleCode = controls.vehicles [controls.currentVehicle].GetComponent<MSVehicleController> ();
						heightVehicleSlider.value = controls.vehicleCode._wheels.leftFrontWheel.wheelCollider.suspensionDistance - controls.vehicleCode._suspension.constVehicleHeightStart;
					}
					//
				}
			}
		}
		//
		EnableUI (controls.vehicleCode.isInsideTheCar);
	}
}
