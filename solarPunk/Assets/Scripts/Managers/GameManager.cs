using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] pages = new GameObject[3];

    public List<Document> allDocuments;
    public float budget;

    [SerializeField] public Document[] partFiles = new Document[3];
    [SerializeField] public Document doc;

    [SerializeField] public int page=0;
    [SerializeField] public bool candraw;
    [SerializeField] public int count;

    [SerializeField] GameObject moveOn;
    [SerializeField] GameObject signCanvas;
    [SerializeField] TMP_Text budgetText;

    [SerializeField] public int totalInfluence;
    [SerializeField] int totalBudget;

    [SerializeField] LineGenerator line;
    void Start()
    {
        budget = 10;
        line = GameObject.FindGameObjectWithTag("Line").GetComponent<LineGenerator>();
        if (allDocuments!=null)
        {
            TakeDoc();
        }
    }

    private void Update()
    {
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

    //button appear when you sign
    public void MoveON()
    {
        candraw = false;
        line.hancock = false;
        TakeDoc();
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
            if (page < 2)
            {
                page++;
            }
        }
        else
        {
            Debug.Log("Cant Do");
        }
        //button.SetActive(false);
        //RemoveDoc();
    }

    //X button
    public void RemoveDoc()
    {
        if (partFiles[page].checkbox == 0)
        {
            count++;
        }
        partFiles[page].checkbox = -1;
        if (page < 2)
        {
            page++;
        }
        //allDocuments.Remove(allDocuments[randomFile]);
        //TakeDoc();
    }

    //Get The Page
    public void ChangePaper(int num)
    {
        page = num;
    }

    //Take 3 documents from the list
    //restore all values
    public void TakeDoc()
    {
        for(int i=0; i<allDocuments.Count;i++)
        {

        }
        page = 0;
        count = 0;
        budgetText.text = budget + "M $";
        moveOn.SetActive(false);
        signCanvas.SetActive(false);
        candraw = false;

        for (int i = 0; i < 3; i++)
        {
            if(allDocuments.Contains(partFiles[i]))
            {
                allDocuments.Remove(partFiles[i]);
            }
        }

        for (int i = 0; i < allDocuments.Count; i++)
        {
            allDocuments[i].checkbox = 0;
        }

        for (int i=0; i<3; i++)
        {
            partFiles[i] = allDocuments[i];
        }
    }

}
