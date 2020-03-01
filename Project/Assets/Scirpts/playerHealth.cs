using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {


	public int currentHealth = 10;
	public int damageAmount = 1;
	private Transform healthBar;
	private Transform health;
	public float takingDMG;
	public float totalHealth = 10;
	public bool gotHit = false;
	public bool playerDamage = false;
	public bool playerAlive = true;

	private void playerDamageDelay(){
		playerDamage = false;
	}





	public void OnTriggerStay(Collider other)
	{
		
		if (other.gameObject.layer == 16 && playerDamage == false && playerAlive == true) {
			currentHealth -= damageAmount;
			playerDamage = true;

			//healthbar code start
			healthBar = transform.Find ("HealthBar"); 
			health = healthBar.Find ("RedBar");
			if (gotHit == false) {
				takingDMG = health.localScale.y * (damageAmount / totalHealth);
				Debug.Log(" player got hit");
				gotHit = true;
			}
			health.localScale -= new Vector3 (0, takingDMG, 0);
			//healthbar code end

			Invoke ("playerDamageDelay", 1f);
			if (currentHealth <= 0) {
				//Destroy (other);
				playerAlive = false;
			Debug.Log(" show death ");
			}
		}

		if (other.gameObject.layer == 17 && playerDamage == false && playerAlive == true) {
			currentHealth -= damageAmount;
			playerDamage = true;

			//healthbar code start
			healthBar = transform.Find ("HealthBar"); 
			health = healthBar.Find ("RedBar");
			if (gotHit == false) {
				takingDMG = health.localScale.y * (damageAmount / totalHealth);
				Debug.Log(" player got hit");
				gotHit = true;
			}
			health.localScale -= new Vector3 (0, takingDMG, 0);
			//healthbar code end

			Invoke ("playerDamageDelay", 1f);
			if (currentHealth <= 0) {
				//Destroy (other);
				playerAlive = false;
				Debug.Log(" show death ");
			}
		}


	}
		
}
