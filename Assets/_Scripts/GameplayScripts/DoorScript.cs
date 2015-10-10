using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    Vector3 startPosition;
    Vector3 endPosition;
    Vector3 endPositionOffset = new Vector3(0, 5, 0);

    float openRate = 0.1f;

    private bool isOpenRequest = false;
    private bool isOpen = false;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        endPosition = transform.position + endPositionOffset;
	}
	
	// Update is called once per frame
	void Update () {
        if (isOpenRequest && !isOpen)
        {
            //Debug.Log("opening");

            transform.position = Vector3.Lerp(transform.position, endPosition, openRate);

            if (Vector3.Distance(transform.position, endPosition) < 0.5f)
            {
                transform.position = endPosition;
                isOpen = true;
            }
        }
            
	}

    public void OpenDoor()
    {
        if (!isOpenRequest)
        {
            //Debug.Log("open the damn door");

            isOpenRequest = true;
        }
    }
}
