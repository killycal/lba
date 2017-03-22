using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraController : MonoBehaviour {
	public float distancex=30;
	public float distancey=10;
	public float distancez=10;
	public float dampTime = 0.5f;
	private Vector3 velocity = Vector3.zero;

	void Update () {
		Vector3 PlayerPOS = GameObject.FindWithTag("Player").transform.transform.position;
		Vector3 to = new Vector3(PlayerPOS.x+distancex, PlayerPOS.y+distancey, PlayerPOS.z + distancez);
		GameObject.FindWithTag("MainCamera").transform.position = Vector3.SmoothDamp(Camera.main.transform.position, to, ref velocity, dampTime);
	}
}
