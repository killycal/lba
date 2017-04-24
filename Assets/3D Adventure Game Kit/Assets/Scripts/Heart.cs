using UnityEngine;
using System.Collections;

/// <summary>
/// Method extends collectable and changes the Effect.
/// </summary>
public class Heart : Collectable {

    public GameObject fx;   //Prefab of Particle Effect.
    public AudioClip sfx;   //Sound Effect.
	public float value = 1.0f;   //How much the heart heals.
	//private int direction=0;

    public override void Effect(GameObject player)
    {
        //Makes sure the player isn't at full health
			//If the script has a defined FX then it is spawned when the heart is picked up.
			if (fx) {
				GameObject newFx = Instantiate (fx);
				newFx.transform.position = transform.position;

			}

			//If the script has a defined SFX then it is played when the heart is picked up.
			if (sfx != null) {
				GetComponent<AudioSource> ().PlayOneShot (sfx);
			}

			//Heal the player for the defined value.
		if ((value > 0.0f) && (value < 1.0f) && (player.GetComponent<Health> ().currentHealth < player.GetComponent<Health> ().healthMax)) {
			player.GetComponent<Health> ().Heal ((int)(value * 10.0f));
			Destroy (transform.parent.gameObject);
		} 
		else if ((value < 0.0f) && (value > -1.0f) && (player.GetComponent<Health> ().currentMana < player.GetComponent<Health> ().manaMax)) {
			player.GetComponent<Health> ().ChangeMana ((int)(value * -10.0f));
			Destroy (transform.parent.gameObject);
		} 
		else if (transform.parent.name == "Coin(Clone)") {
			//Destroy the heart.
			Destroy (transform.parent.gameObject);
		}
    }
}
