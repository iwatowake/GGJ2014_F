using UnityEngine;
using System.Collections;

public	enum E_STATE
{
	eTitle=0,
	eStage1,
	eStage2,
	eStage3,
	eResult,
	eEnding
}

public class StateBase : MonoBehaviour {

	public	void	ChangeState(E_STATE nextState)
	{
		Application.LoadLevel ((int)nextState);
	}
}
