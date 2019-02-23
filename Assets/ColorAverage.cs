using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAverage : MonoBehaviour
{
	Texture2D tex;
	public Material target, target2;
    // Start is called before the first frame update
    void Start()
    {
		tex = GetComponent<Renderer>().material.GetTexture("_MainTex") as Texture2D;
		Color[] cols = tex.GetPixels();
		Color average = cols[0];
		//left to right, bottom to top
		for(int w = 1; w < cols.Length; w++) {
				average = (average + cols[w]) / 2;
		}


		for(int w = 1; w < cols.Length; w++) {
			cols[w] -= (average * average);
		}

		Texture2D nTex = new Texture2D(tex.width, tex.height, tex.format, false);

		nTex.SetPixels(cols);
		nTex.Apply();
		target.SetTexture("_MainTex", nTex);

		Texture2D nTex2 = new Texture2D(tex.width, tex.height, tex.format, false);
		average = cols[0];
		for(int w = 1; w < cols.Length; w++) {
			average = (average + cols[w]) / 2;
		}

		for(int w = 1; w < cols.Length; w++) {
			cols[w] = (cols[w] * average);
		}

		Debug.Log(average);
		nTex2.SetPixels(cols);
		nTex2.Apply();
		target2.SetTexture("_MainTex", nTex2);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
