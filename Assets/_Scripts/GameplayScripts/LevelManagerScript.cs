using UnityEngine;

public class LevelManagerScript : MonoBehaviour {

    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;

    public GameObject Doorway1;
    public GameObject Doorway2;
    public GameObject Doorway3;
 
    public GameObject Door1_2_entry;
    public GameObject Door1_2_exit;
    public GameObject Door2_3_entry;
    public GameObject Door2_3_exit;
    public GameObject Door3_final;

    public GameObject TriggerBox_Level1_2;
    public GameObject TriggerBox_Level2_3;
    public GameObject TriggerBox_Level3_final;

    public enum EnumLevels
    {
        LEVEL1,
        LEVEL2,
        LEVEL3,
        FINAL,
    }

    public EnumLevels CurrentLevel = EnumLevels.LEVEL1;

    public bool isRequestLevelChange = false;

	// Use this for initialization
	void Start () {
        LoadLevel1();
	}
	
	// Update is called once per frame
	void Update () {

        if (TriggerBox_Level1_2.GetComponent<RoomTrigger>().CheckPointReached)
        {
            isRequestLevelChange = true;
            CurrentLevel = EnumLevels.LEVEL2;
        }
        else if (TriggerBox_Level2_3.GetComponent<RoomTrigger>().CheckPointReached)
        {
            isRequestLevelChange = true;
            CurrentLevel = EnumLevels.LEVEL3;
        }
        else if (TriggerBox_Level3_final.GetComponent<RoomTrigger>().CheckPointReached)
        {
            isRequestLevelChange = true;
            CurrentLevel = EnumLevels.FINAL;
        }

        if (isRequestLevelChange)
        {
            isRequestLevelChange = false;

            switch (CurrentLevel)
            {
                case EnumLevels.LEVEL1:
                    LoadLevel1();
                    break;
                case EnumLevels.LEVEL2:
                    LoadLevel2();
                    break;
                case EnumLevels.LEVEL3:
                    LoadLevel3();
                    break;
                case EnumLevels.FINAL:
                    //final level
                    break;
            }
        }
	}

    private void LoadLevel1()
    {
        Doorway3.SetActive(true);
        Room3.SetActive(true);
        Door1_2_entry.SetActive(true);

        Doorway1.SetActive(false);
        Doorway2.SetActive(false);
        Room1.SetActive(false);
        Room2.SetActive(false);
        Door1_2_exit.SetActive(false);
        Door2_3_entry.SetActive(false);
        Door2_3_exit.SetActive(false);
        Door3_final.SetActive(false);
    }

    private void LoadLevel2()
    {
        Doorway2.SetActive(true);
        Doorway3.SetActive(true);
        Room2.SetActive(true);
        Door1_2_exit.SetActive(true);
        Door2_3_entry.SetActive(true);

        Doorway1.SetActive(false);
        Room1.SetActive(false);
        Room3.SetActive(false);
        Door1_2_entry.SetActive(false);
        Door2_3_exit.SetActive(false);
        Door3_final.SetActive(false);
    }

    private void LoadLevel3()
    {
        Doorway1.SetActive(true);
        Doorway2.SetActive(true);
        Room1.SetActive(true);
        Door2_3_exit.SetActive(true);
        Door3_final.SetActive(true);

        Doorway3.SetActive(false);
        Room2.SetActive(false);
        Room3.SetActive(false);
        Door1_2_entry.SetActive(false);
        Door1_2_exit.SetActive(false);
        Door2_3_entry.SetActive(false);
    }
}
