using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rigid;
	Animator anim;
	SpriteRenderer spriteRend;
	float speed = 10f;
	bool grounded = false;

	StatsController statsController;
	public GameObject healthBar;

	void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		spriteRend = GetComponent<SpriteRenderer>();
		statsController = GetComponent<StatsController>();
	}

	void Update()
	{
		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			rigid.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rigid.velocity.y);
			anim.SetBool("isWalking", true);
			if (Input.GetAxisRaw("Horizontal") < 0 && !spriteRend.flipX)
			{
				spriteRend.flipX = true;
			}
			if (Input.GetAxisRaw("Horizontal") > 0 && spriteRend.flipX)
			{
				spriteRend.flipX = false;
			}
		}
		else
		{
			anim.SetBool("isWalking", false);
		}

		if (Input.GetButtonDown("Fire1"))
		{
			anim.SetTrigger("attack");
			CircleCollider2D hitbox = gameObject.AddComponent<CircleCollider2D>();
			hitbox.radius = 0.75f;
			hitbox.isTrigger = true;
			StartCoroutine(Hit(hitbox));
		}

		if (grounded && Input.GetButtonDown("Jump"))
		{
			grounded = false;
			rigid.AddForce(new Vector2(0f, 1200f));
		}
	}

	IEnumerator Hit(CircleCollider2D hitbox)
	{
		int direction = spriteRend.flipX ? -1 : 1;
		while (hitbox.offset.x < 0.5f && hitbox.offset.x > -0.5f)
		{
			hitbox.offset = new Vector2(hitbox.offset.x + Time.deltaTime * direction, 0f);
			yield return null;
		}
		Destroy(hitbox);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			grounded = true;
		}
		if (collision.gameObject.tag == "Enemy")
		{
			grounded = false;
			float direction = Mathf.Sign(transform.position.x - collision.contacts[0].point.x);
			rigid.AddForce(new Vector2(500f * direction, 500));
			statsController.DealDamage(collision.gameObject.GetComponent<StatsController>().strenght);
			healthBar.transform.localScale = new Vector3(statsController.Hp, 1f, 1f);
		}
	}
}
