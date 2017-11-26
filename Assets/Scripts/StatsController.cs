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
	Animator anim;

	void Start()
	{
		spriteRend = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
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
				anim.SetTrigger("die");
				GetComponent<PlayerController>().enabled = false;
				Camera.main.GetComponent<CameraController>().enabled = false;
				StartCoroutine(End());
			}
			else
			{
				anim.SetTrigger("die");
				GetComponent<CapsuleCollider2D>().enabled = false;
				GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
				GetComponent<Rigidbody2D>().isKinematic = true;
			}
		}
	}

	IEnumerator End()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(2);
	}
}
