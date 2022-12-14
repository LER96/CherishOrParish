using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Image[] pages = new Image[3];

    public Sprite[] onpage;

    public Image showTab;
    public Sprite on;
    public Sprite off;

    public List<Document> allDocuments;
    public float budget;

    [SerializeField] public Document[] partFiles = new Document[3];
    [SerializeField] public Document doc;

    [SerializeField] public int page=0;
    [SerializeField] public bool candraw;
    [SerializeField] public int count;

    [SerializeField] GameObject moveOn;
    [SerializeField] GameObject signCanvas;
    [SerializeField] GameObject tablet;
    bool tabletShow;

    [SerializeField] TMP_Text budgetText;
    [SerializeField] TMP_Text newsText;

    [SerializeField] public int totalInfluence;
    [SerializeField] int totalBudget;

    [SerializeField] int cycle = 0;

    [SerializeField] LineGenerator line;
    void Start()
    {
        pages[0].sprite = onpage[1];
        budget = 10;
        line = GameObject.FindGameObjectWithTag("Line").GetComponent<LineGenerator>();
        if (allDocuments!=null)
        {
            TakeDoc();
        }
    }

    private void Update()
    {

        if (tabletShow)
        {
            tablet.SetActive(true);

            line = GameObject.FindGameObjectWithTag("Line").GetComponent<LineGenerator>();
            if (count == 3)
            {
                candraw = true;
                signCanvas.SetActive(true);
                if (line.hancock)
                {
                    moveOn.SetActive(true);
                }
            }
        }
        else
            tablet.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            pages[i].sprite = onpage[0];
        }
        pages[page].sprite = onpage[1];

    }

    //button appear when you sign
    public void MoveON()
    {
        cycle++;
        if (cycle < 3)
        {
            candraw = false;
            line.hancock = false;
            TakeDoc();
        }
        else
            QuitGame();
    }

    //V button
    public void Sign()
    {
        totalInfluence += partFiles[page].influence;
        if (budget - partFiles[page].cost > 0)
        {
            budget -= partFiles[page].cost;
            if (partFiles[page].checkbox == 0)
            {
                count++;
            }
            partFiles[page].checkbox = 1;
            newsText.text = partFiles[page].news;
            if (page < 2)
            {
                page++;
            }
        }
        else
        {
            Debug.Log("Cant Do");
        }
    }

    //X button
    public void RemoveDoc()
    {
        if (partFiles[page].checkbox == 0)
        {
            count++;
        }
        partFiles[page].checkbox = -1;
        newsText.text = "";
        if (page < 2)
        {
            page++;
        }
    }

    //Get The Page
    public void ChangePaper(int num)
    {
        page = num;
    }

    public void Show()
    {
        if(tabletShow)
        {
            tabletShow = false;
            showTab.sprite = on;
        }
        else
        {
            tabletShow = true;
            showTab.sprite = off;
        }
    }

    //Take 3 documents from the list
    //restore all values
    public void TakeDoc()
    {
        NextRound();
        if (allDocuments !=null)
        {
            for (int i = 0; i < allDocuments.Count; i++)
            {
                allDocuments[i].checkbox = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                partFiles[i] = allDocuments[i];
            }
        }
    }

    public void NextRound()
    {
        page = 0;
        count = 0;
        budgetText.text = "Wallet: "+ budget + "M $";
        newsText.text = "";
        moveOn.SetActive(false);
        signCanvas.SetActive(false);
        candraw = false;

        for (int i = 0; i < 3; i++)
        {
            if (allDocuments.Contains(partFiles[i]))
            {
                allDocuments.Remove(partFiles[i]);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
