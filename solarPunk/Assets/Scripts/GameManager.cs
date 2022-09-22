using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Document> allDocuments;
    [SerializeField] int totalScore;
    [SerializeField] int randomFile;
    // Start is called before the first frame update
    void Start()
    {
        TakeDoc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sign()
    {
        totalScore += allDocuments[randomFile].influence;
        RemoveDoc();
    }
    public void RemoveDoc()
    {
        allDocuments.Remove(allDocuments[randomFile]);
    }

    public void TakeDoc()
    {
        randomFile = Random.Range(0, allDocuments.Count);
    }
}
