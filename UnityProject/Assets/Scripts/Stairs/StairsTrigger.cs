using UnityEngine;
using System.Collections;

public class StairsTrigger : MonoBehaviour
{
	private CharacterMovement player;

	private void OnTriggerEnter(Collider obj)
	{
		if (obj.CompareTag("Player")) {
			player = (CharacterMovement) obj.gameObject.GetComponent("CharacterMovement");
			player.EnterStairs(transform.position.x, transform.position.y + transform.localScale.y/2 );
		}
	}

	private void OnTriggerExit(Collider obj)
	{
		if (obj.CompareTag("Player")) {
			player.ExitStairs();
		}
	}

}
