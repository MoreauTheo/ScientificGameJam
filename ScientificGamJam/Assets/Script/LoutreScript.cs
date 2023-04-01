using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoutreScript : MonoBehaviour
{
    public ScriptManager ScriptManager;
    public int Place;
    public bool keyed;
    void Start()
    {
        keyed = false;
        ScriptManager = GameObject.Find("GameManager").GetComponent<ScriptManager>();
        Place = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Place == 0)
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

        if (keyed == false && (Place ==1 || Place == 2 || Place == 3))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Place == 1)
                {
                    ScriptManager.win = true;

                }
                keyed = true;
            }
            if ( Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (Place == 2)
                {
                    ScriptManager.win = true;
                }
                keyed = true;
            }
            if ( Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Place == 3)
                {
                    ScriptManager.win = true;
                }
                keyed = true;
            }
        }
        
        
       
    }
}
