using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {
	public AudioClip destroy;
	new AudioSource audio;
	public GameObject heart_prefab;
	private GameObject heart_object;
	public float yield;
	private float value;
	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision collision)
	{
		value=Random.value;

		if (collision.gameObject.tag == "Player")
		{
			if (value < yield) {
				heart_object = (GameObject)Instantiate (heart_prefab);
				heart_object.transform.position = gameObject.transform.position;
			}
				Destroy (gameObject);
		}
	}
}
