using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] pages = new GameObject[3];

    public List<Document> allDocuments;
    [SerializeField]public  Document[] partFiles = new Document[3];
    [SerializeField] public Document doc;

    [SerializeField] GameObject moveOn;
    [SerializeField] GameObject signCanvas;

    [SerializeField] int totalScore;
    [SerializeField] int randomFile;
    [SerializeField] public int page=0;
    [SerializeField] public bool candraw;

    [SerializeField] LineGenerator line;
    [SerializeField] public int count;
    // Start is called before the first frame update
    void Start()
    {
        //line = GameObject.FindGameObjectWithTag("Line").GetComponent<LineGenerator>();
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
        totalScore += partFiles[page].influence;
        if (partFiles[page].checkbox == 0)
        {
            count++;
        }
        partFiles[page].checkbox = 1;
        if (page < 2)
        {
            page++;
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
        count = 0;
        moveOn.SetActive(false);
        signCanvas.SetActive(false);
        candraw = false;

        for (int i = 0; i < 3; i++)
        {
            if(allDocuments.Contains(partFiles[i]))
            {
                allDocuments.Remove(partFiles[i]);
            }
            allDocuments[i].checkbox=0;
            partFiles[i] = allDocuments[i];
        }
        //doc = allDocuments[randomFile];
    }

}
