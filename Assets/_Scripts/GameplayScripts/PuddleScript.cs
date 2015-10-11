using UnityEngine;
using System.Collections;

public class PuddleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        // splash something?
        if (collision.gameObject.tag == "Player")
        {
         //   Debug.Log("puddle collision with player!");
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
