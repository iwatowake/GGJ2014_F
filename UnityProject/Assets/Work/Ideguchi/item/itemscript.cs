﻿using UnityEngine;
using System.Collections;

public class itemscript : MonoBehaviour {


	public string objname;
	public string sendtext;
//	public int key	=	0;
//	public int time	=	0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable(){
	
	}

	void OnTriggerEnter (Collider player){

		if(player.gameObject.tag  == "Player" ){
			//gameObject.Find(objname).gameObject = sendtext;
			GameObject.Find(objname).SendMessage(sendtext);		// Edit by iwatowake
			SoundManager.Instance.PlaySE((int)SE.itemget);
			gameObject.SetActiveRecursively(false);				
			OnDisable();
		}
	}


}
