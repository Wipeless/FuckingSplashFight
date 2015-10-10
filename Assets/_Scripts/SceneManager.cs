using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {


    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnClickMainMenu()
    {
        Application.LoadLevel(1);
    }
}
