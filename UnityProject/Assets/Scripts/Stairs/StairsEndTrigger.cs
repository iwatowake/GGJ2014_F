using UnityEngine;
using System.Collections;

public class StairsEndTrigger : MonoBehaviour {

	private CharacterMovement player;
	
	private void OnTriggerEnter(Collider obj)
	{
		if (obj.CompareTag("Player")) {
			player = (CharacterMovement) obj.gameObject.GetComponent("CharacterMovement");
			player.EndOfStairsEnter(transform.position.y);
		}
	}
	
	private void OnTriggerExit(Collider obj)
	{
		if (obj.CompareTag("Player")) {
			player.EndOfStairsExit(transform.position.y);
		}
	}
}
