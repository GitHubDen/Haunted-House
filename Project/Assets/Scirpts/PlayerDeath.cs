using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {


	public playerHealth playerHealthScript;
	public CountText CountTextScript;
	public TeleportCube TeleportCubeScript;
	public WeaponGrab WeaponGrabRight;
	public WeaponGrab WeaponGrabLeft;
	public GameObject Crossbow;
	public GameObject Sword;

	public GameObject controllerR;
	public GameObject controllerL;

	public GameObject redbarHealth;



	void Update () {
		if (playerHealthScript.currentHealth <= 0) {
			//teleport
			SteamVR_Fade.View (Color.black, 3f);



			//destroy ememies

			var clones = GameObject.FindGameObjectsWithTag ("EnemyClones");
			foreach(var item in clones){
				Destroy(item);
			}



			WeaponGrabRight.swordInHand = false;
			WeaponGrabRight.crossbowInHand = false;
			WeaponGrabLeft.swordInHand = false;
			WeaponGrabLeft.crossbowInHand = false;
			Crossbow.GetComponent<Rigidbody> ().isKinematic = false;
			Sword.GetComponent<Rigidbody> ().isKinematic = false;


			CountTextScript.roomNumber = 0;
			CountTextScript.remaining = 0;
			//CountTextScript.ememiesText.text = "Ememies Remaining: " + remaining.ToString();
			//true with out tutorial
			CountTextScript.room1Entered = false;
			CountTextScript.room1Cleared = false;
			CountTextScript.room2Entered = false;
			CountTextScript.room2Cleared = false;
			CountTextScript.room3Entered = false;
			CountTextScript.room3Cleared = false;
			CountTextScript.room4Entered = false;
			CountTextScript.room4Cleared = false;
			CountTextScript.room5Audio = false;
			CountTextScript.winRoomEntered= false;


			TeleportCubeScript.nextRoomLocation = new Vector3 (0f, 0f, 35f);
			TeleportCubeScript.Invoke("Teleport", 3f);
		//health

			playerHealthScript.currentHealth = 10;
			redbarHealth.transform.localScale = new Vector3 (1.1f, 1f, 1f);


		


			playerHealthScript.takingDMG =0;
		
			playerHealthScript.gotHit = false;
			playerHealthScript.playerDamage = false;
			playerHealthScript.playerAlive = true;



			//playerHealthScript.
			//weapons
		
		

			Crossbow.transform.position = new Vector3 (0f, 1.7f, 4.25f);
			Crossbow.transform.rotation = Quaternion.identity;
			Sword.transform.position = new Vector3 (21f, 3.02f, -28.31f);
			Sword.transform.rotation = Quaternion.identity;



		}




		
	}


}
