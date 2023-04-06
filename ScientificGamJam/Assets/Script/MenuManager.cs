using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    bool isAfficher = false;
    public Image tuto;

    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("SampleScene");
        FindObjectOfType<AudioManager>().Play("BoutonBip");
    }

    public void HelpMenu()
    {
        if (!isAfficher)
        {
            isAfficher = true;
            tuto.enabled = true;
            FindObjectOfType<AudioManager>().Play("BoutonBip");
        }
        else
        {
            isAfficher = false;
            tuto.enabled = false;
            FindObjectOfType<AudioManager>().Play("BoutonBip");
        }
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
