
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DocumentManager: MonoBehaviour
{
    GameManager manage;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    //public Image docArt;
    private void Start()
    {
        manage = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        //descriptionText.text = manage.doc.documentTitle;
    }
    private void Update()
    {
        //Debug.Log(manage.doc.documentDescription);
        nameText.text = manage.doc.documentTitle;
        descriptionText.text = manage.doc.documentDescription;
    }

}


