using UnityEngine;
using System.Collections;

public class MasterData : MonoBehaviour {

	[HideInInspector]
	public	float	TotalTime = 100.0f;
	[HideInInspector]
	public	int		TotalRotation = 0;

	public	void	Reset(){
		TotalTime = 0;
		TotalRotation = 0;
	}

	protected static MasterData instance;
	
	public static MasterData Instance
	{
		get
		{
			if(instance == null)
			{
				instance = (MasterData) FindObjectOfType(typeof(MasterData));
				
				if (instance == null)
				{
					Debug.LogError("MasterData Instance Error");
				}
			}
			
			return instance;
		}
	}

	void Start(){
		DontDestroyOnLoad(gameObject);
	}
}
