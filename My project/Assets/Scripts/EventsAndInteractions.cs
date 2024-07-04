using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsAndInteractions : MonoBehaviour
{
    public GameObject win, loose, UI;
    int outcome = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (outcome == 1) 
        {
            UI.SetActive(false);
            win.GetComponent<WinCondition>().win();
        }

        if (outcome == 2)
        {
            UI.SetActive(false);
            loose.GetComponent<LooseCondition>().loose();
        }
    }

    public void levelRestatr()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void levelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void victory(int result)
    {
        outcome = result;
    } 
}
