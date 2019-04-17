using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class GasStation : MonoBehaviour {

	[Tooltip("The amount of fuel that will be added to the vehicle when it enters the collider of this object.")]
	public int fuel = 20;

	void Start(){
		GetComponent<BoxCollider> ().isTrigger = true;
	}

	void OnTriggerEnter(Collider other){
		MSVehicleController controller = other.transform.GetComponentInParent<MSVehicleController> ();
		if (controller) {
			float max = controller._fuel.capacityInLiters;
			controller.currentFuelLiters += fuel;
			controller.currentFuelLiters = Mathf.Clamp (controller.currentFuelLiters, 0, max);
		}
	}
}
