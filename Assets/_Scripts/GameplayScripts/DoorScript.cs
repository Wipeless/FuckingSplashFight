using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    Vector3 closePosition;
    Vector3 openPosition;

    Vector3 openPositionOffset = new Vector3(0, 5, 0);

    float openRate = 0.5f;

    private bool isOpenRequest = false;
    private bool isOpen = false;

    float closeRate = 0.5f;

    private bool isCloseRequest = false;
    private bool isClose = false;

    // Use this for initialization
    void Start () {
        closePosition = transform.position;
        openPosition = transform.position + openPositionOffset;
	}
	
	// Update is called once per frame
	void Update () {

        if (isOpenRequest && !isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, openRate);

            if (Vector3.Distance(transform.position, openPosition) < 0.5f)
            {
                transform.position = openPosition;
                isOpen = true;
            }
        }
        else if (isCloseRequest && !isClose)
        {
            transform.position = Vector3.Lerp(transform.position, closePosition, closeRate);

            if (Vector3.Distance(transform.position, closePosition) < 0.5f)
            {
                transform.position = closePosition;
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
