using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkinDestruction : MonoBehaviour {


	public AudioClip swordSound;
	private AudioSource source;
	private float volLowRange = .25f;
	private float volHighRange = 0.5f;


	void Awake () {

		source = GetComponent<AudioSource>();

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.layer == 11 && gameObject.layer == 17) {

			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(swordSound,vol);

			Destroy (gameObject);

		}
	}

	void Start()
	{
		Destroy (gameObject, 10f);
	}
}
