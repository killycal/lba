using UnityEngine;
using System.Collections;

public class MagicBall_Lifespan : MonoBehaviour
{
	public float numberOfBounces = 3;
	public float toVel = 10f;
	public float maxVel = 30f;
	public float maxForce = 10f;
	public float gain = 5f;
	public GameObject controller = null;
	public GameObject obj;
	private GameObject item;
	private MagicBall ball;
	private float currentNumberOfBounces = 0;
	private bool returnMagicBall = false;
	public Vector3 dist;
	private Vector3 force;
	private bool enemyHit=false;
	private bool played=false;
	private bool keyExists=false;
	public bool keyHit = false;



	// Initialization
	void Start ()
	{
		controller = GameObject.FindWithTag("Player");
		ball = obj.AddComponent<MagicBall>(); 
		ball.myTimer=5.0f;
		gameObject.SendMessage ("PlaySoundThrow");
		if (item = GameObject.FindWithTag ("Key"))
			keyExists = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if ((currentNumberOfBounces >= numberOfBounces)||(Input.GetButtonDown("Fire2"))||(ball.myTimer <= 0))
		{
			returnMagicBall = true;
		}
		else 
		{
			ball.myTimer -= Time.deltaTime;
		}
		if (returnMagicBall == true)
		{			
			Vector3 dist = controller.transform.position - GetComponent<Rigidbody>().position;
			Vector3 tgtVel = Vector3.ClampMagnitude(toVel * dist, maxVel);
			Vector3 error = tgtVel - GetComponent<Rigidbody>().velocity;
			Vector3 force = Vector3.ClampMagnitude(gain * error, maxForce);
			GetComponent<Rigidbody>().AddForce(force);
			//transform.position = Vector3.Lerp(transform.position, controller.transform.position, 0.01f);

			if ((enemyHit == false) && (played == false)) {
				gameObject.SendMessage ("PlaySoundReturnEmpty");
				played = true;
			}
			if (Mathf.Abs(dist.x) < 1 && Mathf.Abs(dist.z) < 1) 
				Destroy(gameObject);
		}
		else if (keyExists == true) 
		{
			Vector3 dist = item.transform.position - GetComponent<Rigidbody>().position;
			Vector3 tgtVel = Vector3.ClampMagnitude(toVel * dist, maxVel);
			Vector3 error = tgtVel - GetComponent<Rigidbody>().velocity;
			Vector3 force = Vector3.ClampMagnitude(gain * error, maxForce);
			GetComponent<Rigidbody>().AddForce(force);
			dist = controller.transform.position - GetComponent<Rigidbody>().position;
		}

	}
	
	void FixedUpdate()
	{
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == controller.name) {
			print (dist.x + " " + dist.z + "it hit the player");
			Destroy (gameObject);
		} else if (collision.gameObject.tag == "Enemy") {
			gameObject.SendMessage ("PlaySoundEnemyHit");
			currentNumberOfBounces += 2;
		} else if (collision.gameObject.tag == "Key") {
			currentNumberOfBounces += 2;
			controller.GetComponent<PlayerHealth> ().SetKeyHit (true);
		}
		else {
			ball.GetComponent<Rigidbody>().AddForce(transform.forward*(1/2)+transform.up*2, ForceMode.Impulse);
			currentNumberOfBounces += 1;
			gameObject.SendMessage("PlaySound");
		}

	}
}
