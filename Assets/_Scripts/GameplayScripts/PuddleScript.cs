using UnityEngine;
using System.Collections;

public class PuddleScript : MonoBehaviour {

    private bool isCollidingWithPlayer = false; public bool IsCollidingWithPlayer { get { return isCollidingWithPlayer; } }
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        // splash something?
        if (collision.gameObject.tag == "Player")
        {
            isCollidingWithPlayer = true;
            //   Debug.Log("puddle collision with player!");
        }
    }

    void OnTriggerExit(Collider collision)
    {
        // splash something?
        if (collision.gameObject.tag == "Player")
        {
            isCollidingWithPlayer = false;
            //   Debug.Log("puddle collision with player!");
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
