using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript : MonoBehaviour
{
    public ScriptManager ScriptManager;
    public int direction;
    public int indexsens;
    public bool isPlan1;
    void Start()
    {
        
        ScriptManager = GameObject.Find("GameManager").GetComponent<ScriptManager>();
        indexsens = Random.Range(0, 2);
        if (indexsens ==1)
            transform.localScale = new Vector3(1500, -1500,1500);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScriptManager.TimerStep <= 0 && ScriptManager.keyed == false)
        {
            FindObjectOfType<AudioManager>().Play("BadChoice");
        }
        if (transform.localScale.y < 0)
            direction = 1;
        if(isPlan1 == false)
        {
            if (transform.parent.name == "PlaceG1"|| transform.parent.name == "PlaceC1"|| transform.parent.name == "PlaceD1")
            {
                isPlan1 = true;
            }
        }

        if (ScriptManager.keyed == false && isPlan1 == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (direction == 1)
                {
                    ScriptManager.win = true;
                    FindObjectOfType<AudioManager>().Play("GoodChoice");
                    ScriptManager.score++;
                }
                else
                    FindObjectOfType<AudioManager>().Play("BadChoice");
                ScriptManager.ennemyfinal = "lion";
                ScriptManager.keyed = true;
            }
            
            if ( Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (direction == 0)
                {
                    ScriptManager.win = true;
                    FindObjectOfType<AudioManager>().Play("GoodChoice");
                    ScriptManager.score++;
                }
                else
                    FindObjectOfType<AudioManager>().Play("BadChoice");
                ScriptManager.keyed = true;
                ScriptManager.ennemyfinal = "lion";
            }
        }
        
        
       
    }
}
