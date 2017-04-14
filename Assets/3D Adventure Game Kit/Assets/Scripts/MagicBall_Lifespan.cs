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
	//public GameObject obj1;
	//public EnemyAI bad;
	private MagicBall ball;
	private float currentNumberOfBounces = 0;
	private bool returnMagicBall = false;
	public Vector3 dist;
	private Vector3 force;
	private bool enemyHit=false;
	private bool played=false;



	// Initialization
	void Start ()
	{
		controller = GameObject.FindWithTag("Player");
		ball = obj.AddComponent<MagicBall>(); 
		//bad = obj1.AddComponent<EnemyAI>(); 
		ball.myTimer=5.0f;
		gameObject.SendMessage ("PlaySoundThrow");

	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((currentNumberOfBounces >= numberOfBounces)||(Input.GetButtonDown("Fire2"))||(ball.myTimer <= 0))
		{
			returnMagicBall = true;
			if ((enemyHit == false) && (played == false)) {
				gameObject.SendMessage ("PlaySoundReturnEmpty");
				played = true;
			}
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
			if ((enemyHit == false) && (played == false)) {
				gameObject.SendMessage ("PlaySoundReturnEmpty");
				played = true;
			}
			if (Mathf.Abs(dist.x) < 1 & Mathf.Abs(dist.z) < 1) 
			{
				Destroy(gameObject);
			}
		}

	}
	
	void FixedUpdate()
	{
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		
		//print("collision with "+collision.transform.name);
		if (collision.gameObject.name == controller.name)
		{
			
			print (dist.x+" "+dist.z+ "it hit the player");
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "Enemy") {
			gameObject.SendMessage ("PlaySoundEnemyHit");
			enemyHit = true;
			Destroy (collision.gameObject); 
			currentNumberOfBounces += 2;
			//obj1.st= EnemyAI.State.Dead;
		} 
		else {
			ball.GetComponent<Rigidbody>().AddForce(transform.forward*(1/2)+transform.up*2, ForceMode.Impulse);
			currentNumberOfBounces += 1;
			gameObject.SendMessage("PlaySound");
		}

	}
}
