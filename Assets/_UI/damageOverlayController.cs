using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damageOverlayController : MonoBehaviour
{

    float fade;
    CanvasGroup cg;
    Image myImage;
    public Player player;


    // Use this for initialization
    void Start()
    {
        //myImage = GetComponent<Image>();
        cg = GetComponent<CanvasGroup>();
        fade = cg.alpha;
        //fade = myImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("]"))
        {
            fade += 0.05f; if (fade > 1) fade = 1;  // from 0.0 to 1.0
            //Color c = myImage.color;
            //c.a = fade;
            //myImage.color = new Color(c.r, c.g, c.b, fade);
            cg.alpha = fade;

        }
        if (Input.GetKeyDown("["))
        {
            fade -= 0.05f; if (fade < 0) fade = 0;  // from 0.0 to 1.0
            //Color c = myImage.color;
            //c.a = fade;
            //myImage.color = new Color(c.r, c.g, c.b, fade);
            cg.alpha = fade;

        }

    }
}
