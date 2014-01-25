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

	public	void	FadeIn(GameObject oncompletetarget, string oncomplete, float time){
		Hashtable ht = new Hashtable ();
		ht.Add ("time", time);
		ht.Add ("color", defaultColor);
		ht.Add ("oncompletetarget", oncompletetarget);
		ht.Add ("oncomplete", oncomplete);
		iTween.ColorTo (gameObject, ht);
	}
	
	public	void	FadeOut(GameObject oncompletetarget, string oncomplete, float time){
		Hashtable ht = new Hashtable ();
		ht.Add ("time", time);
		ht.Add ("color", Color.clear);
		ht.Add ("oncompletetarget", oncompletetarget);
		ht.Add ("oncomplete", oncomplete);
		iTween.ColorTo (gameObject, ht);
	}
}
