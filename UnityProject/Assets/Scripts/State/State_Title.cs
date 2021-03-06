﻿using UnityEngine;
using System.Collections;

public class State_Title : StateBase {

	enum STATE
	{
		Start_Init = 0,
		Start_Exec,
		
		Main_Init,
		Main_Exec,
		
		Exit_Init,
		Exit_Exec,
		
		Out_Init,
		Out_Exec
	}
	

	private	STATE	state = STATE.Start_Init;
	
	// Update is called once per frame
	void Update () {
		switch (state) 
		{
		case STATE.Start_Init:
			FadeIn();
			SoundManager.Instance.volume.BGM = 100;
			SoundManager.Instance.PlayBGM((int)BGM.title);
			state++;
			break;
		case STATE.Start_Exec:
			if(Input.anyKeyDown)
			{
				state=STATE.Exit_Init;
			}
			break;
			
		case STATE.Main_Init:
			state++;
			break;
		case STATE.Main_Exec:
			if(Input.anyKeyDown)
			{
				state=STATE.Exit_Init;
			}
			break;
			
		case STATE.Exit_Init:
			FadeOut();
			state++;
			break;
		case STATE.Exit_Exec:
			break;
			
		case STATE.Out_Init:
			state++;
			break;
		case STATE.Out_Exec:
			ChangeState(E_STATE.eStage1);
			break;
		}
	}
	
	protected override void OnCompleteFade(){
		base.OnCompleteFade ();
		state++;
	}

}
