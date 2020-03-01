using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponGrab : MonoBehaviour {
    
	public bool swordInHand;
	public bool crossbowInHand;
	public bool crossbowDelay;
	public GameObject otherControllerr;

	public Rigidbody arrowPrefab;
	public Transform crossbowEnd;

    private SteamVR_TrackedObject trackedObj;

	//audio
	public AudioClip shootSound;
	private AudioSource source;
	private float volLowRange = .15f;
	private float volHighRange = 0.3f;


 	
    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    
    // Use this for initialization

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
		source = GetComponent<AudioSource>();

    }

    private GameObject collidingObject;
    private GameObject objectInHand;

	private void CrossbowFireReset(){
		crossbowDelay = false;
	}

    private void SetCollidingObject(Collider col)
    {

        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

		if (swordInHand == true) {
			collidingObject = GameObject.Find("Medieval Sword");
		}
		if (crossbowInHand == true) {
			collidingObject = GameObject.Find("Crossbow");
		}
		if (swordInHand == false && crossbowInHand == false) {
			collidingObject = col.gameObject;
		}
    }


	public void controllerPulse(){
		SteamVR_Controller.Input ((int)trackedObj.index).TriggerHapticPulse(800);
	}




    public void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.layer == 15) {
			SteamVR_Controller.Input ((int)trackedObj.index).TriggerHapticPulse(2000);
			SteamVR_Controller.Input ((int)trackedObj.index).TriggerHapticPulse(2000);
		}
		SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
		if (other.gameObject.layer == 12 && crossbowInHand == false && swordInHand == false && otherControllerr.GetComponent<WeaponGrab>().crossbowInHand == false) {
			SteamVR_Controller.Input ((int)trackedObj.index).TriggerHapticPulse (800);
		}
		if (other.gameObject.layer == 12 && crossbowInHand == false && swordInHand == false && otherControllerr.GetComponent<WeaponGrab> ().crossbowInHand == true) {
			return;
		}
		if (other.gameObject.layer == 11 && swordInHand == false && crossbowInHand == false && otherControllerr.GetComponent<WeaponGrab>().swordInHand == false) {
			SteamVR_Controller.Input ((int)trackedObj.index).TriggerHapticPulse (800);
		}
		if (other.gameObject.layer == 11 && swordInHand == false && crossbowInHand == false && otherControllerr.GetComponent<WeaponGrab> ().swordInHand == true) {
			return;
		}
		SetCollidingObject(other);
    }


    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
 
		objectInHand = collidingObject;
		collidingObject = null;
		objectInHand.transform.position = this.transform.position ;

		objectInHand.transform.rotation = this.transform.rotation;
		objectInHand.transform.Rotate (new Vector3 (0, -90, 0));
	
       // var joint = AddFixedJoint();
     //   joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

	
    }
	private void GrabObject2()
	{

		objectInHand = collidingObject;
		collidingObject = null;
		objectInHand.transform.position = this.transform.position ;

		objectInHand.transform.rotation = this.transform.rotation;
		objectInHand.transform.Rotate (new Vector3 (-90, 90, 0));
	//	var joint = AddFixedJoint();
	//	joint.connectedBody = objectInHand.GetComponent<Rigidbody>();


	}

    private FixedJoint AddFixedJoint()
    {
         FixedJoint fx = gameObject.AddComponent<FixedJoint>();

    return fx;
    }
    private void ReleaseObject()
    {

        if (GetComponent<FixedJoint>())
        {
    
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }

        objectInHand = null;
    }
    void Start() {
        foreach (string i in UnityEngine.Input.GetJoystickNames()) {
            print(i);
        }
        swordInHand = false;
		crossbowInHand = false;
		crossbowDelay = false;
    }
	// Update is called once per frame
	void Update () {



		if(Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && crossbowInHand == true && crossbowDelay == false)
		{
			crossbowDelay = true;
			Rigidbody arrowInstance;
			arrowInstance = Instantiate(arrowPrefab, crossbowEnd.position, crossbowEnd.rotation) as Rigidbody;
			arrowInstance.AddForce(crossbowEnd.right * -1000);
			Invoke("CrossbowFireReset", 0.75f);
			//audio
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(shootSound,vol);

		}



	
		if (Controller.GetPress(SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log(gameObject.name + " Grip Press");

		}
		if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
			Debug.Log(gameObject.name + " Grip Release");

		}

		if (Controller.GetHairTriggerDown() && collidingObject.gameObject.layer == 11)
        {
		//	crossbowInHand = false;
			swordInHand = true;
	
			objectInHand.GetComponent<Rigidbody> ().isKinematic = true;

			//objectInHand.transform.parent = gameObject.transform;
        }
			
		if (Controller.GetHairTriggerDown() && collidingObject.gameObject.layer == 12)
		{
		//	swordInHand = false;
			crossbowInHand = true;
		
			objectInHand.GetComponent<Rigidbody> ().isKinematic = true;
		
		//	objectInHand.transform.parent = gameObject.transform;
		}
	/*		
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
			swordInHand = false;
			crossbowInHand = false;
	
			objectInHand.GetComponent<Rigidbody> ().isKinematic = false;
		//	objectInHand.gameObject.parent = null;

		}
*/
		if (swordInHand == true) {
			GrabObject();
		}

		if (crossbowInHand == true) {
			GrabObject2();
		}







	






    }
}
