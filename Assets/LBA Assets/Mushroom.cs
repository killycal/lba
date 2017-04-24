using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {
	public AudioClip destroy;
	public GameObject heart_prefab;
	private GameObject heart_object;
	public GameObject mana_prefab;
	private GameObject mana_object;
	public GameObject coin_prefab;
	private GameObject coin_object;

	public float yield;
	private float value;
	// Use this for initialization
	void Start () 
	{
	}

	void OnCollisionEnter(Collision collision)
	{
		value=Random.value;

		if (collision.gameObject.tag == "Player") {
			if (value < .33) {
				heart_object = (GameObject)Instantiate (heart_prefab);
				heart_object.transform.position = gameObject.transform.position;
			} else if (value < .66) {
				mana_object = (GameObject)Instantiate (mana_prefab);
				mana_object.transform.position = gameObject.transform.position;
			} else {
				coin_object = (GameObject)Instantiate (coin_prefab);
				coin_object.transform.position = gameObject.transform.position;
			}
				
				Destroy (gameObject);
		}
	}
}
