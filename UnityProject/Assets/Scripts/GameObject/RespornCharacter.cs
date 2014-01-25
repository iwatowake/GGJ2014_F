using UnityEngine;
using System.Collections;

public class RespornCharacter : MonoBehaviour {

	private	Vector3 defaultPosition;

	// Use this for initialization
	void Start () {
		defaultPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -30.0f)
						Resporn ();
	}

	void Resporn(){
		transform.position = defaultPosition;
		particleSystem.Play ();
	}
}
