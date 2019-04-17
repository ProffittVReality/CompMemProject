using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System;

[Serializable]
public class Controls {
	[Header("Gears")]
	[Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_increasedGear_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_increasedGear_Button_Mobile = true;
	[Tooltip("The key that must be pressed to increase the vehicle's current gear.")]
	public KeyCode increasedGear = KeyCode.LeftShift;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button increasedGearMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_decreasedGear_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_decreasedGear_Button_Mobile = true;
	[Tooltip("The key that must be pressed to decrease the vehicle's current gear.")]
	public KeyCode decreasedGear = KeyCode.LeftControl;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button decreasedGearMobileButton;

	[Space(10)][Header("Lights")]
	[Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_flashesRightAlert_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_flashesRightAlert_Button_Mobile = true;
	[Tooltip("The key that must be pressed turns on or off the blinking lights on the right side of the vehicle.")]
	public KeyCode flashesRightAlert = KeyCode.E;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button flashesRightAlertMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_flashesLeftAlert_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_flashesLeftAlert_Button_Mobile = true;
	[Tooltip("The key that must be pressed turns on or off the blinking lights on the left side of the vehicle.")]
	public KeyCode flashesLeftAlert = KeyCode.Q;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button flashesLeftAlertMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_mainLightsInput_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_mainLightsInput_Button_Mobile = true;
	[Tooltip("The key that must be pressed to turn the vehicle main lights on or off.")]
	public KeyCode mainLightsInput = KeyCode.L;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button mainLightsMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_extraLightsInput_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_extraLightsInput_Button_Mobile = true;
	[Tooltip("The key that must be pressed to turn the vehicle extra lights on or off.")]
	public KeyCode extraLightsInput = KeyCode.K;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button extraLightsMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_headlightsInput_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_headlightsInput_Button_Mobile = true;
	[Tooltip("The key that must be pressed to turn the vehicle headlights on or off.")]
	public KeyCode headlightsInput = KeyCode.J;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button headlightsMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_warningLightsInput_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_warningLightsInput_Button_Mobile = true;
	[Tooltip("The key that must be pressed to turn the vehicle warning lights on or off.")]
	public KeyCode warningLightsInput = KeyCode.H;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button warningLightsMobileButton;

	[Space(10)][Header("Game")]
	[Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_reloadScene_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_reloadScene_Button_Mobile = true;
	[Tooltip("The key that must be pressed to reload the current scene.")]
	public KeyCode reloadScene = KeyCode.R;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button reloadSceneMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_pause_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_pause_Button_Mobile = true;
	[Tooltip("The key that must be pressed to pause the game.")]
	public KeyCode pause = KeyCode.P;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button pauseMobileButton;

	[Space(10)][Header("Vehicle")]
	[Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_startTheVehicle_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_startTheVehicle_Button_Mobile = true;
	[Tooltip("The key that must be pressed to turn the vehicle engine on or off.")]
	public KeyCode startTheVehicle = KeyCode.F;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button startTheVehicleMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_enterEndExit_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_enterEndExit_Button_Mobile = true;
	[Tooltip("The key that must be pressed to enter or exit the vehicle.")]
	public KeyCode enterEndExit = KeyCode.T;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button enterEndExitMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_hornInput_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_hornInput_Button_Mobile = true;
	[Tooltip("The key that must be pressed to emit the horn sound of the vehicle.")]
	public KeyCode hornInput = KeyCode.B;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button hornMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_handBrakeInput_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_handBrakeInput_Button_Mobile = true;
	[Tooltip("The key that must be pressed to activate or deactivate the vehicle hand brake.")]
	public KeyCode handBrakeInput = KeyCode.Space;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button handBrakeMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_switchingCameras_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_switchingCameras_Button_Mobile = true;
	[Tooltip("The key that must be pressed to toggle between the cameras of the vehicle.")]
	public KeyCode switchingCameras = KeyCode.C;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button switchingCamerasMobileButton;

	[Space(15)][Tooltip("If this variable is true, the control for this variable will be activated.")]
	public bool enable_manualOrAutoGears_Input_key = true;
	[Tooltip("If this variable is true, the control for this variable will be enabled on the mobile buttons.")]
	public bool enable_manualOrAutoGears_Button_Mobile = true;
	[Tooltip("The key that must be pressed to leave the vehicle in manual gears or automatic gears.")]
	public KeyCode manualOrAutoGears = KeyCode.O;
	[Tooltip("In this variable it is possible to associate a 'UI Button' to execute the described command.")]
	public Button manualOrAutoGearsMobileButton;
}

[Serializable]
public class SensibilityControlsMobile{
	[Range(0.1f, 5.0f)][Tooltip("Here you can set the speed at which you can zoom in or out of the vehicle camera.")]
	public float speedScrollWheelMobile = 0.5f;

	[Header("Mobile Joystick")]
	[Range(0.1f,10.0f)][Tooltip("The speed at which the input of the joystick will be passed to the vehicle.")]
	public float speedJoystickMove = 5.0f;
	[Range(0.1f,10.0f)][Tooltip("The speed at which the input of the joystick will be passed to the vehicle camera.")]
	public float speedJoystickCamera = 0.4f;

	[Space(10)][Header("Mobile Button")]
	[Range(0.5f,10.0f)][Tooltip("The speed at which the input of the button will be passed to the vehicle.")]
	public float speedButtonMove = 5.0f;
	[Range(0.5f,10.0f)][Tooltip("The speed at which the input of the button will be passed to the vehicle.")]
	public float speedButtonDirection = 5.0f;
	[Range(0.1f,10.0f)][Tooltip("The speed at which the input of the joystick will be passed to the vehicle camera.")]
	public float _speedJoystickCamera = 0.4f;

	[Space(10)][Header("Mobile Volant")]
	[Range(1.0f,15.0f)][Tooltip("The speed at which the joystick input will be passed to the steering wheel of the vehicle.")]
	public float speedMobileVolant = 10.0f;
}

public class MSSceneController : MonoBehaviour {
	
	[Space(-7)][Header("---- Controls ----")]
	#region defineInputs
	[Tooltip("Vertical input recognized by the system")]
	public string _verticalInput = "Vertical";

	[Tooltip("Horizontal input recognized by the system")]
	public string _horizontalInput = "Horizontal";

	[Tooltip("Horizontal input for camera movements")]
	public string _mouseXInput = "Mouse X";

	[Tooltip("Vertical input for camera movements")]
	public string _mouseYInput = "Mouse Y";

	[Tooltip("Scroll input, to zoom in and out of the cameras.")]
	public string _mouseScrollWheelInput = "Mouse ScrollWheel";
	#endregion

	public enum ControlType{windows, mobileJoystick, mobileButton, mobileVolant};
	[Space(10)][Tooltip("Here you can select the type of control, where 'Mobile Button' will cause buttons to appear on the screen so that vehicles can be controlled, 'Mobile Joystick' will cause two Joysticks to appear on the screen so vehicles can be controlled, 'windows' will allow vehicles to be controlled through the computer, and 'Mobile Volant' will make a steering wheel and two pedals appear on the screen, allowing you to control the vehicle through them.")]
	public ControlType selectControls = ControlType.windows;

	[Tooltip("Here you can configure the vehicle controls, choose the desired inputs and also, deactivate the unwanted ones.")]
	public Controls controls;
	[Tooltip("Here you can configure the sensitivity of the controls for mobile devices.")]
	public SensibilityControlsMobile sensitivityOfMobileControls;
	[Space(5)][Header("---- Vehicle list ----")][Tooltip("All vehicles in the scene containing the 'MS Vehicle Controller' component must be associated with this list.")]
	public GameObject[] vehicles;

	[Space(10)][Header("---- Settings ----")][Tooltip("If this variable is true and if you have a player associated with the 'player' variable, the game will start at the player. Otherwise, the game will start in the starting vehicle, selected in the variable 'startingVehicle'.")]
	public bool startInPlayer = false;
	[Tooltip("This variable is responsible for defining the vehicle in which the player will start. It represents an index of the 'vehicles' list, where the number placed here represents the index of the list. The selected index will be the starting vehicle.")]
	public int startingVehicle = 0;
	[Tooltip("The player must be associated with this variable. This variable should only be used if your scene also has a player other than a vehicle. This \"player\" will temporarily be disabled when you get in a vehicle, and will be activated again when you leave a vehicle.")]
	public GameObject player;
	[Tooltip("This is the minimum distance the player needs to be in relation to the door of a vehicle, to interact with it.")]
	public float minDistance = 3;

	[Space(10)][Header("---- UI Text ----")][Tooltip("If this variable is true, a warning will appear on the screen every time the player approaches a vehicle, informing which key it is necessary to press to enter the vehicle.")]
	public bool pressKeyUI = true;

	[Space(10)][Header("---- Optimization ----")]
	[Tooltip("If this variable is true, the vehicle controller will deactivate vehicles that are further away from the player in order to improve performance.")]
	public bool disableVehicleByDistance = true;
	[Tooltip("If the variable 'disableVehicleByDistance' is true, the code will disable vehicles that are far from the player, according to this variable. In this way, you can set the distance at which vehicles will be activated or deactivated.")]
	public float distanceDisable = 500;



	//
	float timerOptimizationLoop = 0;

	GameObject myCanvas;

	Joystick joystickMove;
	Joystick joystickRotate;
	Joystick joystickCamera;
	MSButton buttonLeft;
	MSButton buttonRight;
	MSButton buttonUp;
	MSButton buttonDown;
	MSButton buttonScrollUp;
	MSButton buttonScrollDown;

	Text enterOrExitVehicleText;

	#region customizeInputs
	[HideInInspector]
	public float verticalInput = 0;
	[HideInInspector]
	public float horizontalInput = 0;
	[HideInInspector]
	public float mouseXInput = 0;
	[HideInInspector]
	public float mouseYInput = 0;
	[HideInInspector]
	public float mouseScrollWheelInput = 0;
	#endregion

	[HideInInspector]
	public bool blockedInteraction = false;
	bool enterAndExitBool;
	bool enterAndExitTextBool;
	string sceneName;


	MSVehicleController controllerTemp;

	float MSbuttonHorizontal;
	float MSbuttonVertical;

	[HideInInspector]
	public int currentVehicle = 0;
	[HideInInspector]
	public MSVehicleController vehicleCode;
	[HideInInspector]
	public bool pause = false;
	[HideInInspector]
	public bool error;

	bool interactBool;

	Vector2 vectorDirJoystick;

	//mobile buttons boolean
	[HideInInspector]
	public bool increasedGearInputBool = false;
	[HideInInspector]
	public bool decreasedGearInputBool = false;
	[HideInInspector]
	public bool flashesRightAlertBool = false;
	[HideInInspector]
	public bool flashesLeftAlertBool = false;
	[HideInInspector]
	public bool mainLightsInputBool = false;
	[HideInInspector]
	public bool extraLightsInputBool = false;
	[HideInInspector]
	public bool headlightsInputBool = false;
	[HideInInspector]
	public bool warningLightsInputBool = false;
	[HideInInspector]
	public bool startTheVehicleInputBool = false;
	[HideInInspector]
	public bool hornInputBool = false;
	[HideInInspector]
	public bool handBrakeInputBool;
	[HideInInspector]
	public bool returnHandBrakeInputBool;
	[HideInInspector]
	public bool manualOrAutoGearsInputBool = false;
	//end


	//mobile volant variables
	Graphic androidInputVolant;
	RectTransform rectT;
	Vector2 centerPoint;
	private float maxAngle = 200.0f;
	private float rotateSpeed = 200.0f;
	float wheelAngle = 0.0f;
	float wheelPrevAngle = 0.0f;
	bool wheelBeingHeld = false;
    //end

    private bool reversing;

    void Awake () {
        reversing = false;

		error = false;
		CheckEqualKeyCodes ();
		MSSceneController[] sceneControllers = FindObjectsOfType(typeof(MSSceneController)) as MSSceneController[];
		if (sceneControllers.Length > 1) {
			Debug.LogError ("Only one controller is allowed per scene, otherwise the controllers would conflict with each other.");
			error = true;
			for (int x = 0; x < sceneControllers.Length; x++) {
				sceneControllers [x].gameObject.SetActive (false);
			}
		}
		if (startingVehicle >= vehicles.Length) {
			startingVehicle = 0;
			Debug.LogWarning ("Vehicle selected to start does not exist in the 'vehicles' list");
		}
		if (vehicles.Length == 0) {
			error = true;
			Debug.LogError ("There is no vehicle in the scene or no vehicle has been associated with the controller.");
		}
		for (int x = 0; x < vehicles.Length; x++) {
			if (vehicles [x]) {
				if (!vehicles [x].GetComponent<MSVehicleController> ()) {
					error = true;
					Debug.LogError ("The vehicle associated with the index " + x + " does not have the 'MSVehicleController' component. So it will be disabled.");
				}
			}else{
				error = true;
				Debug.LogError ("No vehicle was associated with the index " + x + " of the vehicle list.");
			}
		}
		if (error) {
			for (int x = 0; x < vehicles.Length; x++) {
				if (vehicles [x]) {
					MSVehicleController component = vehicles [x].GetComponent<MSVehicleController> ();
					if (component) {
						component.disableVehicle = true;
					}
					vehicles [x].SetActive (false);
				}
			}
			return;
		}
		else {
			//UI transform.find
			myCanvas = transform.Find ("Canvas").gameObject;
			myCanvas.SetActive (true);

			joystickMove = transform.Find ("Canvas/Default/JoystickM").GetComponent<Joystick> ();
			joystickRotate = transform.Find ("Canvas/Default/JoystickR").GetComponent<Joystick> ();
			joystickCamera = transform.Find ("Canvas/Default/MSJoystickCamera").GetComponent<Joystick> ();

			buttonLeft = transform.Find ("Canvas/Default/MSButtonLeft").GetComponent<MSButton> ();
			buttonRight = transform.Find ("Canvas/Default/MSButtonRight").GetComponent<MSButton> ();
			buttonUp = transform.Find ("Canvas/Default/MSButtonUp").GetComponent<MSButton> ();
			buttonDown = transform.Find ("Canvas/Default/MSButtonDown").GetComponent<MSButton> ();

			buttonScrollUp = transform.Find ("Canvas/Default/scrollUp").GetComponent<MSButton> ();
			buttonScrollDown = transform.Find ("Canvas/Default/scrollDown").GetComponent<MSButton> ();

			androidInputVolant = transform.Find ("Canvas/Default/volant").GetComponent<Graphic> ();

			enterOrExitVehicleText = transform.Find ("Canvas/Default/enterVehicleText").GetComponent<Text> ();
			enterAndExitTextBool = false;
			interactBool = false;
			if (enterOrExitVehicleText) {
				enterOrExitVehicleText.text = "Press '" + controls.enterEndExit + "' to enter the vehicle.";
				enterOrExitVehicleText.enabled = false;
			}


			SetVoidsOnMobileButtons ();//initialize buttons


			if (androidInputVolant) {
				//initialize event system and volant mobile
				maxAngle = rotateSpeed = 200.0f;
				rectT = androidInputVolant.rectTransform;
				InitEventsSystem();
				UpdateRect();
			}

			vehicleCode = vehicles [currentVehicle].GetComponent<MSVehicleController> ();
			EnableOrDisableButtons (vehicleCode.isInsideTheCar);
			ResetMobileButtonInputs (); 

			Time.timeScale = 1;
			enterAndExitBool = false;
			sceneName = SceneManager.GetActiveScene ().name;
			currentVehicle = startingVehicle;
			//
			for (int x = 0; x < vehicles.Length; x++) {
				if (vehicles [x]) {
					vehicles [x].GetComponent<MSVehicleController> ().isInsideTheCar = false;
				}
			}

			if (player) {
				player.SetActive (false);
			}
			if (startInPlayer) {
				if (player) {
					player.SetActive (true);
				} else {
					startInPlayer = false;
					if (vehicles.Length > startingVehicle && vehicles [currentVehicle]) {
						vehicles [startingVehicle].GetComponent<MSVehicleController> ().isInsideTheCar = true;
					}
				}
			} else {
				if (vehicles.Length > startingVehicle && vehicles [currentVehicle]) {
					vehicles [startingVehicle].GetComponent<MSVehicleController> ().isInsideTheCar = true;
				}
			}
			//
			timerOptimizationLoop = 0;
		}
	}

	void SetVoidsOnMobileButtons (){
		//gears
		if (controls.increasedGearMobileButton) {
			controls.increasedGearMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.increasedGearMobileButton.onClick.AddListener (() => Mobile_IncreasedGearButton ());
		} else {
			controls.enable_increasedGear_Button_Mobile = false;
		}

		if (controls.decreasedGearMobileButton) {
			controls.decreasedGearMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.decreasedGearMobileButton.onClick.AddListener (() => Mobile_DecreasedGearButton ());
		} else {
			controls.enable_decreasedGear_Button_Mobile = false;
		}

		//
		//
		//lights
		if (controls.flashesRightAlertMobileButton) {
			controls.flashesRightAlertMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.flashesRightAlertMobileButton.onClick.AddListener (() => Mobile_FlashesRightAlertButton ());
		} else {
			controls.enable_flashesRightAlert_Button_Mobile = false;
		}

		if (controls.flashesLeftAlertMobileButton) {
			controls.flashesLeftAlertMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.flashesLeftAlertMobileButton.onClick.AddListener (() => Mobile_FlashesLeftAlertButton ());
		} else {
			controls.enable_flashesLeftAlert_Button_Mobile = false;
		}

		if (controls.mainLightsMobileButton) {
			controls.mainLightsMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.mainLightsMobileButton.onClick.AddListener (() => Mobile_MainLightsButton ());
		} else {
			controls.enable_mainLightsInput_Button_Mobile = false;
		}

		if (controls.extraLightsMobileButton) {
			controls.extraLightsMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.extraLightsMobileButton.onClick.AddListener (() => Mobile_ExtraLightsButton ());
		} else {
			controls.enable_extraLightsInput_Button_Mobile = false;
		}

		if (controls.headlightsMobileButton) {
			controls.headlightsMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.headlightsMobileButton.onClick.AddListener (() => Mobile_HeadLightsButton ());
		} else {
			controls.enable_headlightsInput_Button_Mobile = false;
		}

		if (controls.warningLightsMobileButton) {
			controls.warningLightsMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.warningLightsMobileButton.onClick.AddListener (() => Mobile_WarningLightsButton ());
		} else {
			controls.enable_warningLightsInput_Button_Mobile = false;
		}

		//
		//
		//game
		if (controls.reloadSceneMobileButton) {
			controls.reloadSceneMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.reloadSceneMobileButton.onClick.AddListener (() => Mobile_ReloadSceneButton ());
		} else {
			controls.enable_reloadScene_Button_Mobile = false;
		}

		if (controls.pauseMobileButton) {
			controls.pauseMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.pauseMobileButton.onClick.AddListener (() => Mobile_PauseButton ());
		} else {
			controls.enable_pause_Button_Mobile = false;
		}

		//
		//
		//vehicle
		if (controls.startTheVehicleMobileButton) {
			controls.startTheVehicleMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.startTheVehicleMobileButton.onClick.AddListener (() => Mobile_StartTheVehicleButton ());
		} else {
			controls.enable_startTheVehicle_Button_Mobile = false;
		}

		if (controls.enterEndExitMobileButton) {
			controls.enterEndExitMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.enterEndExitMobileButton.onClick.AddListener (() => Mobile_EnterAndExitButton ());
		} else {
			controls.enable_enterEndExit_Button_Mobile = false;
		}

		if (controls.hornMobileButton) {
			controls.hornMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.hornMobileButton.onClick.AddListener (() => Mobile_HornButton ());
		} else {
			controls.enable_hornInput_Button_Mobile = false;
		}

		if (controls.handBrakeMobileButton) {
			controls.handBrakeMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.handBrakeMobileButton.onClick.AddListener (() => Mobile_HandBrakeButton ());
		} else {
			controls.enable_handBrakeInput_Button_Mobile = false;
		}

		if (controls.switchingCamerasMobileButton) {
			controls.switchingCamerasMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.switchingCamerasMobileButton.onClick.AddListener (() => Mobile_SwitchingCamerasInputButton ());
		} else {
			controls.enable_switchingCameras_Button_Mobile = false;
		}

		if (controls.manualOrAutoGearsMobileButton) {
			controls.manualOrAutoGearsMobileButton.onClick = new Button.ButtonClickedEvent ();
			controls.manualOrAutoGearsMobileButton.onClick.AddListener (() => Mobile_ManualOrAutoGearsButton ());
		} else {
			controls.enable_manualOrAutoGears_Button_Mobile = false;
		}
	}

	void CheckEqualKeyCodes(){
		var type = typeof(Controls);
		var fields = type.GetFields();
		var values = (from field in fields
			where field.FieldType == typeof(KeyCode)
			select (KeyCode)field.GetValue(controls)).ToArray();

		foreach (var value in values) {
			if (Array.FindAll (values, (a) => {
				return a == value;
			}).Length > 1) {
				Debug.LogError ("There are similar commands in the 'controls' list. Use different keys for each command.");
				error = true;
			}
		}
	}
	 
	void Update () {
        if (reversing && Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            reversing = false;
        } else if (!reversing && Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            reversing = true;
        }

		if (!error) {
			#region customizeInputsValues
			switch (selectControls) {
			case ControlType.mobileVolant:
				if(androidInputVolant){
					if(!wheelBeingHeld && !Mathf.Approximately(0.0f, wheelAngle )){
						float deltaAngle = rotateSpeed * Time.deltaTime;
						if(Mathf.Abs(deltaAngle) > Mathf.Abs(wheelAngle )){
							wheelAngle = 0.0f;
						}else if(wheelAngle > 0.0f){
							wheelAngle -= deltaAngle;
						}else{
							wheelAngle += deltaAngle;
						}
					}
					MSbuttonHorizontal = (wheelAngle/maxAngle);
					rectT.localEulerAngles = Vector3.back * wheelAngle;
				}
				if(buttonUp && buttonDown){
					MSbuttonVertical = (-buttonDown.buttonInput + buttonUp.buttonInput);
				}
				if(joystickCamera){
					mouseXInput = Mathf.Lerp(mouseXInput, joystickCamera.joystickHorizontal * sensitivityOfMobileControls._speedJoystickCamera, Time.deltaTime * 5);
					mouseYInput = Mathf.Lerp(mouseYInput, joystickCamera.joystickVertical * sensitivityOfMobileControls._speedJoystickCamera, Time.deltaTime * 5);
				}
				verticalInput = Mathf.Lerp(verticalInput, MSbuttonVertical, Time.deltaTime * sensitivityOfMobileControls.speedButtonMove);
				horizontalInput = Mathf.Lerp(horizontalInput, MSbuttonHorizontal, Time.deltaTime * sensitivityOfMobileControls.speedMobileVolant);
				//
				if(buttonScrollUp && buttonScrollDown){
					mouseScrollWheelInput = (-buttonScrollDown.buttonInput + buttonScrollUp.buttonInput) * Time.deltaTime * sensitivityOfMobileControls.speedScrollWheelMobile; 
				}
				break;
			case ControlType.mobileButton:
				if(buttonLeft && buttonRight){
					MSbuttonHorizontal = (-buttonLeft.buttonInput + buttonRight.buttonInput);
				}
				if(buttonUp && buttonDown){
					MSbuttonVertical = (-buttonDown.buttonInput + buttonUp.buttonInput);
				}
				if(joystickCamera){
					mouseXInput = Mathf.Lerp(mouseXInput, joystickCamera.joystickHorizontal * sensitivityOfMobileControls._speedJoystickCamera, Time.deltaTime * 5);
					mouseYInput = Mathf.Lerp(mouseYInput, joystickCamera.joystickVertical * sensitivityOfMobileControls._speedJoystickCamera, Time.deltaTime * 5);
				}
				verticalInput = Mathf.Lerp(verticalInput, MSbuttonVertical, Time.deltaTime * sensitivityOfMobileControls.speedButtonMove);
				horizontalInput = Mathf.Lerp(horizontalInput, MSbuttonHorizontal, Time.deltaTime * sensitivityOfMobileControls.speedButtonDirection);
				//
				if(buttonScrollUp && buttonScrollDown){
					mouseScrollWheelInput = (-buttonScrollDown.buttonInput + buttonScrollUp.buttonInput) * Time.deltaTime * sensitivityOfMobileControls.speedScrollWheelMobile; 
				}
				break;
				//====================================================================================
			case ControlType.mobileJoystick:
				if(joystickMove || joystickRotate){
					if(joystickMove){
						vectorDirJoystick = new Vector2(joystickMove.joystickHorizontal,joystickMove.joystickVertical);
						if(vectorDirJoystick.magnitude > 1){
							vectorDirJoystick.Normalize();
						}
						if(joystickMove.joystickVertical >= 0){
							verticalInput = vectorDirJoystick.magnitude;
						}else{
							verticalInput = -vectorDirJoystick.magnitude;
						}
						horizontalInput = Mathf.Lerp(horizontalInput, joystickMove.joystickHorizontal, Time.deltaTime * sensitivityOfMobileControls.speedJoystickMove);
					}
					if(joystickRotate){
						mouseXInput = Mathf.Lerp(mouseXInput, joystickRotate.joystickHorizontal * sensitivityOfMobileControls.speedJoystickCamera, Time.deltaTime * 5.0f);
						mouseYInput = Mathf.Lerp(mouseYInput, joystickRotate.joystickVertical * sensitivityOfMobileControls.speedJoystickCamera, Time.deltaTime * 5.0f);
					}
					//
					if(buttonScrollUp && buttonScrollDown){
						mouseScrollWheelInput = (-buttonScrollDown.buttonInput + buttonScrollUp.buttonInput) * Time.deltaTime * sensitivityOfMobileControls.speedScrollWheelMobile; 
					}
				}
				break;
				//====================================================================================
			case ControlType.windows:
                //verticalInput = Mathf.Clamp(Input.GetAxis (_verticalInput), 0, 1) + Mathf.Clamp(Input.GetAxis("Brake"), -1, 0);
                float brake = (Input.GetAxis("Brake") - 1f) / -2f;
                    //GUI.TextField()
                    print("Brake: " + brake);

                    if (Vector3.Dot(vehicles[0].GetComponent<Rigidbody>().velocity, vehicles[0].transform.forward) < -float.Epsilon) {
                    brake = 0f;
                }

                    float gas = (Input.GetAxis("Vertical") - 1f) / -2f;

                    if (reversing) gas *= -1;

                    verticalInput = gas - 1.5f*brake;

				horizontalInput = Mathf.Clamp(Input.GetAxis (_horizontalInput), -1, 1);
				mouseXInput = Input.GetAxis (_mouseXInput);
				mouseYInput = Input.GetAxis (_mouseYInput);
				mouseScrollWheelInput = Input.GetAxis (_mouseScrollWheelInput);
				break;
				//====================================================================================
			}
			#endregion

			vehicleCode = vehicles [currentVehicle].GetComponent<MSVehicleController> ();
			EnableOrDisableButtons (vehicleCode.isInsideTheCar);

			if (Input.GetKeyDown (controls.reloadScene) && controls.enable_reloadScene_Input_key) {
				SceneManager.LoadScene (sceneName);
			}

			if (Input.GetKeyDown (controls.pause) && controls.enable_pause_Input_key) {
				pause = !pause;
			}
			if (pause) {
				Time.timeScale = Mathf.Lerp (Time.timeScale, 0.0f, Time.fixedDeltaTime * 5.0f);
			} else {
				Time.timeScale = Mathf.Lerp (Time.timeScale, 1.0f, Time.fixedDeltaTime * 5.0f);
			}

			if ((Input.GetKeyDown (controls.enterEndExit)||enterAndExitBool) && !blockedInteraction && player && controls.enable_enterEndExit_Input_key) {
				if (vehicles.Length <= 1) {
					if (vehicleCode.transform.gameObject.activeInHierarchy) {
						if (vehicleCode.isInsideTheCar) {
							vehicleCode.ExitTheVehicle ();
							if (player) {
								int freeDoor = 0;
								for (int x = 0; x < vehicleCode.doorPosition.Length; x++) {
									bool checkObstacles = CheckObstacles (vehicleCode.doorPosition [x].transform);
									if (checkObstacles) {
										freeDoor++;
									} else {
										break;
									}
								}
								//
								if (freeDoor < vehicleCode.doorPosition.Length) {
									player.transform.position = vehicleCode.doorPosition [freeDoor].transform.position;
									//player.transform.rotation = vehicleCode.doorPosition [freeDoor].transform.rotation;
								}
								else {
									player.transform.position = vehicleCode.doorPosition [0].transform.position + Vector3.up * 3.0f;
									//player.transform.rotation = vehicleCode.doorPosition [0].transform.rotation;
								}
								player.SetActive (true);
							}
							blockedInteraction = true;
							enterAndExitBool = false;
							StartCoroutine ("WaitToInteract");
						} else {
							float currentDistance = Vector3.Distance (player.transform.position, vehicleCode.doorPosition [0].transform.position);
							for (int x = 0; x < vehicleCode.doorPosition.Length; x++) {
								float proximityDistance = Vector3.Distance (player.transform.position, vehicleCode.doorPosition [x].transform.position);
								if (proximityDistance < currentDistance) {
									currentDistance = proximityDistance;
								}
							}
							if (currentDistance < minDistance) {
								vehicleCode.EnterInVehicle ();
								if (player) {
									player.SetActive (false);
								}
								blockedInteraction = true;
								enterAndExitBool = false;
								StartCoroutine ("WaitToInteract");
							} else {
								enterAndExitBool = false;
							}
						}
					}
				} else {
					if (vehicleCode.isInsideTheCar) {
						vehicleCode.ExitTheVehicle ();
						if (player) {
							int freeDoor = 0;
							for (int x = 0; x < vehicleCode.doorPosition.Length; x++) {
								bool checkObstacles = CheckObstacles (vehicleCode.doorPosition [x].transform);
								if (checkObstacles) {
									freeDoor++;
								} else {
									break;
								}
							}
							//
							if (freeDoor < vehicleCode.doorPosition.Length) {
								player.transform.position = vehicleCode.doorPosition [freeDoor].transform.position;
								//player.transform.rotation = vehicleCode.doorPosition [freeDoor].transform.rotation;
							}
							else {
								player.transform.position = vehicleCode.doorPosition [0].transform.position + Vector3.up * 3.0f;
								//player.transform.rotation = vehicleCode.doorPosition [0].transform.rotation;
							}
							player.SetActive (true);
						}
						blockedInteraction = true;
						enterAndExitBool = false;
						StartCoroutine ("WaitToInteract");
					} else {
						int proximityObjectIndex = 0;
						int proximityDoorIndex = 0;
						for (int x = 0; x < vehicles.Length; x++) {
							controllerTemp = vehicles [x].GetComponent<MSVehicleController> ();
							if (controllerTemp.transform.gameObject.activeInHierarchy) {
								for (int y = 0; y < controllerTemp.doorPosition.Length; y++) {
									float currentDistanceTemp = Vector3.Distance (player.transform.position, controllerTemp.doorPosition [y].transform.position);
									float proximityDistance = Vector3.Distance (player.transform.position, vehicles [proximityObjectIndex].GetComponent<MSVehicleController> ().doorPosition [proximityDoorIndex].transform.position);
									if (currentDistanceTemp < proximityDistance) {
										proximityObjectIndex = x;
										proximityDoorIndex = y;
									}
								}
							}
						}
						//
						controllerTemp = vehicles [proximityObjectIndex].GetComponent<MSVehicleController> ();
						float proximityDistance2 = Vector3.Distance (player.transform.position, controllerTemp.doorPosition[0].transform.position);
						for (int x = 0; x < controllerTemp.doorPosition.Length; x++) {
							float currentDistanceTemp = Vector3.Distance (player.transform.position, controllerTemp.doorPosition [x].transform.position);
							if (currentDistanceTemp < proximityDistance2) {
								proximityDistance2 = currentDistanceTemp;
							}
						}
						if (proximityDistance2 < minDistance) {
							currentVehicle = proximityObjectIndex;
							vehicles [currentVehicle].GetComponent<MSVehicleController> ().EnterInVehicle ();
							if (player) {
								player.SetActive (false);
							}
							blockedInteraction = true;
							enterAndExitBool = false;
							StartCoroutine ("WaitToInteract");
						} else {
							enterAndExitBool = false;
						}
					}
				}
			}
				
			if (player) {
				if (!enterAndExitTextBool) {
					enterAndExitTextBool = true;
					StartCoroutine (WaitToCheckDistance (vehicleCode.isInsideTheCar));
				}
			}
			//
			if (returnHandBrakeInputBool) {
				handBrakeInputBool = false;
			}
			//
			#region optimizationByDistance
			if(disableVehicleByDistance){
				timerOptimizationLoop += Time.deltaTime;
				if(timerOptimizationLoop > 0.2f){ //5Hz
					timerOptimizationLoop = 0.0f;
					//optimization
					if(vehicleCode.isInsideTheCar){
						for(int x = 0; x < vehicles.Length; x++){
							float currentDistanceTemp = Vector3.Distance(vehicleCode.transform.position,vehicles[x].transform.position);
							if(currentDistanceTemp < distanceDisable){
								vehicles[x].gameObject.SetActive(true);
							}else{
								vehicles[x].gameObject.SetActive(false);
							}
						}
					}else{
						for(int x = 0; x < vehicles.Length; x++){
							float currentDistanceTemp = Vector3.Distance(player.transform.position,vehicles[x].transform.position);
							if(currentDistanceTemp < distanceDisable){
								vehicles[x].gameObject.SetActive(true);
							}else{
								vehicles[x].gameObject.SetActive(false);
							}
						}
					}
				}
			}
			#endregion
		}
	}

	bool CheckObstacles (Transform vehicleDoor){
		Collider[] hitColliders = Physics.OverlapSphere (vehicleDoor.position, 0.4f);
		if (hitColliders.Length > 0) {
			return true;
		}
		return false;
	}

	IEnumerator WaitToInteract(){
		yield return new WaitForSeconds (0.7f);
		blockedInteraction = false;
	}

	IEnumerator WaitToCheckDistance(bool isInsideTheCar){
		interactBool = false;
		for (int x = 0; x < vehicles.Length; x++) {
			controllerTemp = vehicles [x].GetComponent<MSVehicleController> ();
			if (controllerTemp.transform.gameObject.activeInHierarchy) {
				for (int y = 0; y < controllerTemp.doorPosition.Length; y++) {
					if (Vector3.Distance (player.transform.position, controllerTemp.doorPosition [y].transform.position) < minDistance) {
						interactBool = true;
					}
				}
			}
		}
		if (interactBool && !isInsideTheCar && pressKeyUI) {
			if (selectControls == ControlType.mobileButton || selectControls == ControlType.mobileJoystick || selectControls == ControlType.mobileVolant) {
				enterOrExitVehicleText.enabled = false;
			} else {
				enterOrExitVehicleText.enabled = true;
			}
		} else {
			enterOrExitVehicleText.enabled = false;
		}
		//
		yield return new WaitForSeconds (0.2f);
		enterAndExitTextBool = false;
	}

	void EnableOrDisableButtons(bool insideInCar){
		if (selectControls == ControlType.mobileButton || selectControls == ControlType.mobileJoystick || selectControls == ControlType.mobileVolant) {
			//gears
			if (vehicleCode.automaticGears) {
				if (controls.increasedGearMobileButton) {
					controls.increasedGearMobileButton.gameObject.SetActive (false);
				}
				if (controls.decreasedGearMobileButton) {
					controls.decreasedGearMobileButton.gameObject.SetActive (false);
				}
			} else {
				if (controls.increasedGearMobileButton) {
					controls.increasedGearMobileButton.gameObject.SetActive (insideInCar & controls.enable_increasedGear_Button_Mobile);
				}
				if (controls.decreasedGearMobileButton) {
					controls.decreasedGearMobileButton.gameObject.SetActive (insideInCar & controls.enable_decreasedGear_Button_Mobile);
				}
			}


			//lights
			if (controls.flashesRightAlertMobileButton) {
				controls.flashesRightAlertMobileButton.gameObject.SetActive (insideInCar & controls.enable_flashesRightAlert_Button_Mobile);
			}
			if (controls.flashesLeftAlertMobileButton) {
				controls.flashesLeftAlertMobileButton.gameObject.SetActive (insideInCar & controls.enable_flashesLeftAlert_Button_Mobile);
			}
			if (controls.mainLightsMobileButton) {
				controls.mainLightsMobileButton.gameObject.SetActive (insideInCar & controls.enable_mainLightsInput_Button_Mobile);
			}
			if (controls.extraLightsMobileButton) {
				controls.extraLightsMobileButton.gameObject.SetActive (insideInCar & controls.enable_extraLightsInput_Button_Mobile);
			}
			if (controls.headlightsMobileButton) {
				controls.headlightsMobileButton.gameObject.SetActive (insideInCar & controls.enable_headlightsInput_Button_Mobile);
			}
			if (controls.warningLightsMobileButton) {
				controls.warningLightsMobileButton.gameObject.SetActive (insideInCar & controls.enable_warningLightsInput_Button_Mobile);
			}

			//game
			if (controls.reloadSceneMobileButton) {
				controls.reloadSceneMobileButton.gameObject.SetActive (controls.enable_reloadScene_Button_Mobile);
			}
			if (controls.pauseMobileButton) {
				controls.pauseMobileButton.gameObject.SetActive (controls.enable_pause_Button_Mobile);
			}

			//vehicle
			if (controls.startTheVehicleMobileButton) {
				controls.startTheVehicleMobileButton.gameObject.SetActive (insideInCar & controls.enable_startTheVehicle_Button_Mobile);
			}
			if (controls.enterEndExitMobileButton) {
				controls.enterEndExitMobileButton.gameObject.SetActive (controls.enable_enterEndExit_Button_Mobile);
			}
			if (controls.hornMobileButton) {
				if (vehicleCode._sounds.hornSound) {
					controls.hornMobileButton.gameObject.SetActive (insideInCar & controls.enable_hornInput_Button_Mobile);
				} else {
					controls.hornMobileButton.gameObject.SetActive (false);
				}
			}
			if (controls.handBrakeMobileButton) {
				if (vehicleCode.automaticGears) {
					controls.handBrakeMobileButton.gameObject.SetActive (false);
				} else {
					controls.handBrakeMobileButton.gameObject.SetActive (insideInCar & controls.enable_handBrakeInput_Button_Mobile);
				}
			}
			if (controls.switchingCamerasMobileButton) {
				if (vehicleCode._cameras.cameras.Length <= 1) {
					controls.switchingCamerasMobileButton.gameObject.SetActive (false);
				} else {
					controls.switchingCamerasMobileButton.gameObject.SetActive (insideInCar & controls.enable_switchingCameras_Button_Mobile);
				}
			}
			if (controls.manualOrAutoGearsMobileButton) {
				controls.manualOrAutoGearsMobileButton.gameObject.SetActive (insideInCar & controls.enable_manualOrAutoGears_Button_Mobile);
			}


			/// JOYSTICK, BUTTON AND MOVE CONTROLLS
			if (selectControls == ControlType.mobileButton) {
				//joystick
				if (joystickMove) {
					joystickMove.gameObject.SetActive (false); 
				}
				if (joystickRotate) {
					joystickRotate.gameObject.SetActive (false);
				}
				//joystick camera and scroll
				if (joystickCamera) {
					if (vehicleCode._cameras.cameras.Length > 0) {
						joystickCamera.gameObject.SetActive (insideInCar);
					} else {
						joystickCamera.gameObject.SetActive (false);
					}
				}
				if (buttonScrollUp) {
					buttonScrollUp.gameObject.SetActive (insideInCar);
				}
				if (buttonScrollDown) {
					buttonScrollDown.gameObject.SetActive (insideInCar);
				}
				//move buttons
				if (buttonLeft) {
					buttonLeft.gameObject.SetActive (insideInCar);
				}
				if (buttonRight) {
					buttonRight.gameObject.SetActive (insideInCar);
				}
				if (buttonUp) {
					buttonUp.gameObject.SetActive (insideInCar);
				}
				if (buttonDown) {
					buttonDown.gameObject.SetActive (insideInCar);
				}
				//volant
				if (androidInputVolant) {
					androidInputVolant.gameObject.SetActive (false);
				}
			} 
			// \/
			if (selectControls == ControlType.mobileJoystick) {
				//joystick
				if (joystickMove) {
					joystickMove.gameObject.SetActive (insideInCar); 
				}
				if (joystickRotate) {
					joystickRotate.gameObject.SetActive (insideInCar);
				}
				//joystick camera and scroll
				if (joystickCamera) {
					joystickCamera.gameObject.SetActive (false);
				}
				if (buttonScrollUp) {
					buttonScrollUp.gameObject.SetActive (insideInCar);
				}
				if (buttonScrollDown) {
					buttonScrollDown.gameObject.SetActive (insideInCar);
				}
				//move buttons
				if (buttonLeft) {
					buttonLeft.gameObject.SetActive (false);
				}
				if (buttonRight) {
					buttonRight.gameObject.SetActive (false);
				}
				if (buttonUp) {
					buttonUp.gameObject.SetActive (false);
				}
				if (buttonDown) {
					buttonDown.gameObject.SetActive (false);
				}
				//volant
				if (androidInputVolant) {
					androidInputVolant.gameObject.SetActive (false);
				}
			}
			// \/
			if (selectControls == ControlType.mobileVolant) {
				//joystick
				if (joystickMove) {
					joystickMove.gameObject.SetActive (false); 
				}
				if (joystickRotate) {
					joystickRotate.gameObject.SetActive (false);
				}
				//joystick camera and scroll
				if (joystickCamera) {
					if (vehicleCode._cameras.cameras.Length > 0) {
						joystickCamera.gameObject.SetActive (insideInCar);
					} else {
						joystickCamera.gameObject.SetActive (false);
					}
				}
				if (buttonScrollUp) {
					buttonScrollUp.gameObject.SetActive (insideInCar);
				}
				if (buttonScrollDown) {
					buttonScrollDown.gameObject.SetActive (insideInCar);
				}
				//move buttons
				if (buttonLeft) {
					buttonLeft.gameObject.SetActive (false);
				}
				if (buttonRight) {
					buttonRight.gameObject.SetActive (false);
				}
				if (buttonUp) {
					buttonUp.gameObject.SetActive (insideInCar);
				}
				if (buttonDown) {
					buttonDown.gameObject.SetActive (insideInCar);
				}
				//volant
				if (androidInputVolant) {
					androidInputVolant.gameObject.SetActive (insideInCar);
				}
			}
		} 
		else {
			//gears
			if (controls.increasedGearMobileButton) {
				controls.increasedGearMobileButton.gameObject.SetActive (false);
			}
			if (controls.decreasedGearMobileButton) {
				controls.decreasedGearMobileButton.gameObject.SetActive (false);
			}

			//lights
			if (controls.flashesRightAlertMobileButton) {
				controls.flashesRightAlertMobileButton.gameObject.SetActive (false);
			}
			if (controls.flashesLeftAlertMobileButton) {
				controls.flashesLeftAlertMobileButton.gameObject.SetActive (false);
			}
			if (controls.mainLightsMobileButton) {
				controls.mainLightsMobileButton.gameObject.SetActive (false);
			}
			if (controls.extraLightsMobileButton) {
				controls.extraLightsMobileButton.gameObject.SetActive (false);
			}
			if (controls.headlightsMobileButton) {
				controls.headlightsMobileButton.gameObject.SetActive (false);
			}
			if (controls.warningLightsMobileButton) {
				controls.warningLightsMobileButton.gameObject.SetActive (false);
			}

			//game
			if (controls.reloadSceneMobileButton) {
				controls.reloadSceneMobileButton.gameObject.SetActive (false);
			}
			if (controls.pauseMobileButton) {
				controls.pauseMobileButton.gameObject.SetActive (false);
			}

			//vehicle
			if (controls.startTheVehicleMobileButton) {
				controls.startTheVehicleMobileButton.gameObject.SetActive (false);
			}
			if (controls.enterEndExitMobileButton) {
				controls.enterEndExitMobileButton.gameObject.SetActive (false);
			}
			if (controls.hornMobileButton) {
				controls.hornMobileButton.gameObject.SetActive (false);
			}
			if (controls.handBrakeMobileButton) {
				controls.handBrakeMobileButton.gameObject.SetActive (false);
			}
			if (controls.switchingCamerasMobileButton) {
				controls.switchingCamerasMobileButton.gameObject.SetActive (false);
			}
			if (controls.manualOrAutoGearsMobileButton) {
				controls.manualOrAutoGearsMobileButton.gameObject.SetActive (false);
			}
			//
			if (joystickMove) {
				joystickMove.gameObject.SetActive (false);
			}
			if (joystickRotate) {
				joystickRotate.gameObject.SetActive (false);
			}
			if (joystickCamera) {
				joystickCamera.gameObject.SetActive (false);
			}
			if (buttonScrollUp) {
				buttonScrollUp.gameObject.SetActive (false);
			}
			if (buttonScrollDown) {
				buttonScrollDown.gameObject.SetActive (false);
			}
			if (buttonLeft) {
				buttonLeft.gameObject.SetActive (false);
			}
			if (buttonRight) {
				buttonRight.gameObject.SetActive (false);
			}
			if (buttonUp) {
				buttonUp.gameObject.SetActive (false);
			}
			if (buttonDown) {
				buttonDown.gameObject.SetActive (false);
			}
			if (androidInputVolant) {
				androidInputVolant.gameObject.SetActive (false);
			}
		}
	}


		

	#region mobileVolant
	public float GetClampedValue(){
		return wheelAngle / maxAngle;
	}
	public float GetAngle(){
		return wheelAngle;
	}
	void InitEventsSystem(){
		EventTrigger events = androidInputVolant.gameObject.GetComponent<EventTrigger>();
		if (events == null) {
			events = androidInputVolant.gameObject.AddComponent<EventTrigger> ();
		}
		if (events.triggers == null) {
			events.triggers = new System.Collections.Generic.List<EventTrigger.Entry> ();
		}
		EventTrigger.Entry entry = new EventTrigger.Entry();
		EventTrigger.TriggerEvent callback = new EventTrigger.TriggerEvent();
		UnityAction<BaseEventData> functionCall = new UnityAction<BaseEventData>( PressEvent );
		callback.AddListener( functionCall );
		entry.eventID = EventTriggerType.PointerDown;
		entry.callback = callback;
		events.triggers.Add( entry );
		entry = new EventTrigger.Entry();
		callback = new EventTrigger.TriggerEvent();
		functionCall = new UnityAction<BaseEventData>( DragEvent );
		callback.AddListener( functionCall );
		entry.eventID = EventTriggerType.Drag;
		entry.callback = callback;
		events.triggers.Add( entry );
		entry = new EventTrigger.Entry();
		callback = new EventTrigger.TriggerEvent();
		functionCall = new UnityAction<BaseEventData>( ReleaseEvent );
		callback.AddListener( functionCall );
		entry.eventID = EventTriggerType.PointerUp;
		entry.callback = callback;
		events.triggers.Add( entry );
	}
	void UpdateRect(){
		Vector3[] corners = new Vector3[4];
		rectT.GetWorldCorners( corners );
		for( int i = 0; i < 4; i++ ){
			corners[i] = RectTransformUtility.WorldToScreenPoint( null, corners[i] );
		}
		Vector3 bottomLeft = corners[0];
		Vector3 topRight = corners[2];
		float width = topRight.x - bottomLeft.x;
		float height = topRight.y - bottomLeft.y;
		Rect _rect = new Rect( bottomLeft.x, topRight.y, width, height );
		centerPoint = new Vector2( _rect.x + _rect.width * 0.5f, _rect.y - _rect.height * 0.5f );
	}
	public void PressEvent( BaseEventData eventData ){
		Vector2 pointerPos = ( (PointerEventData) eventData ).position;
		wheelBeingHeld = true;
		wheelPrevAngle = Vector2.Angle( Vector2.up, pointerPos - centerPoint );
	}
	public void DragEvent( BaseEventData eventData ){
		Vector2 pointerPos = ( (PointerEventData) eventData ).position;
		float wheelNewAngle = Vector2.Angle( Vector2.up, pointerPos - centerPoint );
		if( Vector2.Distance( pointerPos, centerPoint ) > 20f ){
			if (pointerPos.x > centerPoint.x) {
				wheelAngle += wheelNewAngle - wheelPrevAngle;
			} else {
				wheelAngle -= wheelNewAngle - wheelPrevAngle;
			}
		}
		wheelAngle = Mathf.Clamp( wheelAngle, -maxAngle, maxAngle );
		wheelPrevAngle = wheelNewAngle;
	}
	public void ReleaseEvent( BaseEventData eventData ){
		DragEvent( eventData );
		wheelBeingHeld = false;
	}
	#endregion


	#region mobileButtonInputs
	public void ResetMobileButtonInputs(){
		increasedGearInputBool = false;
		decreasedGearInputBool = false;
		flashesRightAlertBool = false;
		flashesLeftAlertBool = false;
		mainLightsInputBool = false;
		extraLightsInputBool = false;
		headlightsInputBool = false;
		warningLightsInputBool = false;
		startTheVehicleInputBool = false;
		hornInputBool = false;
		handBrakeInputBool = false;
		returnHandBrakeInputBool = false;
		manualOrAutoGearsInputBool = false;
	}
		

	//gears
	void Mobile_IncreasedGearButton (){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_increasedGear_Button_Mobile && !increasedGearInputBool) {
				increasedGearInputBool = true; 
			}
		}
	}
	void Mobile_DecreasedGearButton (){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_decreasedGear_Button_Mobile && !decreasedGearInputBool) {
				decreasedGearInputBool = true;
			}
		}
	}


