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
		
		Over_FadeIn_Init,
		Over_FadeIn_Exec,

		Over_FadeOut_Init,
		Over_FadeOut_Exec,
		
		Exit_Init,
		Exit_Exec,
		
		Out_Init,
		Out_Exec
	}

	public			int			stageNumber = 0;
	private			float		time = 180;
	private			STATE		state = STATE.Start_Init;
	public			GUIText 	GUI_timeCounter;
	private			E_STATE		nextState = E_STATE.eGameOver;
	public			UI_InGame	ui_InGame;
	private			bool		bHasKey = false;
	private			float		waitTimer = 0;

	private	const	float		TIME_REWINDVALUE = 30.0f;

	public	bool	hasKey{
		get{ return bHasKey;}
	}

	void Update(){
		switch (state) 
		{
		case STATE.Start_Init:			// start
			state++;
			FadeIn();
			ui_InGame.message.FadeIn(0.5f);
			SoundManager.Instance.PlayBGM((int)BGM.stage);
			break;
		case STATE.Start_Exec:
			break;

		case STATE.Main_Init:			// main
			state++;
			ui_InGame.message.FadeOut(1.5f);
			break;
		case STATE.Main_Exec:
			Main_Exec();
			break;

		case STATE.Clear_Init:			// clear
			state++;
			nextState = E_STATE.eStage1 + stageNumber;
			ui_InGame.StageClear();
			SoundManager.Instance.StopBGM();
			SoundManager.Instance.PlaySE((int)SE.clear);
			break;
		case STATE.Clear_Exec:
			if((waitTimer+=Time.deltaTime) > 3.0f)
				state=STATE.Exit_Init;
			break;

		case STATE.Over_FadeIn_Init:	// over
			state++;
			nextState = E_STATE.eGameOver;
			ui_InGame.timeOver.FadeIn(1.0f);
			SoundManager.Instance.StopBGM();
			SoundManager.Instance.PlaySE((int)SE.gameover);
			GameObject.Find("Player").GetComponent<CharacterMovement>().isFreesed = true;
			break;
		case STATE.Over_FadeIn_Exec:
			if(ui_InGame.timeOver.GetAlpha() == 1.0f)
				state++;
			break;

		case STATE.Over_FadeOut_Init:	// over
			state++;
			nextState = E_STATE.eGameOver;
			ui_InGame.timeOver.FadeOut(1.0f);
			break;
		case STATE.Over_FadeOut_Exec:
			if(ui_InGame.timeOver.GetAlpha() == 0.0f)
				state++;
			break;

		case STATE.Exit_Init:			// exit
			FadeOut();
			state++;
			break;
		case STATE.Exit_Exec:
			break;

		case STATE.Out_Init:			// out
			state++;
			ui_InGame.timeOver.FadeOut(1.0f);
			break;
		case STATE.Out_Exec:
			ChangeState(nextState);
			break;
		}

	}
	
	void Main_Exec(){
		if (time > 0 && !isFading)
		{
			time-=Time.deltaTime;
			MasterData.Instance.TotalTime += Time.deltaTime;
			GUI_timeCounter.text = time.ToString("0");
		}else{
			state = STATE.Over_FadeIn_Init;
		}
	}

	protected override void OnCompleteFade(){
		base.OnCompleteFade ();
		state++;
	}

	public	void	Goal(){
		state = STATE.Clear_Init;
	}

	private	void	KeyGet(){
		bHasKey = true;
		ui_InGame.KeyEnable (true);
	}

	private	void	ClockGet(){
		time += TIME_REWINDVALUE;
	}
}
