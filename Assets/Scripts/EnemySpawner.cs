using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;

	void Start ()
	{
		StartCoroutine(Spawner(20f));
	}
	
	void Update ()
	{
		
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