	//lights
	void Mobile_FlashesRightAlertButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_flashesRightAlert_Button_Mobile && !flashesRightAlertBool) {
				flashesRightAlertBool = true;
			}
		}
	}
	void Mobile_FlashesLeftAlertButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_flashesLeftAlert_Button_Mobile && !flashesLeftAlertBool) {
				flashesLeftAlertBool = true;
			}
		}
	}
	void Mobile_MainLightsButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_mainLightsInput_Button_Mobile && !mainLightsInputBool) {
				mainLightsInputBool = true;
			}
		}
	}
	void Mobile_ExtraLightsButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_extraLightsInput_Button_Mobile && !extraLightsInputBool) {
				extraLightsInputBool = true;
			}
		}
	}
	void Mobile_HeadLightsButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_headlightsInput_Button_Mobile && !headlightsInputBool) {
				headlightsInputBool = true;
			}
		}
	}
	void Mobile_WarningLightsButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_warningLightsInput_Button_Mobile && !warningLightsInputBool) {
				warningLightsInputBool = true;
			}
		}
	}


	//game
	void Mobile_ReloadSceneButton(){ //================= OK, this input is managed in this code.
		if (!error) {
			if (controls.enable_reloadScene_Button_Mobile) {
				SceneManager.LoadScene (sceneName);
			}
		}
	}
	void Mobile_PauseButton(){ //================= OK, this input is managed in this code.
		if (!error) {
			if (controls.enable_pause_Button_Mobile) {
				pause = !pause;
				if (pause) {
					Time.timeScale = Mathf.Lerp (Time.timeScale, 0.0f, Time.fixedDeltaTime * 5.0f);
				} else {
					Time.timeScale = Mathf.Lerp (Time.timeScale, 1.0f, Time.fixedDeltaTime * 5.0f);
				}
			}
		}
	}


	//vehicle
	void Mobile_StartTheVehicleButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_startTheVehicle_Button_Mobile && !startTheVehicleInputBool) {
				startTheVehicleInputBool = true; //bool in this code
			}
		}
	}
	void Mobile_EnterAndExitButton (){ //================= OK, this input is managed in this code.
		if (!error){
			if (!enterAndExitBool && controls.enable_enterEndExit_Button_Mobile) {
				enterAndExitBool = true;
			}
		}
	}
	void Mobile_HornButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_hornInput_Button_Mobile && !hornInputBool) {
				hornInputBool = true;
			}
		}
	}
	void Mobile_HandBrakeButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_handBrakeInput_Button_Mobile && !handBrakeInputBool) {
				returnHandBrakeInputBool = false;
				handBrakeInputBool = true;
			}
		}
	}
	void Mobile_SwitchingCamerasInputButton(){ //================= OK, this input is managed in this code.
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_switchingCameras_Button_Mobile) {
				vehicleCode.InputsCamerasMobile ();
			}
		}
	}
	void Mobile_ManualOrAutoGearsButton(){ //OK - implemented in the vehicle controller
		if (!error) {
			if (vehicleCode.isInsideTheCar && controls.enable_manualOrAutoGears_Button_Mobile && !manualOrAutoGearsInputBool) {
				manualOrAutoGearsInputBool = true;
			}
		}
	}
	#endregion
}
