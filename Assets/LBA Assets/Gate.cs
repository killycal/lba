using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
	
	private bool unlocked=false;
	private Vector3 destination;
	public new AudioClip audio;
	public AudioSource audioSource;
	// Use this for initialization
	void Start () {
		destination=transform.position;
		destination.y = transform.position.y-10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (unlocked == true)
		transform.position = Vector3.Lerp(transform.position, destination, 0.05f);
	}
	void OnCollisionEnter(Collision c)
	{

		if (c.gameObject.tag == "Player")
		{
			if (c.gameObject.GetComponent<Health> ().getKey () == 1) {
				c.gameObject.GetComponent<Health> ().KeyCounter (-1);
				unlocked = true;
				//GetComponent<AbstractBehaviour> ().m_Audio.
				audioSource.PlayOneShot (audio, 5);
			}
		}
	}
}
