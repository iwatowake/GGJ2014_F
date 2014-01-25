using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		State_InGame scr = GameObject.Find ("InGameManager").GetComponent<State_InGame> ();

		if (other.tag == "Player" &&
		    scr.hasKey) 
		{
			scr.Goal();
			other.GetComponent<CharacterMovement>().isFreesed = true;
		}
	}
	
}
