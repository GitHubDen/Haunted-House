using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour {
	public Text ememiesText;
	public int remaining;
	public int roomNumber;

	public bool room1Entered;
	public bool room1Cleared;

	//true for now with no tutorial room

	public bool room2Entered;
	public bool room2Cleared;

	public bool room3Entered;
	public bool room3Cleared;

	public bool room4Entered;
	public bool room4Cleared;

	public bool room5Entered;
	public bool room5Cleared;
	public bool room5Audio;


	public bool winRoomEntered;

	public GameObject r0Cube;
	public GameObject r1Cube;
	public GameObject r2Cube;
	public GameObject r2S1Cube;
	public GameObject r2s1Cube2;
	public GameObject r2Cube2;
	public GameObject r3Cube;
	public GameObject r3Cube2;
	public GameObject r4Cube;
	public GameObject r4Cube2;

	public GameObject r1Door01;
	public GameObject r2Door02;
	public GameObject r2Door03;
	public GameObject r2Door01;
	public GameObject r2SRDoor01;
	public GameObject r3Door01;
	public GameObject r3Door02;
	public GameObject r4Door01;
	public GameObject r4Door02;


	public Material originalDoor;
	public Material outLine;
	public Material outLine2;
	public Material outLine3;



	//audio
	public AudioClip bossRoomEnterSound;
	private AudioSource source;
	private float volLowRange = .15f;
	private float volHighRange = 0.3f;



		



	void Awake () {

		source = GetComponent<AudioSource>();

	}
	void Start () {
		remaining = 0;
		ememiesText.text = "Ememies Remaining: " + remaining.ToString();
		//true with out tutorial
    	 room1Entered = false;
		 room1Cleared = false;
		room2Entered = false;
		room2Cleared = false;
		 room3Entered = false;
		 room3Cleared = false;
		room4Entered = false;
		room4Cleared = false;
		roomNumber = 0;
		room5Audio = false;
		winRoomEntered= false;

	}
	
	void FixedUpdate () {
		//win

		if (room5Cleared == true && winRoomEntered == false) {
			winRoomEntered = true;
			SteamVR_Fade.View (Color.black, 1f);
			r0Cube.GetComponent<TeleportCube> ().nextRoomLocation = new Vector3 (0f, 0f, -157f);
			r0Cube.GetComponent<TeleportCube> ().Invoke ("Teleport", 1f);
			r0Cube.GetComponent<TeleportCube> ().Invoke ("setRoomNum6", 2f);
		}







		//remaining = 5;
		ememiesText.text = "Ememies Remaining: " + remaining.ToString();

		if (room5Entered == true && room5Audio ==false) {
			room5Audio = true;
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(bossRoomEnterSound,vol);


		}


		if (room1Cleared == false && room1Entered ==false) {
			r1Cube.SetActive (false);
			r2Cube.SetActive (false);
			r2S1Cube.SetActive (false);
			r2s1Cube2.SetActive (false);
			r2Cube2.SetActive (false);
			r3Cube.SetActive (false);
			r3Cube2.SetActive (false);
			r4Cube.SetActive (false);
			r4Cube2.SetActive (false);

		}

		if(room1Cleared == true){
			//spawn cube

			r1Cube.SetActive (true);
		}
		if(room2Cleared == true){
			//spawn cube
			r2Cube.SetActive (true);
			r2S1Cube.SetActive (true);
			r2s1Cube2.SetActive (true);
			r2Cube2.SetActive (true);

		}

		if(room3Cleared == true){
			//spawn cube
			r3Cube.SetActive (true);
			r3Cube2.SetActive (true);

		}
		if(room4Cleared == true){
			//spawn cube
			r4Cube.SetActive (true);
			r4Cube2.SetActive (true);

		}




		if (remaining == 0 && roomNumber ==0) {
			
			r1Door01.GetComponent<Renderer> ().material = originalDoor;
			r2Door02.GetComponent<Renderer> ().material = originalDoor;
			r2Door03.GetComponent<Renderer> ().material = originalDoor;
			r2Door01.GetComponent<Renderer> ().material = originalDoor;
			r2SRDoor01.GetComponent<Renderer> ().material = originalDoor;
			r3Door01.GetComponent<Renderer> ().material = originalDoor;
			r3Door02.GetComponent<Renderer> ().material = originalDoor;
			r4Door01.GetComponent<Renderer> ().material = originalDoor;
			r4Door02.GetComponent<Renderer> ().material = originalDoor;

		}



		if (remaining == 0 && roomNumber ==1) {
			room1Cleared = true;
			r1Door01.GetComponent<Renderer> ().material = outLine;


		}
		if (remaining == 0 && roomNumber ==2) {
			room2Cleared = true;
			r2Door02.GetComponent<Renderer> ().material = outLine;
			r2Door03.GetComponent<Renderer> ().material = outLine2;
			r2Door01.GetComponent<Renderer> ().material = outLine3;
			r2SRDoor01.GetComponent<Renderer> ().material = outLine2;
	

		}

		if (remaining == 0 && roomNumber ==3) {
			room3Cleared = true;
			r3Door01.GetComponent<Renderer> ().material = outLine3;
			r3Door02.GetComponent<Renderer> ().material = outLine;

		}

		if (remaining == 0 && roomNumber ==4) {
			room4Cleared = true;
			r4Door01.GetComponent<Renderer> ().material = outLine;
			r4Door02.GetComponent<Renderer> ().material = outLine3;

		}

		if (remaining == 0 && roomNumber ==5) {
			room5Cleared = true;

		}


	}




}
