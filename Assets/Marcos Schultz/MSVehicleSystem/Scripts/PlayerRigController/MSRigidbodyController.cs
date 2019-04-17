using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))][RequireComponent(typeof(CapsuleCollider))]
public class MSRigidbodyController : MonoBehaviour {
	
	[Header("Move")]
	[Range(1.0f, 10.0f)][Tooltip("The speed at which the player moves when walking.")]
	public float walkSpeed = 3;
	[Range(2.0f, 20.0f)][Tooltip("The speed at which the player moves when running.")]
	public float runSpeed = 6;

	[Header("Jump")]
	[Range(2.0f, 10.0f)][Tooltip("The force of the player's leap. The higher the jump force, the higher the player can jump.")]
	public float jumpForce = 5.0f;

	[Header("Camera")]
	[Range(1.0f, 20.0f)][Tooltip("The speed at which the player can move the camera on the X axis.")]
	public float sensMouseX = 5.0f;
	[Range(1.0f, 20.0f)][Tooltip("The speed at which the player can move the camera on the Y axis.")]
	public float sensMouseY = 5.0f;
	[Range(20.0f, 85.0f)][Tooltip("The maximum angle of incline that the player can reach.")]
	public float maxAngle = 50.0f;

	MSSceneController sceneControllerMS;
	Joystick joystickMoveFPS;
	Joystick joystickRotateFPS;

	GameObject cameraFPS;
	Rigidbody ms_Rigidbody;
	bool isGrounded = false;
	float yRot = 0;

	float moveInputMSForward;
	float moveInputMSSide;
	float rotateInputMSx;
	float rotateInputMSy;

	bool foundTheSceneController;

	void Awake () {
		transform.tag = "Player";
		cameraFPS = GetComponentInChildren (typeof(Camera)).transform.gameObject;
		cameraFPS.transform.localPosition = new Vector3 (0, 1.55f, 0);
		cameraFPS.transform.localRotation = Quaternion.identity;
		cameraFPS.tag = "MainCamera";
		//
		ms_Rigidbody = GetComponent<Rigidbody>();
		ms_Rigidbody.freezeRotation = true;
		ms_Rigidbody.useGravity = false;
		ms_Rigidbody.mass = 15.0f;
		ms_Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
		ms_Rigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
		//
		CapsuleCollider capsule = GetComponent<CapsuleCollider>();
		capsule.height = 1.6f;
		capsule.radius = 0.35f;
		capsule.direction = 1;
		capsule.center = new Vector3 (0.0f, 0.8f, 0.0f);
		//
		joystickMoveFPS = transform.Find("Camera/Canvas/JoystickMFPS").GetComponent<Joystick>();
		joystickRotateFPS = transform.Find("Camera/Canvas/JoystickRFPS").GetComponent<Joystick>();
		sceneControllerMS = FindObjectOfType(typeof(MSSceneController)) as MSSceneController;
		if (sceneControllerMS) {
			foundTheSceneController = true;
		} else {
			foundTheSceneController = false;
		}
	}

	void OnEnable(){
		EnableControls ();
	}

	void OnCollisionStay(){
		isGrounded = true;
	}

	void FixedUpdate(){
		if (isGrounded){
			float speed = walkSpeed;
			if (Input.GetKey (KeyCode.LeftShift)) {
				speed = runSpeed;
			}
			Vector3 targetVelocity = new Vector3(moveInputMSSide, 0, moveInputMSForward);
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;

			Vector3 velocity = ms_Rigidbody.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -speed, speed);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -speed, speed);
			velocityChange.y = 0;
			ms_Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

			// jump
			if (Input.GetKeyDown(KeyCode.Space)) {
				float _jumpForce = jumpForce;
				ms_Rigidbody.velocity = new Vector3(velocity.x, _jumpForce, velocity.z);
			}
		}

		// rotation
		float rotationX = transform.localEulerAngles.y + rotateInputMSx * sensMouseX;
		transform.localEulerAngles = new Vector3(0, rotationX, 0);

		//gravity
		ms_Rigidbody.AddForce(new Vector3(0, -10 * ms_Rigidbody.mass, 0));

		//ground
		isGrounded = false;
	}

	void LateUpdate(){
		yRot += rotateInputMSy * sensMouseY * Time.deltaTime * 50.0f;
		yRot = Mathf.Clamp(yRot, -maxAngle, maxAngle);
		cameraFPS.transform.localEulerAngles = new Vector3 (-yRot, 0, 0);
	}

	void EnableControls(){
		if (foundTheSceneController) {
			if (sceneControllerMS.selectControls == MSSceneController.ControlType.mobileButton || sceneControllerMS.selectControls == MSSceneController.ControlType.mobileJoystick || sceneControllerMS.selectControls == MSSceneController.ControlType.mobileVolant) {
				joystickMoveFPS.gameObject.SetActive (true);
				joystickRotateFPS.gameObject.SetActive (true);
			} else {
				joystickMoveFPS.gameObject.SetActive (false);
				joystickRotateFPS.gameObject.SetActive (false);
			}
		}
	}

	void Update () {
		//get inputs
		if(foundTheSceneController){
			if (sceneControllerMS.selectControls == MSSceneController.ControlType.mobileButton || sceneControllerMS.selectControls == MSSceneController.ControlType.mobileJoystick || sceneControllerMS.selectControls == MSSceneController.ControlType.mobileVolant) {
				if(!joystickMoveFPS.isActiveAndEnabled || !joystickRotateFPS.isActiveAndEnabled){
					EnableControls();
				}
				if(joystickMoveFPS){
					moveInputMSForward = joystickMoveFPS.joystickVertical;
					moveInputMSSide = joystickMoveFPS.joystickHorizontal;
				}
				if(joystickRotateFPS){
					rotateInputMSx = joystickRotateFPS.joystickHorizontal;
					rotateInputMSy = joystickRotateFPS.joystickVertical;
				}
			}
			else{
				if(joystickMoveFPS.isActiveAndEnabled || joystickRotateFPS.isActiveAndEnabled){
					EnableControls();
				}
				moveInputMSForward = Input.GetAxis("Vertical");
				moveInputMSSide = Input.GetAxis("Horizontal");
				rotateInputMSx = Input.GetAxis ("Mouse X");
				rotateInputMSy = Input.GetAxis ("Mouse Y");
			}
		}else{
			if(joystickMoveFPS.isActiveAndEnabled || joystickRotateFPS.isActiveAndEnabled){
				EnableControls();
			}
			moveInputMSForward = Input.GetAxis("Vertical");
			moveInputMSSide = Input.GetAxis("Horizontal");
			rotateInputMSx = Input.GetAxis ("Mouse X");
			rotateInputMSy = Input.GetAxis ("Mouse Y");
		}
	}
}
