using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class MagicBall_Soundhandler : MonoBehaviour
{
	public AudioClip[] sounds;
 
	void Awake() 
	{
	}
	
	void Start ()
	{
	}
	
	void Update()
	{
	}
	
	public void PlaySound()
	{	
		//GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource> ().PlayOneShot (sounds [0]);
	}
	public void PlaySoundEnemyHit()
	{
		//GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource> ().PlayOneShot (sounds [2]);
	}
	public void PlaySoundThrow()
	{
		GetComponent<AudioSource> ().PlayOneShot (sounds [1]);
	}
	public void PlaySoundReturnEmpty()
	{
		//GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().PlayOneShot (sounds [3]);
	}
}