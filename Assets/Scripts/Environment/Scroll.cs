using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    [Range(0f, 5f)]
    public float ScrollScale = 0.2f;
    private Material mat;
	
	void Start ()
    {
        mat = GetComponent<Renderer>().material;
	}
	
	
	void Update ()
    {
        mat.mainTextureOffset = new Vector2(Time.time * ScrollScale, 0);
    }
}
