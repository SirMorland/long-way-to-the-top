using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HephaestosController : MonoBehaviour
{

	Rigidbody2D rigid;
	GameObject player;
	SpriteRenderer spriteRend;
	float speed = 5f;
	bool grounded = false;
	StatsController statsController;
	Animator anim;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		rigid = GetComponent<Rigidbody2D>();
		spriteRend = GetComponent<SpriteRenderer>();
		statsController = GetComponent<StatsController>();
		anim = GetComponent<Animator>();
		StartCoroutine(Attack());
	}

	void Update ()
	{
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			grounded = false;
			float direction = Mathf.Sign(transform.position.x - collider.transform.position.x);
			rigid.AddForce(new Vector2(100f * direction, 100));
			statsController.DealDamage(collider.GetComponent<StatsController>().strenght);
		}
	}

	IEnumerator Attack()
	{
		while(true)
		{
			yield return new WaitForSeconds(4f);
			anim.SetTrigger("attack");
		}
	}
}
