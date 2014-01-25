using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" &&
		    GameObject.Find("InGameManager").GetComponent<State_InGame>().hasKey) 
		{
			gameObject.SetActive(false);
		}
	}

}
