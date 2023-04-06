using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
using UnityEngine.SceneManagement;


public class ScriptManager : MonoBehaviour
{
    public TMP_Text scorefield;
    [Header("Var Settingd")]
    public string ennemyfinal;
    public int score;
    public TMP_Text indice;
    public float StepGap;
    public bool win;
    public float TranslateTime = 0.2f;
    public bool keyed;
    [Header("Place Settings")]
    public GameObject Place1G;
    public GameObject Place1C;
    public GameObject Place1D;
    public GameObject ActualEnnemi;
    public GameObject Place2G;
    public GameObject Place2C;
    public GameObject Place2D;
    public GameObject Place3G;
    public GameObject Place3C;
    public GameObject Place3D;
    [Header("RandomShow Settings")]
    public List<GameObject> ListPlace;
    public List<GameObject> ListPlace2;
    public List<GameObject> ListPlace3;
    public int SpawnIndex;
    [Header("WikiEnnemi Settings")]
    public List<GameObject> WikiEnnemi;
    [Header("User Settings")]
    public Slider LifeBar;
    public float life;
    public Slider DebugSlider;
    public float TimerStep;
    public GameObject LoosePanel;
    public AudioSource DangerGO;
    public float actualScore = 0;
    public float bestScore = 0;


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
        FindObjectOfType<AudioManager>().Play("Ambiance");
        actualScore = 0;
        win = true;
        life = 11;
        TimerStep = StepGap;
        ListPlace.Add(Place1G);
        ListPlace.Add(Place1C);
        ListPlace.Add(Place1D);
        ListPlace2.Add(Place2G);
        ListPlace2.Add(Place2C);
        ListPlace2.Add(Place2D);
        ListPlace3.Add(Place3G);
        ListPlace3.Add(Place3C);
        ListPlace3.Add(Place3D);
        SpawnIndex = Random.Range(0, 3);
        ActualEnnemi = Instantiate(WikiEnnemi[Random.Range(0, WikiEnnemi.Count)], ListPlace3[SpawnIndex].transform.position, ListPlace3[SpawnIndex].transform.rotation);
        ActualEnnemi.transform.SetParent(ListPlace3[SpawnIndex].transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))
        {
            SceneManager.LoadScene("Menu");
        }
        scorefield.text = "Score : " + score;
        TimerStep -= Time.deltaTime;
        DebugSlider.value = TimerStep;
        if (TimerStep <= 0)
        {
            NextStep();  
        }
        LifeBar.value = life;
        if(life <=0 )
        {

            FindObjectOfType<AudioManager>().Play("Loser");
            Loose();
        }
    }

    public void NextStep()
    {
        if (win == true && life <10)
        {
            life += 0.5f;
        }
        else
            life -= 1;
        //Debug.Log("Step");
        TimerStep = StepGap;
            
        keyed = false;
        if(life > 0)
        {
            NextPlan();
            SpawnIndex = Random.Range(0, 3);
            ActualEnnemi = Instantiate(WikiEnnemi[Random.Range(0, WikiEnnemi.Count)], ListPlace3[SpawnIndex].transform.position, ListPlace3[SpawnIndex].transform.rotation);
            ActualEnnemi.transform.SetParent(ListPlace3[SpawnIndex].transform);
            win = false;
            ennemyfinal = "";
            
            
        }
    }
    public void Loose()
    {

        GameObject[] ADetruire = GameObject.FindGameObjectsWithTag("Pet");
        foreach (GameObject pet in ADetruire)
        {
            GameObject.Destroy(pet);
        }
        LoosePanel.SetActive(true);
        DebugSlider.gameObject.SetActive(false);
        LifeBar.gameObject.SetActive(false);
        if (ennemyfinal == "lion")
            indice.text = "Aie, le lion t'a eu! \n Lorsqu'il s'approche de toi, soit attentif à la \n direction vers laquelle il regarde";
        if (ennemyfinal == "loutre")
            indice.text = "Aie, la loutre t'a eu! \n Lorsqu'elle s'approche de toi, soit attentif au couloir \n dans laquelle elle se trouve";
        if (ennemyfinal == "pare")
            indice.text = "Aie, le paresseux t'a eu! \n Lorsqu'il s'approche de toi, ne réponds pas trop vite \n pour ne pas le brusquer !";
        if (ennemyfinal == "camel")
            indice.text = "Aie, le caméléon t'a eu! \n Lorsqu'il s'approche de toi, il apparait au dernier \n moment! Trouve LA réponse qui lui correspond afin \n d'être réactif.";
        if (ennemyfinal == "")
            indice.text = "Aie, tu n'a rien fait! \n Essaie toujours d'apprendre comment fonctionne un animal \n Ce n'est pas grave de se tromper et de perdre.";
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            Restart();
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("BoutonBip");

        LoosePanel.SetActive(false);
        DebugSlider.gameObject.SetActive(true);
        LifeBar.gameObject.SetActive(true);
        win = true;
        life = 11;
        score = 0;
        ennemyfinal = "";
        NextStep();
    }

    public void NextPlan()
    {
        if (Place1G.transform.childCount == 1)
        {
            Transform detruit = Place1G.transform.GetChild(0);
            detruit.parent = null;
            Destroy(detruit.gameObject);
            if(win == false)
            FindObjectOfType<AudioManager>().Play("BadChoice");
        }
        if (Place1C.transform.childCount == 1)
        {
            Transform detruit = Place1C.transform.GetChild(0);
            detruit.parent = null;
            Destroy(detruit.gameObject);
            if (win == false)
                FindObjectOfType<AudioManager>().Play("BadChoice");
        }
        if (Place1D.transform.childCount == 1)
        {
            Transform detruit = Place1D.transform.GetChild(0);
            detruit.parent = null;
            Destroy(detruit.gameObject);
            if (win == false)
                FindObjectOfType<AudioManager>().Play("BadChoice");
        }
        if (Place2G.transform.childCount ==1)
        {
            Place2G.transform.GetChild(0).SetParent(Place1G.transform);
            Place1G.transform.GetChild(0).DOMoveZ(-4.5f, TranslateTime).SetEase(Ease.OutSine);
            //Place2G.transform.GetChild(0).gameObject.transform.position = Place1G.transform.position;
            
            

        }
        if (Place2C.transform.childCount == 1)
        {
            Place2C.transform.GetChild(0).SetParent(Place1C.transform);
            Place1C.transform.GetChild(0).DOMoveZ(-4.5f, TranslateTime).SetEase(Ease.OutSine);
            //Place2C.transform.GetChild(0).gameObject.transform.position = Place1C.transform.position;
            
        }
        if (Place2D.transform.childCount == 1)
        {
            Place2D.transform.GetChild(0).SetParent(Place1D.transform);
            Place1D.transform.GetChild(0).DOMoveZ(-4.5f, TranslateTime).SetEase(Ease.OutSine);
            //Place2D.transform.GetChild(0).gameObject.transform.position = Place1D.transform.position;
            
        }
        if (Place3D.transform.childCount == 1)
        {
            Place3D.transform.GetChild(0).SetParent(Place2D.transform);
            Place2D.transform.GetChild(0).DOMoveZ(-3.7f/7f, TranslateTime).SetEase(Ease.OutSine);
            //Place2D.transform.GetChild(0).gameObject.transform.position = Place1D.transform.position;

        }
        if (Place3G.transform.childCount == 1)
        {
            Place3G.transform.GetChild(0).SetParent(Place2G.transform);
            Place2G.transform.GetChild(0).DOMoveZ(-3.7f/7f, TranslateTime).SetEase(Ease.OutSine);
            //Place2D.transform.GetChild(0).gameObject.transform.position = Place1D.transform.position;

        }
        if (Place3C.transform.childCount == 1)
        {
            Place3C.transform.GetChild(0).SetParent(Place2C.transform);
            Place2C.transform.GetChild(0).DOMoveZ(-3.7f/7f, TranslateTime).SetEase(Ease.OutSine);
            //Place2D.transform.GetChild(0).gameObject.transform.position = Place1D.transform.position;

        }

    }

    
}
