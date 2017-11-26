using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;

	bool stage2 = false;
	bool stage3 = false;

	void Start ()
	{
		StartCoroutine(Spawner(20f));
	}
	
	void Update ()
	{
		if (transform.position.x >= 80 && !stage2)
		{
			stage2 = true;
			StartCoroutine(Spawner(100f));
		}
		if (transform.position.x >= 160 && !stage3)
		{
			stage3 = true;
			StartCoroutine(Spawner(200f));
		}
	}

	IEnumerator Spawner(float x)
	{
		yield return new WaitForSeconds(2f);

		while (transform.position.x < x)
		{

			Instantiate(enemy).transform.position = transform.position + new Vector3(14f * (Random.Range(0, 2) * 2 - 1), 0f, 10f);
			yield return new WaitForSeconds(2f);
		}
	}
}
