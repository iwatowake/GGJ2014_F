using UnityEngine;
using System.Collections;

public class UI_InGame : MonoBehaviour {
	
	public	TextFade	message;
	public	TextFade	time_cap;
	public	TextFade	time_counter;
	public	TextFade	timeOver;

	public	GUITexture	allow_left;
	public	GUITexture	allow_right;
	public	GUITexture	key;
	public	Animator	stageClear;

	public	void	LeftAllowEnable(bool enable){
		allow_left.guiTexture.enabled = enable;
	}

	public	void	RightAllowEnable(bool enable){
		allow_right.guiTexture.enabled = enable;
	}

	public	void	AllowReset(){
		allow_left.guiTexture.enabled = allow_right.guiTexture.enabled = true;
	}

	public	void	KeyEnable(bool enable){
		key.guiTexture.enabled = enable;
	}

	public	void	StageClear(){
		stageClear.enabled = true;
	}
}
