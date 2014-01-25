using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	private	Color	defaultColor = new Color();

	void	Start(){
		defaultColor = renderer.material.color;
	}

	public	void	FadeIn(float time){
		iTween.ColorTo (gameObject, defaultColor, time);
	}

	public	void	FadeOut(float time){
		iTween.ColorTo (gameObject, Color.clear, time);
	}
}
