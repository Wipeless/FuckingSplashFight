using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/Keyboard Orbit")]

public class cameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public Transform lookTarget;

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
        }
    }

}