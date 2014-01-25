using UnityEngine;
using System.Collections;

public	enum E_STATE
{
	eTitle=0,
	eStage1,
	eStage2,
	eStage3,
	eResult,
	eGameOver
}

public class StateBase : MonoBehaviour {

	public		Fade	fade;
	protected	bool	isFading = false;

	public	void	ChangeState(E_STATE nextState)
	{
		Application.LoadLevel ((int)nextState);
	}


	protected void	FadeIn(){
		isFading = true;
		fade.FadeOut(gameObject, "OnCompleteFade", 1.5f);
	}
	
	protected void	FadeOut(){
		isFading = true;
		fade.FadeIn(gameObject, "OnCompleteFade", 1.5f);
	}

	protected virtual void OnCompleteFade(){
		isFading = false;
	}
}
