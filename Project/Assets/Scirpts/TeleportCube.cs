using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCube : MonoBehaviour {

	public Transform cameraRigTransform; 
	public Transform headTransform; 
	//enemy prefabs
	public GameObject ghostPrefab;
	public GameObject ghost2Prefab;
	public GameObject eyeballPrefab;
	public GameObject bigEyeballPrefab;
	public GameObject pumpkinBossPrefab;


	public Transform bossPosition;
	public Transform cameraRig;
	private bool teleport = true;
	public Vector3 nextRoomLocation;

	public CountText countScipt;
	public GameObject controllerScriptrr;
	public GameObject controllerScriptll;








	private void setTrans(GameObject enemy){
		enemy.transform.LookAt (cameraRig);
		enemy.GetComponent<FloatGhost> ().cameraRigg = cameraRig.transform;
		enemy.GetComponent<GhostDMG> ().countScript = countScipt;
		enemy.GetComponent<GhostDMG> ().controllerScriptR= controllerScriptrr;
		enemy.GetComponent<GhostDMG> ().controllerScriptL= controllerScriptll;

	}

	private void setTransBossRoom(GameObject enemy){
		enemy.transform.LookAt (cameraRig);
		enemy.GetComponent<FloatGhost> ().cameraRigg = cameraRig.transform;
		enemy.GetComponent<GhostDMG> ().countScript = countScipt;
		enemy.GetComponent<GhostDMG> ().controllerScriptR= controllerScriptrr;
		enemy.GetComponent<GhostDMG> ().controllerScriptL= controllerScriptll;
		enemy.gameObject.transform.localScale = new Vector3(2,2,2);

	}

	private void setTransBossPumpkin(GameObject enemy){
		enemy.transform.LookAt (cameraRig);
		enemy.GetComponent<FloatGhost> ().cameraRigg = bossPosition.transform;
		enemy.GetComponent<ShootPumpkins> ().cameraEye = cameraRig.transform;
		enemy.GetComponent<GhostDMG> ().countScript = countScipt;
		enemy.GetComponent<GhostDMG> ().controllerScriptR= controllerScriptrr;
		enemy.GetComponent<GhostDMG> ().controllerScriptL= controllerScriptll;


		enemy.gameObject.transform.localScale = new Vector3(11,9,11);
		enemy.gameObject.transform.Rotate (new Vector3 (-90, 0, 0));

	}




	private void room1enemy(){
		countScipt.remaining = 2;
		countScipt.room1Entered = true;
		//make enemy
		GameObject ememyInstance;
		//make enemies
		ememyInstance = Instantiate (ghostPrefab, new Vector3 (-3f, 3f, -7f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghostPrefab, new Vector3 (3f, 4f, -7f), Quaternion.identity);
		setTrans (ememyInstance);


	}



	private void room2enemy(){
		countScipt.remaining = 6;
		countScipt.room2Entered = true;
		//make enemy
		GameObject ememyInstance;
		//make enemies
		ememyInstance = Instantiate (ghostPrefab, new Vector3 (-12f, 3f, -27f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghostPrefab, new Vector3 (10f, 4f, -24f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghostPrefab, new Vector3 (-5f, 3f, -36f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghostPrefab, new Vector3 (5f, 4f, -36f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghost2Prefab, new Vector3 (-8.2f, 3f, -16f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghost2Prefab, new Vector3 (8f, 3f, -16f), Quaternion.identity);
		setTrans (ememyInstance);

	}
	private void room3enemy(){
		countScipt.remaining = 6;
		countScipt.room3Entered = true;
		//make enemy
		GameObject ememyInstance;
		//make enemies
		ememyInstance = Instantiate (ghost2Prefab, new Vector3 (-12f, 3f, -61f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghost2Prefab, new Vector3 (10f, 3f, -57f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghost2Prefab, new Vector3 (-9f, 4f, -52f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (ghost2Prefab, new Vector3 (6f, 3f, -52f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (eyeballPrefab, new Vector3 (-12f, 4f, -41f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (eyeballPrefab, new Vector3 (10f, 4f, -41f), Quaternion.identity);
		setTrans (ememyInstance);

	}

	private void room4enemy(){
		countScipt.remaining = 6;
		countScipt.room4Entered = true;
		//make enemy
		GameObject ememyInstance;
		//make enemies
		ememyInstance = Instantiate (eyeballPrefab, new Vector3 (-12f, 3f, -88f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (eyeballPrefab, new Vector3 (10f, 3f, -85f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (eyeballPrefab, new Vector3 (12f, 4f, -78f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (eyeballPrefab, new Vector3 (6f, 3f, -82f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (bigEyeballPrefab, new Vector3 (1f, 4f, -88f), Quaternion.identity);
		setTrans (ememyInstance);
		ememyInstance = Instantiate (bigEyeballPrefab, new Vector3 (4f, 4f, -87f), Quaternion.identity);
		setTrans (ememyInstance);

	}


	private void room5enemy(){
		countScipt.remaining = 3;
		countScipt.room5Entered = true;
		//make enemy
		GameObject ememyInstance;
		//make enemies
		ememyInstance = Instantiate (bigEyeballPrefab, new Vector3 (8f, 4f, -123f), Quaternion.identity);
		setTransBossRoom (ememyInstance);
		ememyInstance = Instantiate (bigEyeballPrefab, new Vector3 (-8f, 4f, -123f), Quaternion.identity);
		setTransBossRoom (ememyInstance);

		ememyInstance = Instantiate (pumpkinBossPrefab, new Vector3 (0f, 1.25f, -139f), Quaternion.identity);
		setTransBossPumpkin (ememyInstance);

	}





	private void setRoomNum1(){
		countScipt.roomNumber = 1;
	}


	private void setRoomNum2(){
		countScipt.roomNumber = 2;
	}
	private void setRoomNum3(){
		countScipt.roomNumber = 3;
	}
	private void setRoomNum2S(){
		countScipt.roomNumber = 102;
	}
	private void setRoomNum4(){
		countScipt.roomNumber = 4;
	}
	private void setRoomNum5(){
		countScipt.roomNumber = 5;
	}
	private void setRoomNum6(){
		countScipt.roomNumber = 6;
	}




	private void OnTriggerEnter(Collider other)
	{


		if (this.name.Equals("R0Cube") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0f, 0f, 5.5f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum1", 2f);
			if (countScipt.room1Entered == false) {
				Invoke ("room1enemy", 1f);
			}

		}




		if (this.name.Equals("R1Cube") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0f, 0f, -26f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum2", 2f);
			if (countScipt.room1Cleared == true && countScipt.room2Entered == false) {
				Invoke ("room2enemy", 1f);
			}

		}


		if (this.name.Equals("R2Cube") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0f, 0f, -51f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");

			Invoke ("setRoomNum3", 2f);
			if (countScipt.room2Cleared == true && countScipt.room3Entered == false) {
				Invoke ("room3enemy", 1f);
			}

		}
		if (this.name.Equals("R2Cube2") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0f, 0f, 5.5f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum1", 2f);

		}

		if (this.name.Equals("R2S1Cube") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (22f, 0f, -27f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum2S", 2f);

		}

		if (this.name.Equals("R2S1Cube2") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0, 0f, -26f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum2", 2f);

		}


		if (this.name.Equals("R3Cube") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0f, 0f, -26f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum2", 2f);

		}
			
		if (this.name.Equals("R3Cube2") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0f, 0f, -76f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum4", 2f);
			if (countScipt.room3Cleared == true && countScipt.room4Entered == false) {
				Invoke ("room4enemy", 1f);
			}

		}
		if (this.name.Equals("R4Cube") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0f, 0f, -26f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum3", 2f);

		}
		if (this.name.Equals("R4Cube2") && teleport == true && other.gameObject.layer == 13) {
			teleport = false;
			SteamVR_Fade.View (Color.black, 1f);
			nextRoomLocation = new Vector3 (0f, 0f, -98f);
			Invoke ("Teleport", 1f);
			Debug.Log ("teleport");
			Invoke ("setRoomNum5", 2f);
			if (countScipt.room4Cleared == true && countScipt.room5Entered == false) {
				Invoke ("room5enemy", 1f);
			}

		}


	}



	private void Teleport()
	{
		Vector3 difference = cameraRigTransform.position - headTransform.position;
		difference.y = 0;
		cameraRigTransform.position = nextRoomLocation + difference;
		SteamVR_Fade.View(Color.clear, 1f);
		teleport = true;
	}



}
