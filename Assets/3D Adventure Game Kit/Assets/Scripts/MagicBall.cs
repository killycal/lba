using UnityEngine;
using System.Collections;

public class MagicBall : MonoBehaviour
{	
	public GameObject MagicBall_prefab;
	private GameObject MagicBall_object;
	private GameObject CheckForMagicBall;
	public float myTimer= 5.0f;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			CheckForMagicBall = GameObject.FindWithTag("MagicBall");
			if (CheckForMagicBall == null)
			{
				MagicBall_object = (GameObject)Instantiate(MagicBall_prefab, transform.position + transform.forward+transform.up, transform.rotation);
				MagicBall_object.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
			}
		}
	}
}
