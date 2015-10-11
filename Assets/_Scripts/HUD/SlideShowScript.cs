using UnityEngine;
using System.Collections;

public class SlideShowScript : MonoBehaviour {


    public int intervalTime = 3;
    float nowTime;
    float endTime;
    int currentSlideIndex = 0;
    GameObject[] items;

    //SlideShow intro = new SlideShow();


    void Start()
    {
        
        items = GameObject.FindGameObjectsWithTag("IntroSlide") as GameObject[];
        //itemsRemaining = items.Length;
        items[currentSlideIndex].SetActive(true);
        for(int i = 1; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }
        initiateTimer();

    }
 
	// Update is called once per frame.
	void Update () {

        nowTime = Time.time;
        if (nowTime >= endTime )
        {
            getNextSlide();

        }

    }
     
    void initiateTimer()
    {
        nowTime = Time.time;
        endTime = nowTime + intervalTime;
    }

    void getNextSlide()
    {
        if (currentSlideIndex < items.Length)
        {
            items[currentSlideIndex].SetActive(false);
            currentSlideIndex++;
            items[currentSlideIndex].SetActive(true);
            initiateTimer();
        }
        else
        {
            
            items[currentSlideIndex].SetActive(false);
        }
    }
}
