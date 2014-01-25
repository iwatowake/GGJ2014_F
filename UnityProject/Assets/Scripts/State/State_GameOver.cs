using UnityEngine;
using System.Collections;

public class State_GameOver : StateBase {

	enum STATE
	{
		Start_Init=0,
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
			SoundManager.Instance.PlayBGM((int)BGM.gameover);
			state++;
			break;
		case STATE.Start_Exec:
			break;

		case STATE.Main_Init:
			state++;
			break;
		case STATE.Main_Exec:
			if(Input.anyKeyDown && !isFading)
			{
				state++;
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
			SoundManager.Instance.StopBGM();
			ChangeState(E_STATE.eTitle);
			break;
		}
	}

	protected override void OnCompleteFade(){
		base.OnCompleteFade ();
		state++;
	}

}

