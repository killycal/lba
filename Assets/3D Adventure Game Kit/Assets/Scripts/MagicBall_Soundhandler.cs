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
		GetComponent<AudioSource>().clip = sounds[0];
		GetComponent<AudioSource>().Play();
	}
	public void PlaySoundEnemyHit()
	{
		//GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().clip = sounds[2];
		GetComponent<AudioSource>().Play();
	}
	public void PlaySoundThrow()
	{
		//GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().clip = sounds [1];
		GetComponent<AudioSource> ().Play ();
	}
	public void PlaySoundReturnEmpty()
	{
		//GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().clip = sounds [3];
		GetComponent<AudioSource> ().Play ();
	}
}