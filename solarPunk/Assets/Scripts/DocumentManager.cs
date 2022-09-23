
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DocumentManager: MonoBehaviour
{
    GameManager manage;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    int p;
    //public Image docArt;
    private void Start()
    {
        //manage = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        //descriptionText.text = manage.doc.documentTitle;
    }
    private void Update()
    {
        manage = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        Debug.Log(p);
        p = manage.page;
        nameText.text = manage.partFiles[p].documentTitle;
        descriptionText.text = manage.partFiles[p].documentDescription;

    }

}


