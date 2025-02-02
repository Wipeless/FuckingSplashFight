﻿using UnityEngine;
using System.Collections;

public class waterMatAnimScript : MonoBehaviour
{

    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(.05f, .025f);
    public string textureName = "_MainTex";

    Vector2 uvOffset = Vector2.zero;
    void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }



}
