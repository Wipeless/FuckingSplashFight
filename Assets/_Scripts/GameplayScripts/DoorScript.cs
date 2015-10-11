using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    Vector3 startPosition;
    Vector3 endPosition;
    Vector3 endPositionOffset = new Vector3(0, 5, 0);

    float openRate = 0.5f;

    private bool isOpenRequest = false;
    private bool isOpen = false;

    float closeRate = 0.5f;

    private bool isCloseRequest = false;
    private bool isClose = false;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        endPosition = transform.position + endPositionOffset;
	}
	
	// Update is called once per frame
	void Update () {

        if (isOpenRequest && !isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, openRate);

            if (Vector3.Distance(transform.position, endPosition) < 0.5f)
            {
                transform.position = endPosition;
                isOpen = true;
            }
        }
        else if (isCloseRequest && !isClose)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, closeRate);

            if (Vector3.Distance(transform.position, endPosition) < 0.5f)
            {
                transform.position = endPosition;
                isClose = true;
            }
        }

    }

    public void OpenDoor()
    {
        if (!isOpenRequest)
            isOpenRequest = true;
    }

    public void CloseDoor()
    {
        if (!isCloseRequest)
            isCloseRequest = true;
    }
}
