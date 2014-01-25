#define TIME_MODE
using UnityEngine;
using System.Collections;

public class SetRate : MonoBehaviour {

	private	float[]		RecordLine_Time = {
		60.0f,	// S
		90.0f,	// A
		120.0f	// B
	};

	private	int[]		RecordLine_Rotation = {
		15,		// S
		30,		// A
		45		// B
	};

	// Use this for initialization
	void Start () {
	#if TIME_MODE
		Debug.Log(MasterData.Instance.TotalTime);
		if (MasterData.Instance.TotalTime <= RecordLine_Time [0])
				guiTexture.texture = (Texture)Resources.Load ("Textures/s");
		else if (MasterData.Instance.TotalTime <= RecordLine_Time [1])
				guiTexture.texture = (Texture)Resources.Load ("Textures/a");
		else if (MasterData.Instance.TotalTime <= RecordLine_Time [2])
				guiTexture.texture = (Texture)Resources.Load ("Textures/b");
		else
				guiTexture.texture = (Texture)Resources.Load ("Textures/c");
	#else
		if (MasterData.Instance.TotalRotation <= RecordLine_Rotation [0])
			guiTexture.texture = (Texture)Resources.Load ("Textures/s");
		else if (MasterData.Instance.TotalRotation <= RecordLine_Rotation [1])
			guiTexture.texture = (Texture)Resources.Load ("Textures/a");
		else if (MasterData.Instance.TotalRotation <= RecordLine_Rotation [2])
			guiTexture.texture = (Texture)Resources.Load ("Textures/b");
		else
			guiTexture.texture = (Texture)Resources.Load ("Textures/c");
	#endif
	}

}
