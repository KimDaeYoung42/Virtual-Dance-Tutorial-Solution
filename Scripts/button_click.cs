using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test_ButtonClick()
    {
        SceneManager.LoadScene("TEST_Scene");
    }

    public void Practice_ButtonClick()
    {
        SceneManager.LoadScene("PRACTICE_Scene");
    }

    public void EXIT_ButtonClick()
    {
        Application.Quit();
    }
}
