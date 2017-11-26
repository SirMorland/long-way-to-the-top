using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsController : MonoBehaviour
{
	public int maxHp;
	int hp;
	public int strenght;

	void Start()
	{
		hp = maxHp;
	}

	public float Hp
	{
		get
		{
			return (float)hp / (float)maxHp;
		}
	}

	public void DealDamage(int damage)
	{
		hp -= damage;
		if(hp <= 0)
		{
			if (gameObject.tag == "Player")
			{
				SceneManager.LoadScene(2);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
