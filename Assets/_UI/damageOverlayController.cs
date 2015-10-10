using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damageOverlayController : MonoBehaviour
{

    float fade;
    //CanvasGroup cg;
    Image myImage;
    public PlayerScript player;

    private float lastHealthUpdate;


    // Use this for initialization
    void Start()
    {
        myImage = GetComponentInChildren<Image>();
        //cg = GetComponent<CanvasGroup>();

        //fade = cg.alpha;
        fade = myImage.color.a;
        myImage.color = new Color(1f, 1f, 1f, 0f);

        lastHealthUpdate = (float)player.Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastHealthUpdate != (float)player.Health)
        {
            //calculate alpha only if health changes
            lastHealthUpdate = (float)player.Health;        

            myImage.color = new Color(1f, 1f, 1f, 1f - ((float)player.Health * 0.01f));
            // cg.alpha = 1f - ((float)player.Health / 100f);
            //Debug.Log(1f - ((float)player.Health / 100f));
            if (Input.GetKeyDown("]"))
            {
                fade += 0.05f; if (fade > 1) fade = 1;  // from 0.0 to 1.0
                myImage.color = myImage.color = new Color(1, 1, 1,  fade);
                //cg.alpha = fade;

            }
            if (Input.GetKeyDown("["))
            {
                fade -= 0.05f; if (fade < 0) fade = 0;  // from 0.0 to 1.0
                myImage.color = myImage.color = new Color(1, 1, 1, fade);
                //cg.alpha = fade;
            }
        }
    }
}
