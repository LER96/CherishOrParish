
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DocumentManager : MonoBehaviour
{
    GameManager manage;

    public TMP_Text date;
    public TMP_Text nameText;
    public TMP_Text startDescriptionText;
    public TMP_Text middleDescriptionText;
    public TMP_Text endDescriptionText;
    public TMP_Text costText;
    public TMP_Text proFit;

    int p;

    char dots = ':';
    char lines = '—';
    //public Image docArt;
    private void Start()
    {
        //manage = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        //descriptionText.text = manage.doc.documentTitle;
    }
    private void Update()
    {
        manage = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        middleDescriptionText.text = manage.partFiles[p].documentmMiddle;
        char[] words = manage.partFiles[p].documentmMiddle.ToCharArray();
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == dots)
            {
                Split(i+1);
            }
            if(words[i] == lines)
            {
                Split(i+1);
            }
        }

        p = manage.page;

        date.text = manage.partFiles[p].date;
        nameText.text = manage.partFiles[p].documentTitle;
        startDescriptionText.text = manage.partFiles[p].documentStart;
    
        endDescriptionText.text = manage.partFiles[p].documentEnd;

        proFit.text = "Profit: "+ manage.partFiles[p].profit+"M$";
        costText.text="Cost: "+ manage.partFiles[p].cost+"M$";

}

    // string name= "liron \n rotman
    public void Split(int num)
    {
        middleDescriptionText.text = middleDescriptionText.text.Insert(num, "\n");
    }
}


