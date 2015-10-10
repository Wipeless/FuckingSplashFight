using UnityEngine;
using System.Collections;

public class HUD_Gameplay : MonoBehaviour {

    public GameObject Panel_Background;
    public GameObject Button_Resume;
    public GameObject Button_Quit;
    public GameObject Text_Title;

    private enum EnumCurrentHUDState
    {
        DISPLAYED = 0,
        NOTDISPLAYED,
    }

    private EnumCurrentHUDState currentHUDState = EnumCurrentHUDState.NOTDISPLAYED;

	void Start () {
        HideMenus();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (currentHUDState)
            {
                case EnumCurrentHUDState.DISPLAYED:
                    //hide menus
                    HideMenus();
                    break;
                case EnumCurrentHUDState.NOTDISPLAYED:
                    //display pause
                    DisplayMenus();
                    break;
            }
        }
	}

    private void DisplayMenus()
    {
        currentHUDState = EnumCurrentHUDState.DISPLAYED;

        Panel_Background.SetActive(true);
        Button_Quit.SetActive(true);
        Button_Resume.SetActive(true);
        Text_Title.SetActive(true);
    }

    private void HideMenus()
    {
        currentHUDState = EnumCurrentHUDState.NOTDISPLAYED;

        Panel_Background.SetActive(false);
        Button_Quit.SetActive(false);
        Button_Resume.SetActive(false);
        Text_Title.SetActive(false);
    }

    public void OnClickResume()
    {
        HideMenus();
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
