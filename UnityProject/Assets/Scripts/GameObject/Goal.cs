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
			gameObject.SetActive(false);
			Instantiate(Resources.Load("Prefabs/Rocket_Ignition"),transform.position,Quaternion.identity);
			other.GetComponent<CharacterMovement>().isFreesed = true;
			other.gameObject.GetComponent<CharacterFade>().FadeOut(0.05f);
			SoundManager.Instance.PlaySE((int)SE.rocket);
		}
	}
	
}
