using UnityEngine;
using System.Collections;

public class State_InGame : StateBase {

	enum STATE
	{
		Start_Init = 0,
		Start_Exec,
		
		Main_Init,
		Main_Exec,
		
		Clear_Init,
		Clear_Exec,
		
		Over_Init,
		Over_Exec,
		
		Exit_Init,
		Exit_Exec,
		
		Out_Init,
		Out_Exec
	}

	public	int			stageNumber = 0;
	private	float		time = 180;
	private	STATE		state = STATE.Start_Init;
	public	GUIText 	GUI_timeCounter;
	private	E_STATE		nextState = E_STATE.eGameOver;
	public	UI_InGame	ui_InGame;

	void Update(){
		switch (state) 
		{
		case STATE.Start_Init:	// start
			state++;
			FadeIn();
			ui_InGame.message.FadeIn(0.5f);
			break;
		case STATE.Start_Exec:
			break;

		case STATE.Main_Init:	// main
			state++;
			ui_InGame.message.FadeOut(1.5f);
			break;
		case STATE.Main_Exec:
			Main_Exec();
			break;

		case STATE.Clear_Init:	// clear
			state++;
			nextState = E_STATE.eStage1 + stageNumber;
			break;
		case STATE.Clear_Exec:
			break;

		case STATE.Over_Init:	// over
			state++;
			nextState = E_STATE.eGameOver;
			break;
		case STATE.Over_Exec:

			break;

		case STATE.Exit_Init:	// exit
			FadeOut();
			state++;
			break;
		case STATE.Exit_Exec:
			break;

		case STATE.Out_Init:	// out
			state++;
			break;
		case STATE.Out_Exec:
			break;
		}

	}
	
	void Main_Exec(){
		if (time > 0 && !isFading)
		{
			time-=Time.deltaTime;
			GUI_timeCounter.text = time.ToString("0");
		}else{
			state = STATE.Over_Init;
		}
	}

	protected override void OnCompleteFade(){
		base.OnCompleteFade ();
		state++;
	}

	public	void	Goal(){
		state = STATE.Clear_Init;
	}
}
