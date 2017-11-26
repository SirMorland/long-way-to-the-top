using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsController : MonoBehaviour
{
	public int maxHp;
	int hp;
	public int strenght;
	SpriteRenderer spriteRend;

	void Start()
	{
		spriteRend = GetComponent<SpriteRenderer>();
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
				spriteRend.enabled = false;
				Camera.main.GetComponent<CameraController>().enabled = false;
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
