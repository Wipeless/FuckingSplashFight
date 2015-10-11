using UnityEngine;
using System.Collections;

public class cameraFollowPlayer2 : MonoBehaviour {

    public Transform target;
    public Transform lookTarget;
    public float zoom = 15f;
    public float smoothness = 5f;
    public bool isZoomed = false;
    float defaultFOV = 60;


    public void Start()
    {

    }

    public void LateUpdate()
    {
        if (target && lookTarget)
        {
            //hard coding! watch out!
            //transform.position = new Vector3(transform.position.x, transform.position.y, lookTarget.position.z);

            target.transform.LookAt(lookTarget);
            if (lookTarget.GetComponent<PlayerScript>().Attack)
            {
                //Time.timeScale = 1f;
                target.GetComponent<Camera>().fieldOfView = Mathf.Lerp(target.GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smoothness);
            }
            else
            {
                target.GetComponent<Camera>().fieldOfView = Mathf.Lerp(target.GetComponent<Camera>().fieldOfView, defaultFOV, Time.deltaTime * smoothness);
                
            }
        }
    }
}
