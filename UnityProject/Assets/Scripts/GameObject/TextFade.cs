using UnityEngine;
using System.Collections;

public class TextFade : MonoBehaviour {

	public	void	FadeIn(float time){
		Hashtable ht = new Hashtable ();
		ht.Add ("time", time);
		ht.Add ("from", 0);
		ht.Add ("to", 1.0f);
		ht.Add ("onupdate", "UpdateHandler");

		iTween.ValueTo (gameObject, ht);
	}

	public	void	FadeOut(float time){
		Hashtable ht = new Hashtable ();
		ht.Add ("time", time);
		ht.Add ("from", 1.0f);
		ht.Add ("to", 0);
		ht.Add ("onupdate", "UpdateHandler");
		
		iTween.ValueTo (gameObject, ht);
	}

	void	UpdateHandler(float	alpha){
		gameObject.guiText.color =  new Color(gameObject.guiText.color.r, gameObject.guiText.color.g, gameObject.guiText.color.b, alpha);
	}
}
