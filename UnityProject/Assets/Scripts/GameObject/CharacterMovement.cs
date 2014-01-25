using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
	public float colliderWidth = 1.0f;
	public float colliderHeight = 1.0f;

	public float speed = 5.0f;
	public float climbSpeed = 3.0f;
	public float gravity = 10.0f;

	private bool grounded = false;
	private bool onStairs = false;
	private bool falling = false;
	private bool climbing = false;

	private bool wallRight = false;
	private bool wallLeft = false;

	private bool endOfStairs = false;
	private bool startOfStairs = false;
	
	private float stairsX = 0.0f;

	private void Start()
	{
		//animation.wrapMode = WrapMode.Loop;
		//animation.Play ();
	}

	private void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float horizontalMovement = 0.0f;
		float verticalMovement = 0.0f;
		if ((onStairs || startOfStairs) && Input.GetKey(KeyCode.W)) {
			climbing = true;
			verticalMovement = climbSpeed * Time.deltaTime;
			if (transform.position.x != stairsX)
				transform.position = new Vector3(stairsX, transform.position.y, transform.position.z);
		}
		else if ((onStairs || endOfStairs) && Input.GetKey(KeyCode.S) && !startOfStairs) {
			climbing = true;
			verticalMovement = - climbSpeed * Time.deltaTime;
			if (transform.position.x != stairsX)
				transform.position = new Vector3(stairsX, transform.position.y, transform.position.z);
		}
		else if (onStairs && !climbing) {
			horizontalMovement = horizontalInput * speed * Time.deltaTime;
		}
		else if (grounded) {
			if ((horizontalInput > 0 && !wallRight) || (horizontalInput < 0 && !wallLeft))
				horizontalMovement = horizontalInput * speed * Time.deltaTime;
		}
		else if (falling && !climbing) {
			verticalMovement = - gravity * Time.deltaTime;
		}
		else {
			// onStairs && climbing -> don't do anything
		}
		transform.position += new Vector3(horizontalMovement, verticalMovement, 0);
	}

	private void FixedUpdate()
	{
		int mask = 1 << 8;	// Mask for raycast
		if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z),
		                    Vector3.down, colliderHeight, mask)) {
			grounded = true;
			falling = false;
		}
		else {
			grounded = false;
			falling = true;
		}
		if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z),
		                    Vector3.right, colliderWidth/2 + 0.1f, mask)) {
			wallRight = true;
		}
		else {
			wallRight = false;
		}
		if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z),
		                    -Vector3.right, colliderWidth/2 + 0.1f, mask)) {
			wallLeft = true;
		}
		else {
			wallLeft = false;
		}
	}

	/* Called by stair triggers */
	public void EnterStairs(float x, float y)
	{
		onStairs = true;
		stairsX = x;
	}

	public void ExitStairs()
	{
		onStairs = false;
		climbing = false;
	}

	public void EndOfStairsEnter(float y)
	{
		endOfStairs = true;
	}

	public void EndOfStairsExit(float y)
	{
		endOfStairs = false;
	}

	public void StartOfStairsEnter(float y)
	{
		startOfStairs = true;
	}

	public void StartOfStairsExit(float y)
	{
		startOfStairs = false;
	}
}