using UnityEngine;
using System.Collections;

public class CharacterFade : MonoBehaviour {
	
	private	Color	defaultColor = Color.white;

	public	void	FadeIn(float time){
		foreach(SkinnedMeshRenderer ren in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			iTween.ColorTo (ren.gameObject, defaultColor, time);
		}
	}
	
	public	void	FadeOut(float time){
		foreach(SkinnedMeshRenderer ren in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			iTween.ColorTo (ren.gameObject, Color.clear, time);
		}
	}
	
	public	void	FadeIn(GameObject oncompletetarget, string oncomplete, float time){
		Hashtable ht = new Hashtable ();
		ht.Add ("time", time);
		ht.Add ("color", defaultColor);
		ht.Add ("oncompletetarget", oncompletetarget);
		ht.Add ("oncomplete", oncomplete);
		foreach(SkinnedMeshRenderer ren in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			iTween.ColorTo (ren.gameObject, ht);
		}
	}
	
	public	void	FadeOut(GameObject oncompletetarget, string oncomplete, float time){
		Hashtable ht = new Hashtable ();
		ht.Add ("time", time);
		ht.Add ("color", Color.clear);
		ht.Add ("oncompletetarget", oncompletetarget);
		ht.Add ("oncomplete", oncomplete);
		foreach(SkinnedMeshRenderer ren in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			iTween.ColorTo (ren.gameObject, ht);
		}
	}

}
