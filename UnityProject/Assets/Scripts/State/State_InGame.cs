using UnityEngine;
using System.Collections;

public class State_InGame : StateBase {

	private	float	time = 180;
	public	GUIText GUI_timeCounter;

	void Update(){
		if (time > 0)
						time--;
		GUI_timeCounter.text = time.ToString("D");
	}

}
