using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject[] pages = new GameObject[3];

    public List<Document> allDocuments;
    [SerializeField]public  Document[] partFiles = new Document[3];
    [SerializeField] public Document doc;

    [SerializeField] GameObject moveOn;

    [SerializeField] int totalScore;
    [SerializeField] int randomFile;
    [SerializeField] public int page=0;
    [SerializeField] public bool candraw;
    LineGenerator line;
    // Start is called before the first frame update
    void Start()
    {
        //button.SetActive(false);
        //line = GameObject.FindGameObjectWithTag("Line").GetComponent<LineGenerator>();
        if (allDocuments!=null)
        {
            TakeDoc();
        }
    }

    private void Update()
    {
        //if (line.hancock)
        //{
        //    button.SetActive(true);
        //}
        CheckIfFinished();
    }

    public void CheckIfFinished()
    {
        int count = 0;
        for(int i=0; i<partFiles.Length;i++)
        {
            if(partFiles[i].checkbox!=0)
            {
                count++;
            }
            if(count==2)
            {
                moveOn.SetActive(true);
                candraw = true;
            }
        }
    }

    public void MoveON()
    {
        for(int i=0; i<partFiles.Length;i++)
        {
            if(allDocuments.Contains(partFiles[i]))
            {
                allDocuments.Remove(partFiles[i]);
            }
        }
        TakeDoc();
    }

    public void Sign()
    {
        totalScore += partFiles[page].influence;
        partFiles[page].checkbox = 1;
        //button.SetActive(false);
        //RemoveDoc();
    }
    public void RemoveDoc()
    {
        partFiles[page].checkbox = -1;
        //allDocuments.Remove(allDocuments[randomFile]);
        //TakeDoc();
    }

    public void ChangePaper(int num)
    {
        page = num;
    }

    public void TakeDoc()
    {
        candraw = false;
        moveOn.SetActive(false);
        for (int i = 0; i < partFiles.Length; i++)
        {
            randomFile = Random.Range(0, allDocuments.Count);
            partFiles[i] = allDocuments[randomFile];
        }
        //doc = allDocuments[randomFile];
    }

}
