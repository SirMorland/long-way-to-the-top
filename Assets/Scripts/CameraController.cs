using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public bool firstBoss = false;
	public bool secondBoss = false;

	GameObject player;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update ()
	{
		transform.Translate(Time.deltaTime * 1f, 0f, 0f);

		if (!firstBoss)
		{
			transform.position = new Vector3(Mathf.Min(transform.position.x, 40f), transform.position.y, -10f);
		}
		if (firstBoss && !secondBoss)
		{
			transform.position = new Vector3(Mathf.Min(transform.position.x, 120f), transform.position.y, -10f);
		}
		if (secondBoss)
		{
			transform.position = new Vector3(Mathf.Min(transform.position.x, 220f), transform.position.y, -10f);
		}

		if (transform.position.x >= 50 && transform.position.x <= 71)
		{
			transform.position = new Vector3(transform.position.x, transform.position.x - 50f + 5f, -10f);
		}
		if (transform.position.x >= 130 && transform.position.x <= 151)
		{
			transform.position = new Vector3(transform.position.x, transform.position.x - 130f + 26f, -10f);
		}

		if (player.transform.position.x > 50 && !firstBoss)
		{
			firstBoss = true;
		}
		if (player.transform.position.x > 130 && !secondBoss)
		{
			secondBoss = true;
		}
	}
}
