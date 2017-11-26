using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
	Rigidbody2D rigid;
	GameObject player;
	SpriteRenderer spriteRend;
	float speed = 5f;
	bool grounded = false;

	StatsController statsController;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		rigid = GetComponent<Rigidbody2D>();
		spriteRend = GetComponent<SpriteRenderer>();
		statsController = GetComponent<StatsController>();
	}
	
	void Update ()
	{
		if (grounded)
		{
			float direction = Mathf.Sign(player.transform.position.x - transform.position.x);
			rigid.velocity = new Vector2(speed * direction, rigid.velocity.y);

			if (direction < 0 && spriteRend.flipX)
			{
				spriteRend.flipX = false;
			}
			if (direction > 0 && !spriteRend.flipX)
			{
				spriteRend.flipX = true;
			}
		}
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
			rigid.AddForce(new Vector2(500f * direction, 500));
			statsController.DealDamage(collider.GetComponent<StatsController>().strenght);
		}
	}
}
