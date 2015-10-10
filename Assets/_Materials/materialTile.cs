using UnityEngine;
using System.Collections;

public class materialTile : MonoBehaviour {


    public float scaleX = 1;
    public float scaleY = 1;
    int materialIndex = 0;
    //public Vector2 uvAnimationRate = new Vector2(.05f, .025f);
    string textureName = "_MainTex";

    Vector2 uvOffset = Vector2.zero;
    
    // Use this for initialization
    void Start () {
        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureScale(textureName, new Vector2(scaleX, scaleY));
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

}
