using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
	public enum Direction {right, left};
	public enum Anim {idle, move, fall, up, down};
	private Direction facingDir = Direction.right;
	private Anim curAnim = Anim.idle;

	public Animation charaA;
	public Animation charaB;

	public float colliderWidth = 1.0f;
	public float colliderHeight = 1.0f;

	public float speed = 5.0f;
	public float climbSpeed = 3.0f;
	public float gravity = 10.0f;

	private Animation curChara;

	private bool grounded = false;
	private bool onStairs = false;
	private bool falling = false;
	private bool climbing = false;

	private bool wallRight = false;
	private bool wallLeft = false;

	private bool endOfStairs = false;
	private bool startOfStairs = false;
	
	private float stairsX = 0.0f;
	private float stairsEnd = 0.0f;

	private	bool freezed = false;

	public	bool isFreesed{
		get{return freezed;}
		set{freezed = value;}
	}

	public	bool isGruonded{
		get{return grounded;}
		set{grounded = value;}
	}

	private void Start()
	{
		charaA.wrapMode = WrapMode.Loop;
		charaB.wrapMode = WrapMode.Loop;
		SwitchChara(0);
		curChara.animation.Play("Idle");
	}

	private void Update()
	{
		if (freezed)
			return;

		if (Input.GetKeyDown(KeyCode.L)) {
			if (curChara == charaA)
				SwitchChara (1);
			else
				SwitchChara (0);
		}
		float horizontalInput = Input.GetAxis("Horizontal");
		float horizontalMovement = 0.0f;
		float verticalMovement = 0.0f;
		if ((onStairs || startOfStairs) && Input.GetKey(KeyCode.W)) {
			climbing = true;
			verticalMovement = climbSpeed * Time.deltaTime;
			if (transform.position.x != stairsX)
				transform.position = new Vector3(stairsX, transform.position.y, transform.position.z);
			ChangeAnimation(Anim.up);
		}
		else if ((onStairs || endOfStairs) && Input.GetKey(KeyCode.S) && !startOfStairs) {
			climbing = true;
			verticalMovement = - climbSpeed * Time.deltaTime;
			if (transform.position.x != stairsX)
				transform.position = new Vector3(stairsX, transform.position.y, transform.position.z);
			ChangeAnimation(Anim.down);
		}
		else if (onStairs && !climbing) {
			horizontalMovement = horizontalInput * speed * Time.deltaTime;
			if (horizontalInput == 0)
				ChangeAnimation(Anim.idle);
			else 
				ChangeAnimation(Anim.move);
		}
		else if (grounded || (!onStairs && endOfStairs)) {
			if ((horizontalInput > 0 && !wallRight) || (horizontalInput < 0 && !wallLeft))
				horizontalMovement = horizontalInput * speed * Time.deltaTime;
			if (horizontalInput == 0)
				ChangeAnimation(Anim.idle);
			else
				ChangeAnimation(Anim.move);
		}
		else if (falling && !climbing  && !endOfStairs) {
			verticalMovement = - gravity * Time.deltaTime;
			ChangeAnimation(Anim.fall);
		}
		else {
			// onStairs && climbing -> don't do anything
		}
		if (horizontalMovement < 0)
			ChangeDirection(Direction.right);
		else if (horizontalMovement > 0)
			ChangeDirection(Direction.left);
		transform.position += new Vector3(horizontalMovement, verticalMovement, 0);
	}

	private void FixedUpdate()
	{
		int mask = 1 << 8;	// Mask for raycast
		if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z),
		                    Vector3.down, colliderHeight/2 + 0.1f, mask)) {
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

	// 0 = charaA, 1 = charaB
	private void SwitchChara(int chara)
	{
		if (chara == 0) {
			charaB.gameObject.SetActive(false);
			charaA.gameObject.SetActive(true);
			curChara = charaA;
		}
		else {
			charaA.gameObject.SetActive(false);
			charaB.gameObject.SetActive(true);
			curChara = charaB;
		}
	}

	private void ChangeAnimation(Anim newAnim)
	{
		if (newAnim == curAnim)
			return;
		switch (newAnim) {
		case Anim.idle:
			SwitchChara(0);
			curChara.animation.Play("Idle");
			break;
		case Anim.move:
			SwitchChara(0);
			curChara.animation.Play("Move");
			break;
		case Anim.up:
			SwitchChara(1);
			curChara.animation.Play("Up");
			break;
		case Anim.down:
			SwitchChara(1);
			curChara.animation.Play("Up");
			break;
		case Anim.fall:
			SwitchChara(0);
			curChara.animation["Fall"].wrapMode = WrapMode.ClampForever;
			curChara.animation.Play("Fall");
			break;
		}
		curAnim = newAnim;
	}

	private void ChangeDirection(Direction newDir)
	{
		if (newDir == facingDir)
			return;
		switch (newDir) {
		case Direction.right:
			curChara.transform.Rotate(new Vector3(0, 180, 0));
			break;
		case Direction.left:
			curChara.transform.Rotate(new Vector3(0, 180, 0));
			break;
		}
		facingDir = newDir;
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
		stairsEnd = y;
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