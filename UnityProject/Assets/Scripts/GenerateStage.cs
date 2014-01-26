using UnityEngine;
using System.Collections;

public class GenerateStage : MonoBehaviour {

	public	Texture2D		map;

	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			GenerateFromBitmap();
		}
	}

	void GenerateFromBitmap(){
//		Texture2D map = (Texture2D)Resources.Load("Textures/stage1");
		int w = map.width;
		int h = map.height;
		
		int x = 0,y = 0;
		
		float u = 1.0f/w;
		float v = 1.0f/h;
		float uHalf = u*(w*0.5f-0.5f);
		float vHalf = v*(h*0.5f-0.5f);

		GameObject wall = new GameObject ();
		wall.name = "Blocks";

		for(int i=h-1; i>-1; i--)
		{
			GameObject line = new GameObject();
			line.name = "blocks_line" + i;

			for(int j=0; j<w; j++)
			{
				Color pixel = map.GetPixel(j,i);
				
				if(pixel == Color.black)
				{
					GameObject go =	Instantiate(Resources.Load("Prefabs/Block"), new Vector3(-15.5f+j, -15.5f+i, 0.0f), Quaternion.identity) as GameObject;
					go.transform.parent = line.transform;
					go.name = "block";
					go.layer = (int)E_LAYER.Blocks;
				}
			}
			if(line.transform.childCount == 0)
				Destroy(line);
			else
				line.transform.parent = wall.transform;
		}

	}
}
