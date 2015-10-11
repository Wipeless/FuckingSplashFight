using UnityEngine;
using System.Collections;

public class cameraFollowPlayer2 : MonoBehaviour {

    public Transform LookTarget;
    public float zoom = 15f;
    public float smoothness = 5f;
    public bool isZoomed = false;
    float defaultFOV = 60;


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
                //Time.timeScale = 1f;
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smoothness);
            }
            else
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, defaultFOV, Time.deltaTime * smoothness);
                
            }
        }
    }
}
