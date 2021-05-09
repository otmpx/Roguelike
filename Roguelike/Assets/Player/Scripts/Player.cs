using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D rb;
	private Animator anim;
	public Camera cam;
	public bool animLock = false;
	public float moveSpeed;
	public float jumpSpeed;
	public float dashSpeed;

	private Vector2 mousePos;
	private Vector2 moveDir;

	public enum State { Idle, Walk, Jump, Falling, Dash, Blink }
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
		moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		float animDir = mousePos.x - rb.position.x;
		float moveX = moveDir.x;
		float moveY = moveDir.y;
		anim.SetFloat("AnimDir", animDir);
		anim.SetFloat("AnimMvt", moveX);

		if (moveX == 0f)
		{
			state = State.Idle;
		}
		else if (moveX == 1f || moveX == -1f)
		{
			state = State.Walk;
			// Create reversed animation for walking backwards
		}
		if (moveY == 1f)
		{
			state = State.Jump;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			state = State.Dash;
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
			case State.Falling:
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
				rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * jumpSpeed);
				break;
			case State.Falling:
				break;
			case State.Dash:
				rb.velocity = new Vector2(moveDir.x * dashSpeed, 0);
				break;
			case State.Blink:
				break;
		}
	}
}
