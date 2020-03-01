using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowGhost : MonoBehaviour {
	public int currentHealth = 20;
	public int damageAmount = 1;





	void OnTriggerEnter(Collider col){

		if (col.gameObject.layer == 14) {
			currentHealth -= damageAmount;
			Destroy (col.gameObject);


			if (currentHealth <= 0) 
			{
				Destroy (gameObject);
			}
		}

	}







}
