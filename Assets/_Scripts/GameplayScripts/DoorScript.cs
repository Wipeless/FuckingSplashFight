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
    private bool isClose = true;

    // Use this for initialization
    void Start () {
        closePosition = transform.position;
        openPosition = transform.position + openPositionOffset;
	}
	
	// Update is called once per frame
	void Update () {

        if (isOpenRequest)
        {
            if (!isOpen)
            {
                transform.position = Vector3.Lerp(transform.position, openPosition, openRate);

                if (Vector3.Distance(transform.position, openPosition) < 0.25f)
                {
                    transform.position = openPosition;
                    isOpen = true;
                    isClose = false;
                    isOpenRequest = false;
                }
            }
            else
                isOpenRequest = false;
        }
        else if (isCloseRequest)
        {
            if (!isClose)
            {
                transform.position = Vector3.Lerp(transform.position, closePosition, closeRate);

                if (Vector3.Distance(transform.position, closePosition) < 0.25f)
                {
                    transform.position = closePosition;
                    isClose = true;
                    isOpen = false;
                    isCloseRequest = false;
                }
            }
            else
                isCloseRequest = false;
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
