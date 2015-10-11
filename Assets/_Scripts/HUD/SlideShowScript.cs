using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlideShowScript : MonoBehaviour {

    //public Button skipButton;
    public int intervalTime = 5;
    float nowTime;
    float endTime;
    public float fadeTime = 1;
    int currentSlideIndex = 0;
    GameObject[] items;
    GameObject[] itemsSorted;
    GameObject fadingSlide = null;
    bool currentlyFadingIn = false;
    bool currentlyFadingOut = false;

    //SlideShow intro = new SlideShow();


    void Start()
    {
        // first get all items unsorted
        items = GameObject.FindGameObjectsWithTag("IntroSlide") as GameObject[];
        Debug.Log(items.Length);
        itemsSorted = new GameObject[items.Length];

        // sort all the items in a new array
        for (int i = 0; i < itemsSorted.Length; i++)
        {
            int num = i + 1;
            itemsSorted[i] = GameObject.Find("Slide" + num) as GameObject;
            Debug.Log("Slide" + num);
        }

        // make all the images be transparent but the first one in the array
        for(int i = 1; i < itemsSorted.Length; i++)
        {
            Image myImage = itemsSorted[i].GetComponentInChildren<Image>();
            Color c = myImage.color;
            float alpha = 0f;
            Color newColor = new Color(c.r, c.g, c.b, alpha);
            myImage.color = newColor;
            //itemsSorted[i].SetActive(false);
        }
        fadingSlide = itemsSorted[currentSlideIndex];
        initiateTimer();

    }

 
	// Update is called once per frame.
	void Update () {

        nowTime = Time.time;
        if (nowTime >= endTime )
        {
            getNextSlide();

        }
        if (currentlyFadingIn)
        {
            Image myImage = fadingSlide.GetComponentInChildren<Image>();
            Color c = myImage.color;
            float alpha = c.a;
            alpha += (Time.deltaTime / fadeTime);
            //print(alpha);
            Color newColor = new Color(c.r, c.g, c.b, alpha);
            myImage.color = newColor;
            if (newColor.a >= 1f)
            {
                currentlyFadingIn = false;
                Debug.Log("done fading in");
            }
        }
        if (currentlyFadingOut)
        {

            Image myImage = fadingSlide.GetComponentInChildren<Image>();
            Color c = myImage.color;
            float alpha = c.a;
            alpha -= (Time.deltaTime / fadeTime);
            //print(alpha);
            Color newColor = new Color(c.r, c.g, c.b, alpha);
            myImage.color = newColor;
            
            if (newColor.a <= 0f)
            {
                currentlyFadingOut = false;
                Debug.Log("done fading out");
            }
        }

    }
     
    void initiateTimer()
    {
        intervalTime = fadingSlide.GetComponent<SlidePropertiesScript>().timeToDisplay;
        nowTime = Time.time;
        endTime = nowTime + (float)intervalTime;
        Debug.Log("nowTime: " + nowTime);
        Debug.Log("endTime: " + endTime);
    }

    void getNextSlide()
    {
        if (currentSlideIndex < itemsSorted.Length - 1)
        {
            currentSlideIndex++;
            fadingSlide = itemsSorted[currentSlideIndex];
            currentlyFadingIn = true;
            Debug.Log("Starting to Fade...");
            initiateTimer();
        }
        else
        {
            for (int i = 0; i < itemsSorted.Length-1; i++)
            {
                Image myImage = itemsSorted[i].GetComponentInChildren<Image>();
                Color c = myImage.color;
                float alpha = 0f;
                Color newColor = new Color(c.r, c.g, c.b, alpha);
                myImage.color = newColor;
                //itemsSorted[i].SetActive(false);
            }
            fadingSlide = itemsSorted[currentSlideIndex];
            currentlyFadingOut = true;
        }

    }

}
