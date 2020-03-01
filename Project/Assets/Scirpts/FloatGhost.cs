using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatGhost : MonoBehaviour {
	public float height = 0.2f;

	public float moveSpeed = 1.5f;

	public Transform cameraRigg;

	Vector3 startPos = new Vector3 ();
	Vector3 flaotPos = new Vector3 ();

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		flaotPos = startPos;
		flaotPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * 0.5f) * height;
		transform.position = flaotPos;


		float moving = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, cameraRigg.position, moving/3);
		startPos.x = transform.position.x;
		startPos.z = transform.position.z;

	}
}

