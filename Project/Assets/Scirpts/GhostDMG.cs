using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDMG : MonoBehaviour {

	public int currentHealth = 1;
	public int damageAmount = 1;
	private bool swordTimer = false;
	private Transform healthBar;
	private Transform health;
	private float takingDMG;
	public float totalHealth;
	private bool gotHit = false;
	public CountText countScript;
	public GameObject controllerScriptR;
	public GameObject controllerScriptL;

	//audio
	public AudioClip swordSound;
	private AudioSource source;
	private float volLowRange = .25f;
	private float volHighRange = 0.5f;



	void Awake () {

		source = GetComponent<AudioSource>();

	}


	private void SwordDelay(){
		swordTimer = false;
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 11) {
			if (controllerScriptR.GetComponent<WeaponGrab> ().swordInHand == true) {
				controllerScriptR.GetComponent<WeaponGrab> ().controllerPulse ();
			}
			if (controllerScriptL.GetComponent<WeaponGrab> ().swordInHand == true) {
				controllerScriptL.GetComponent<WeaponGrab> ().controllerPulse ();
			}
		}

	}

	void OnTriggerEnter(Collider col){



		if (col.gameObject.layer == 11 && swordTimer == false) {
			currentHealth -= damageAmount;
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(swordSound,vol);


			swordTimer = true;
/*			if (controllerScriptR.GetComponent<WeaponGrab> ().swordInHand == true) {
				controllerScriptR.GetComponent<WeaponGrab> ().controllerPulse ();
			}
			if (controllerScriptL.GetComponent<WeaponGrab> ().swordInHand == true) {
				controllerScriptL.GetComponent<WeaponGrab> ().controllerPulse ();
			}
*/	

			//healthbar code start
			healthBar = transform.Find("HealthBar"); 
			health = healthBar.Find ("RedBar");
			if (gotHit == false) {
				takingDMG = health.localScale.y * (damageAmount / totalHealth);
				gotHit = true;
			}
			health.localScale -= new Vector3(0,takingDMG,0);
			//healthbar code end

			Invoke("SwordDelay", 0.25f);
			if (currentHealth <= 0) 
			{
				Destroy (gameObject);
				countScript.remaining -= 1;
			}
		}
		
		if (col.gameObject.layer == 14) {
			currentHealth -= damageAmount;
			Destroy (col.gameObject);

			//healthbar code start
			healthBar = transform.Find("HealthBar"); 
			health = healthBar.Find ("RedBar");
			if (gotHit == false) {
				takingDMG = health.localScale.y * (damageAmount / totalHealth);
				gotHit = true;
			}
			health.localScale -= new Vector3(0,takingDMG,0);
			//healthbar code end


			if (currentHealth <= 0) 
			{
				Destroy (gameObject);
				countScript.remaining -= 1;
		
			}
		}

	}



}
