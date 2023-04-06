using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameleonScript : MonoBehaviour
{

    public ScriptManager ScriptManager;
    Renderer rend;
    public Material material;
    public MeshFilter camelMesh;
    public Mesh trueMesh;
    public Material trueMaterial;
    public Mesh falseMesh;
    public List<Material> listfalsematerial;
    public List<Mesh> listfalsemesh;
    public int index;
    public bool isPlan1;
    public int score = 0;

    void Start()
    {
        ScriptManager = GameObject.Find("GameManager").GetComponent<ScriptManager>();
        index = Random.Range(0, 3);
        falseMesh = listfalsemesh[index];
        camelMesh.mesh = falseMesh;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = listfalsematerial[index];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlan1)
        {
            camelMesh.mesh = trueMesh;
            rend = GetComponent<Renderer>();
            rend.sharedMaterial = trueMaterial;
            transform.localScale = new Vector3(100, 100, 100);
        }
        if (ScriptManager.TimerStep <= 0 && ScriptManager.keyed == false)
        {
            FindObjectOfType<AudioManager>().Play("BadChoice");
        }
        
        if (isPlan1 == false)
        {
            if (transform.parent.name == "PlaceG1" || transform.parent.name == "PlaceC1" || transform.parent.name == "PlaceD1")
            {
                isPlan1 = true;
            }
        }

        if (ScriptManager.keyed == false && isPlan1 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                    ScriptManager.win = true;
                    FindObjectOfType<AudioManager>().Play("GoodChoice");
                    ScriptManager.keyed = true;
                    ScriptManager.score ++;

            }
               
                
            

            if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                    
                 FindObjectOfType<AudioManager>().Play("Badchoice");

                ScriptManager.ennemyfinal = "camel";
                ScriptManager.keyed = true;
            }
        }



    }
}
