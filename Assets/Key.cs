using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectable {

	public GameObject fx;   //Prefab of Particle Effect.
	//public AudioClip sfx;   //Sound Effect.
	public int value = 1;   //How much the heart heals.
	private GameObject obj;
	private GameObject controller = null;
	private MagicBall ball;
	public Vector3 dist;
	private Vector3 force;
	private bool hit;

	public override void Effect(GameObject player)
	{
		//Makes sure the player isn't at full health
		//if (player.GetComponent<Health> ().currentHealth < player.GetComponent<Health> ().healthMax) {
			//If the script has a defined FX then it is spawned when the heart is picked up.
			if (fx) {
				GameObject newFx = Instantiate (fx);
				newFx.transform.position = transform.position;

			}

			//Destroy the heart.
		Destroy (transform.parent.gameObject);
		player.GetComponent<Health> ().KeyCounter (1);
		controller.GetComponent<PlayerHealth> ().SetKeyHit (false);
	}
	void Start ()
	{
		controller = GameObject.FindWithTag("Player");
		//ball = obj.AddComponent<MagicBall>(); 
	}
	void Update()
	{
		hit = controller.GetComponent<PlayerHealth> ().GetKeyHit ();
		if (hit==true)
			transform.position = Vector3.Lerp(transform.position, controller.transform.position, 0.13f);
	}
}
