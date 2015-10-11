using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {

    public bool CheckPointReached = false;

    void OnTriggerEnter(Collider collision)
    {
        //create splash
        if (collision.gameObject.tag == "Player")
        {
            //this checkpoint has been reached
            CheckPointReached = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        //create splash
        if (collision.gameObject.tag == "Player")
        {
            //reset checkpoint
            CheckPointReached = false;
        }
    }
}
