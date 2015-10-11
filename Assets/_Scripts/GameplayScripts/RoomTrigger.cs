using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {

    public bool CheckPointReached = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        //create splash
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("player is attempting to enter a new level!");
            //this checkpoint has been reached
            CheckPointReached = true;
        }
    }
}
