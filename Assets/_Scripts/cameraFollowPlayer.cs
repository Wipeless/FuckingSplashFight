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
            target.transform.LookAt(lookTarget);
        }
    }

}