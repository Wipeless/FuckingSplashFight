using UnityEngine;

public class LevelManagerScript : MonoBehaviour {

    public enum EnumLevelState
    {
        NORMAL = 0,
        PREPARING,
    }

    public EnumLevelState CurrentLevelState = EnumLevelState.NORMAL;

    private float transitionTimer;
    private const float transitionTimerLimit = 2;

    private float successTimer;                     //starts once all the levels have been cleared. upon completion, go to game over won scene
    private const float successTimerLimit = 3;
    
    public GameObject Level1_Entities;
    public GameObject Level2_Entities;
    public GameObject Level3_Entities;

    public GameObject Level1_Props;
    public GameObject Level2_Props;
    public GameObject Level3_Props;

    public GameObject Player;
    public GameObject Camera;

    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;

    public GameObject Hallway1;
    public GameObject Hallway2;
    public GameObject Hallway3;
 
    public GameObject Door1_2_exit;
    public GameObject Door2_3_entry;
    public GameObject Door2_3_exit;
    public GameObject Door3_final_entry;
    public GameObject Door3_final_exit;

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

    private bool isRequestLevelChange = false;

	// Use this for initialization
	void Start () {
        LoadLevel1();
	}
	
	// Update is called once per frame
	void Update () {

        if (isRequestLevelChange)
        {
            isRequestLevelChange = false;
            CurrentLevelState = EnumLevelState.PREPARING;
            Player.GetComponent<PlayerScript>().CurrentControlMode = PlayerScript.EnumControlMode.AUTO;

            transitionTimer = Time.time;
           
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

        switch (CurrentLevelState)
        {
            case EnumLevelState.NORMAL:
                //do nothing. the level is ready
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
                break;
            case EnumLevelState.PREPARING:
                if (Time.time - transitionTimer > transitionTimerLimit)
                {
                    Debug.Log("everything set. start level!");
                    SceneManager.ResetSceneState();
                    CurrentLevelState = EnumLevelState.NORMAL;
                    Player.GetComponent<PlayerScript>().CurrentControlMode = PlayerScript.EnumControlMode.NORMAL;
                }
                
                //spawn enemies
                
                //move cameras
                
                //prepare player

                break;
        }
	}

    private void LoadLevel1()
    {
        Level1_Entities.SetActive(true);

        if (Level1_Props != null)
            Level1_Props.SetActive(true);

        if (Room1 != null)
            Room1.SetActive(true);
        if (Door1_2_exit != null)
            Door1_2_exit.SetActive(true);
        if (Door2_3_entry != null)
            Door2_3_entry.SetActive(true);
        if (Hallway1 != null)
            Hallway1.SetActive(true);

        if (Room2 != null)
            Room2.SetActive(false);
        if (Room3 != null)
            Room3.SetActive(false);

        if (Door2_3_exit != null)
            Door2_3_exit.SetActive(false);
        if (Door3_final_entry != null)
            Door3_final_entry.SetActive(false);
        if (Door3_final_exit != null)
            Door3_final_exit.SetActive(false);

        if (Hallway2 != null)
            Hallway2.SetActive(false);
        if (Hallway3 != null)
            Hallway3.SetActive(false);

        //speical case: hide all entities except for the current first level

        Level2_Entities.SetActive(false);
        if (Level2_Props != null)
            Level2_Props.SetActive(false);

        Level3_Entities.SetActive(false);
        if (Level3_Props != null)
            Level3_Props.SetActive(false);
    }

    private void LoadLevel2()
    {
        Level2_Entities.SetActive(true);

        if (Level2_Props != null)
            Level2_Props.SetActive(true);

        if (Room2 != null)
            Room2.SetActive(true);
        if (Door2_3_entry != null)
            Door2_3_entry.SetActive(true);
        if (Door2_3_exit != null)
            Door2_3_exit.SetActive(true);
        if (Hallway2 != null)
            Hallway2.SetActive(true);
        if (Hallway1 != null)
            Hallway1.SetActive(true);

        if (Level1_Props != null)
            Level1_Props.SetActive(false);
        Level1_Entities.SetActive(false);

        if (Room1 != null)
            Room1.SetActive(false);
        if (Room3 != null)
            Room3.SetActive(false);

        if (Door1_2_exit != null)
            Door1_2_exit.SetActive(false);
        if (Door3_final_entry != null)
            Door3_final_entry.SetActive(false);
        if (Door3_final_exit != null)
            Door3_final_exit.SetActive(false);

        if (Hallway3 != null)
            Hallway3.SetActive(false);

        Door2_3_entry.GetComponent<MeshRenderer>().enabled = false;
        
        Player.transform.position = new Vector3(Door2_3_entry.transform.position.x, Player.transform.position.y, Door2_3_entry.transform.position.z + 2);
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Door2_3_entry.transform.position.z - 2);
    }

    private void LoadLevel3()
    {
        Level3_Entities.SetActive(true);

        if (Level3_Props != null)
            Level3_Props.SetActive(true);

        if (Room3 != null)
            Room3.SetActive(true);
        if (Door3_final_entry != null)
            Door3_final_entry.SetActive(true);
        if (Door3_final_exit != null)
            Door3_final_exit.SetActive(true);
        if (Hallway2 != null)
            Hallway2.SetActive(true);
        if (Hallway3 != null)
            Hallway3.SetActive(true);

        if (Room1 != null)
            Room1.SetActive(false);
        if (Room2 != null)
            Room2.SetActive(false);

        Level2_Entities.SetActive(false);
        if (Level2_Props != null)
            Level2_Props.SetActive(false);
        if (Door1_2_exit != null)
            Door1_2_exit.SetActive(false);
        if (Door2_3_entry != null)
            Door2_3_entry.SetActive(false);
        if (Door2_3_exit != null)
            Door2_3_exit.SetActive(false);

        if (Hallway1 != null)
            Hallway1.SetActive(false);

        Door3_final_entry.GetComponent<MeshRenderer>().enabled = false;

        Player.transform.position = new Vector3(Door3_final_entry.transform.position.x, Player.transform.position.y, Door3_final_entry.transform.position.z + 2);
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Door3_final_entry.transform.position.z - 2);
    }
}
