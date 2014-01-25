using UnityEngine;
using System.Collections;

public class StairsStartTrigger : MonoBehaviour {

	private CharacterMovement player;

	private void OnTriggerEnter(Collider obj)
	{
		if (obj.CompareTag("Player")) {
			player = (CharacterMovement) obj.gameObject.GetComponent("CharacterMovement");
			player.StartOfStairsEnter(transform.position.y);
		}
	}
	
	private void OnTriggerExit(Collider obj)
	{
		if (obj.CompareTag("Player")) {
			player.StartOfStairsExit(transform.position.y);
		}
	}
}
