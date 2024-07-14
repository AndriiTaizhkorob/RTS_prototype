using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsAndInteractions : MonoBehaviour
{
    public GameObject win, loose, UI, winSound, looseSound;
    int outcome = 0;
    AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        click = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (outcome == 1) 
        {
            UI.SetActive(false);
            win.GetComponent<WinCondition>().win();
            winSound.GetComponent<WinSound>().PlayMusic();
        }

        if (outcome == 2)
        {
            UI.SetActive(false);
            loose.GetComponent<LooseCondition>().loose();
            looseSound.GetComponent<LoseSound>().PlayMusic();
        }
    }

    public void levelRestart()
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

    public void ButtonSound()
    {
        click.Play();
    }
}