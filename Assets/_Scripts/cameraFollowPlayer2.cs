using UnityEngine;
using System.Collections;

public class cameraFollowPlayer2 : MonoBehaviour {

    public Transform LookTarget;
    public float zoom = 1f;
    public float smoothness = 5f;
    bool isZoomed = false;
    float defaultFOV = 60;
    float timeScale = 1f;


    public void Start()
    {

    }
    public void LateUpdate()
    {
        if (LookTarget)
        {
            //hard coding! watch out!
            //transform.position = new Vector3(transform.position.x, transform.position.y, lookTarget.position.z);

            transform.LookAt(LookTarget);

            if (LookTarget.GetComponent<PlayerScript>().AttackInit)
            {
                if (timeScale == 1f)
                    setTimeScale(.7f);
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smoothness);
            }
            else
            {
                if (timeScale != 1f)
                    setTimeScale(1f);
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, defaultFOV, Time.deltaTime * smoothness);
                
            }
        }
    }
    void setTimeScale(float t)
    {
        try
        {
            GameObject.Find("SceneManager").GetComponent<SceneManager>().TimeScale = t;
            Time.timeScale = t;
            timeScale = t;
        }
        catch 
        {
            timeScale = 1f;
            Debug.Log("didn't find SceneManager");
        }
    }
}
