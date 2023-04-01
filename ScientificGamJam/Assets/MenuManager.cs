using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    bool isAfficher = false;
    public Image tuto;

    public void NextLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void HelpMenu()
    {
        if (!isAfficher)
        {
            isAfficher = true;
            tuto.enabled = true;
        }
        else
        {
            isAfficher = false;
            tuto.enabled = false;
        }
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
