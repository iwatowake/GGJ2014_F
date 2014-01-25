using UnityEngine;
using System.Collections;

public class CubeParent : MonoBehaviour {

	public			GameObject	goCharacter;

	public			UI_InGame	uiIngame;

	private const	float		ROTATETIME 		= 1.0f;
	private			bool		isAnimating 	= false;

	/// <summary>
	/// Rotates the right.
	/// </summary>
	public	void	RotateLeft(){
		if (isAnimating)
			return;

		goCharacter.layer = (int)E_LAYER.Invisible;
		goCharacter.GetComponent<Fade> ().FadeOut (0.25f);

		Hashtable ht = new Hashtable ();

		ht.Add ("name", "RotateRight");
		ht.Add ("y", 90.0f);
		ht.Add ("easetype", iTween.EaseType.easeInOutQuad);
		ht.Add ("space", Space.Self);
		ht.Add ("oncomplete", "OnCompleteRotate");
		iTween.RotateAdd (gameObject,ht);

		isAnimating = true;

		uiIngame.RightAllowEnable (false);
	}


	/// <summary>
	/// Rotates the left.
	/// </summary>
	public	void	RotateRight(){
		if (isAnimating)
			return;

		goCharacter.layer = (int)E_LAYER.Invisible;
		goCharacter.GetComponent<Fade> ().FadeOut (0.25f);

		Hashtable ht = new Hashtable ();
		ht.Add ("name", "RotateLeft");
		ht.Add ("y", -90.0f);
		ht.Add ("easetype", iTween.EaseType.easeInOutQuad);
		ht.Add ("space", Space.Self);
		ht.Add ("oncomplete", "OnCompleteRotate");
		iTween.RotateAdd (gameObject,ht);

		isAnimating = true;

		uiIngame.LeftAllowEnable (false);
	}


	/// <summary>
	/// Raises the complete rotate event.
	/// </summary>
	void	OnCompleteRotate(){
		isAnimating = false;
		goCharacter.layer = (int)E_LAYER.Player;
		goCharacter.GetComponent<Fade> ().FadeIn (0.25f);
		uiIngame.AllowReset ();
	}


	/// <summary>
	/// ToDebug
	/// </summary>
	void Update(){
		if (Input.GetKeyDown (KeyCode.Z))
						RotateLeft ();

		if (Input.GetKeyDown (KeyCode.X))
			RotateRight ();
	}
}
