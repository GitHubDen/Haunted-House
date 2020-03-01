using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPumpkins : MonoBehaviour {

	private bool PumpkinDelay;
	private bool PumpkinDelayStart;
	private bool PumpkinDelay2;
	private bool PumpkinDelay2Start;
	public Rigidbody miniPumpkinPrefab;
	public Transform eyeR;
	public Transform eyeL;
	public Transform cameraEye;

	void Start() {
		PumpkinDelay = false;
		PumpkinDelayStart = false;
		PumpkinDelay2 = false;
		PumpkinDelay2Start = false;
	}

	private void ShootDelay(){
		PumpkinDelay = false;
	}
	private void ShootDelayStart(){
		PumpkinDelayStart = true;
	}
	private void ShootDelay2(){
		PumpkinDelay2 = false;
	}
	private void ShootDelay2Start(){
		PumpkinDelay2Start = true;
	}

	void Update () {
		//enemy.GetComponent<FloatGhost> ().cameraRigg = cameraRig.transform;
		eyeL.transform.LookAt (cameraEye);
		eyeR.transform.LookAt (cameraEye);

		if (PumpkinDelayStart == false) {
			Invoke ("ShootDelayStart", 14f);
		}

		if (PumpkinDelay == false && PumpkinDelayStart == true) {
			PumpkinDelay = true;
			Rigidbody pumpkinInstance;
			pumpkinInstance = Instantiate (miniPumpkinPrefab, eyeR.position, eyeR.rotation) as Rigidbody;
			pumpkinInstance.AddForce (eyeR.forward * 500);
			Invoke ("ShootDelay", 3f);
			pumpkinInstance.gameObject.transform.Rotate (new Vector3 (-90, 0, 0));
		}

		if (PumpkinDelay2Start == false) {
			Invoke ("ShootDelay2Start", 15.5f);
		}

		if (PumpkinDelay2 == false && PumpkinDelay2Start == true) {
			
			PumpkinDelay2 = true;
			Rigidbody pumpkinInstance2;
			pumpkinInstance2 = Instantiate (miniPumpkinPrefab, eyeL.position, eyeL.rotation) as Rigidbody;
			pumpkinInstance2.AddForce (eyeL.forward * 500);
			pumpkinInstance2.gameObject.transform.Rotate (new Vector3 (-90, 0, 0));
			Invoke ("ShootDelay2", 3f);
		}


	}
}
