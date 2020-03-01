using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {
   private SteamVR_TrackedObject trackedObj;

private SteamVR_Controller.Device Controller
{
    get { return SteamVR_Controller.Input((int)trackedObj.index); }
}

 
    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 laserPoint;
	public Transform cameraRigTransform; 
	//public GameObject teleportTargetPrefab;
	private GameObject locationSpot;
	private Transform teleportReticleTransform; 
	public Transform headTransform; 
	public Vector3 teleportTargetOffset; 
	public LayerMask teleportMask; 
	public LayerMask teleportDoorMask; 
	private bool shouldTeleport; 
	private GameObject door;
	private Vector3 nextRoomLocation;
	private float nextRoomX;
	private float nextRoomZ;

	public bool roomCleared;




 void Start () {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;

		roomCleared = false;


      //  locationSpot = Instantiate(teleportTargetPrefab);
//teleportReticleTransform = locationSpot.transform;
 
    }


void Awake()
{
    trackedObj = GetComponent<SteamVR_TrackedObject>();
}

 
    // Use this for initialization
       private void ShowLaser(RaycastHit hit) {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, laserPoint, 0.5f);
        laserTransform.LookAt(laserPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }


    // Update is called once per frame
    void Update () {
		if (Controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad) && roomCleared == true) {
            RaycastHit hit;

			if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, teleportMask)) {
                laserPoint = hit.point;
                ShowLaser(hit);
				door = null;
				if (Physics.Raycast (trackedObj.transform.position, transform.forward, out hit, 100, teleportDoorMask)) {

					door = hit.collider.gameObject;

				//	door.GetComponent<Door> ().z;
				//	Debug.Log (door.GetComponent<Door> ().z);
						nextRoomZ = door.transform.position.z - 8f;
					nextRoomX = door.transform.position.x;
					nextRoomLocation = new Vector3 (nextRoomX, 0f, nextRoomZ);

					shouldTeleport = true;

				}

        //        locationSpot.SetActive(true);
  //  teleportReticleTransform.position = laserPoint + teleportTargetOffset;
    	
            }
        }
        else 
        {
            laser.SetActive(false);
       //     locationSpot.SetActive(false);
        }
      if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport)
{
            SteamVR_Fade.View(Color.black, 1f);
            Invoke("Teleport", 1f);
      
}


    }

    
private void Teleport()
{

    shouldTeleport = false;
   //     locationSpot.SetActive(false);
    Vector3 difference = cameraRigTransform.position - headTransform.position;
    difference.y = 0;
		cameraRigTransform.position = nextRoomLocation + difference;
        SteamVR_Fade.View(Color.clear, 1f);

    }

}
