using UnityEngine;
using System.Collections;

public class MagicBall_Lifespan : MonoBehaviour
{
	public float numberOfBounces = 3;
	public float toVel = 5f;
	public float maxVel = 20f;
	public float maxForce = 2f;
	public float gain = 5f;
	public GameObject controller = null;
	public GameObject obj;
	private MagicBall ball;
	private float currentNumberOfBounces = 0;
	private bool returnMagicBall = false;
	private Vector3 dist;
	private Vector3 force;




	// Initialization
	void Start ()
	{
		controller = GameObject.FindWithTag("Player");
		ball = obj.AddComponent<MagicBall>(); 
		ball.myTimer=5.0f;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentNumberOfBounces >= numberOfBounces)
		{
			returnMagicBall = true;
		}
		if (Input.GetButtonDown("Fire2"))
		{
			returnMagicBall = true;
		}
		if (ball.myTimer <= 0) 
		{
			returnMagicBall = true;
		} 
		else 
		{
			ball.myTimer -= Time.deltaTime;
		}
	}
	
	void FixedUpdate()
	{
		if (returnMagicBall == true)
		{			
				Vector3 dist = controller.transform.position - GetComponent<Rigidbody>().position;
				Vector3 tgtVel = Vector3.ClampMagnitude(toVel * dist, maxVel);
				Vector3 error = tgtVel - GetComponent<Rigidbody>().velocity;
				Vector3 force = Vector3.ClampMagnitude(gain * error, maxForce);
				GetComponent<Rigidbody>().AddForce(force);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		currentNumberOfBounces += 1;
		gameObject.SendMessage("PlaySound");
		print("collision with "+collision.transform.name);
		if (collision.gameObject.name == controller.name)
		{
			Destroy(gameObject);
		}
	}
}
