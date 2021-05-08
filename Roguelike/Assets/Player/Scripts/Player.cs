using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D rb;
	private Animator anim;
	public Camera cam;
	private bool facingLeft = false;
	private bool animLock = false;
	public float moveSpeed;
	public float dashSpeed;

	public Vector2 mousePos;
	private Vector2 moveDir;

	public enum State { Idle, Walk, Jump, Dash, Blink }
	public static State state;
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		state = State.Idle;
	}
	private void Update()
	{
		/*player.mousePos.x - rb.position.x < 0f && player.moveDir.sqrMagnitude == 0f*/
		anim.Play(state.ToString());
		#region Input
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

		#endregion

		#region Animation
		float animDir = mousePos.x - rb.position.x;
		anim.SetFloat("AnimDir", animDir);

		float animMvt = moveDir.x;
		anim.SetFloat("AnimMvt", animMvt);

		if (moveDir.sqrMagnitude == 0f)
		{
			state = State.Idle;
		}
		else if (moveDir.sqrMagnitude > 0f)
		{
			state = State.Walk;
			// Create reversed animation for walking backwards
		}
		#endregion

		switch (state)
		{
			case State.Idle:
				break;
			case State.Walk:
				break;
			case State.Jump:
				break;
			case State.Dash:
				break;
			case State.Blink:
				break;
		}
	}
	private void FixedUpdate()
	{
		switch (state)
		{
			case State.Idle:
				rb.velocity = Vector2.zero;
				break;
			case State.Walk:
				rb.velocity = moveDir * moveSpeed;
				break;
			case State.Jump:
				break;
			case State.Dash:
				rb.velocity = moveDir * dashSpeed;
				break;
			case State.Blink:
				break;
		}
	}
}
