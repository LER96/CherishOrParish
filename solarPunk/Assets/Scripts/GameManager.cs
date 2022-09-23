using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Document> allDocuments;
    LineGenerator line;
    [SerializeField] GameObject button;
    [SerializeField] int totalScore;
    [SerializeField] int randomFile;
    [SerializeField] public Document doc;
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

    //private void Update()
    //{
    //    if(line.hancock)
    //    {
    //        button.SetActive(true);
    //    }
    //}

    public void Sign()
    {
        totalScore += allDocuments[randomFile].influence;
        //button.SetActive(false);
        RemoveDoc();
        TakeDoc();
    }
    public void RemoveDoc()
    {
        allDocuments.Remove(allDocuments[randomFile]);
        TakeDoc();
    }

    public void TakeDoc()
    {
        randomFile = Random.Range(0, allDocuments.Count);
        doc = allDocuments[randomFile];
    }
}
