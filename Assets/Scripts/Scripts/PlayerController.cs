using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	private Animator myAnimator;

	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	bool grounded = false;

	public Transform groundCheck;

	float groundRadius = 0f;

	public float jumpForce = 700f;

	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
		facingRight = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		float horizontal = Input.GetAxis ("Horizontal");

		HandleMovement (horizontal);

		Flip (horizontal);

	}

	void Update()
	{
		if (grounded && Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
		}
	}

	private void HandleMovement(float horizontal){
		myRigidBody.velocity = new Vector2 (horizontal * movementSpeed, myRigidBody.velocity.y);

		myAnimator.SetFloat ("speed", Mathf.Abs(horizontal));


	}
		
	private void Flip(float horizontal){
		if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
			{
				facingRight = !facingRight;

				Vector3 theScale = transform.localScale;

				theScale.x *= -1;

				transform.localScale = theScale;
			}
	}

}
