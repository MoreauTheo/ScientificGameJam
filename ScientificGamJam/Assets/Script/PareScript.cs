using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PareScript : MonoBehaviour
{
    public ScriptManager ScriptManager;
    public int Place;
    void Start()
    {

        ScriptManager = GameObject.Find("GameManager").GetComponent<ScriptManager>();
        ScriptManager.keyed = false;
        Place = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScriptManager.TimerStep <= 0 && ScriptManager.keyed == false)
        {
            FindObjectOfType<AudioManager>().Play("BadChoice");
        }
        if (Place == 0)
        {
            if (transform.parent.name == "PlaceG1")
            {
                Place = 1;
            }
            if (transform.parent.name == "PlaceC1")
            {
                Place = 2;
            }
            if (transform.parent.name == "PlaceD1")
            {
                Place = 3;
            }
        }

        if (ScriptManager.keyed == false && (Place == 1 || Place == 2 || Place == 3))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Place == 1 && ScriptManager.TimerStep <=0.2f)
                {
                    ScriptManager.win = true;
                    FindObjectOfType<AudioManager>().Play("GoodChoice");

                }
                else
                    FindObjectOfType<AudioManager>().Play("BadChoice");
                ScriptManager.keyed = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (Place == 2 && ScriptManager.TimerStep <= 0.2f)
                {
                    ScriptManager.win = true;
                    FindObjectOfType<AudioManager>().Play("GoodChoice");
                }
                else
                    FindObjectOfType<AudioManager>().Play("BadChoice");
                ScriptManager.keyed = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Place == 3 && ScriptManager.TimerStep <= 0.2f)
                {
                    ScriptManager.win = true;
                    FindObjectOfType<AudioManager>().Play("GoodChoice");
                }
                else
                    FindObjectOfType<AudioManager>().Play("BadChoice");
                ScriptManager.keyed = true;
            }
        }



    }
}
