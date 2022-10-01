using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    GameManager manage;
    [SerializeField] Image skyImg;
    [SerializeField] Image foreGroundImg;
    [SerializeField] Image middleGroundImg;
    [SerializeField] Image buildingImg;
    [SerializeField] Image morebuildingImg;
    [SerializeField] Image grassImg;

    //0 regular, 1 ruin
    [SerializeField] Sprite[] sky= new Sprite[2];
    //0 regular, 1 ruin
    [SerializeField] Sprite[] foreGround= new Sprite[2];
    //0 regular, 1 ruin
    [SerializeField] Sprite[] middleGround= new Sprite[2];
    //0 regular, 1 glass
    [SerializeField] Sprite[] buildings= new Sprite[2];
    //0 regular, 1 glass
    [SerializeField] Sprite[] morebuildings = new Sprite[2];
    //0 regular, 1 moregrass
    [SerializeField] Sprite[] grass = new Sprite[2];

    [SerializeField] List<Document> copyDoc;
    [SerializeField] Document[] copyFiles= new Document[3];

    [SerializeField] GameObject grassOBJ;
    [SerializeField] GameObject birdsOBJ;

    string gl = "Glass";
    string g = "Grass";
    string moreH = "More Houses";
    string bird = "Birds";

    bool isGrass;
    bool moreHouses;

    private void Update()
    {
        manage = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        copyDoc = manage.allDocuments;
        for (int i = 0; i < 3; i++)
        {
            copyFiles[i] = manage.allDocuments[i];
        }
        Bad();
        Good();
    }

    public void Bad()
    {
        if(manage.totalInfluence<=-1)
        {
            middleGroundImg.sprite = middleGround[1];
            //g.sprite= middleGround[1];
            if (manage.totalInfluence <= -3)
            {
                foreGroundImg.sprite = foreGround[1];
                if (manage.totalInfluence <= -5)
                {
                    skyImg.sprite = sky[1];
                }
            }
        }
    }

    public void Good()
    {
        if (manage.totalInfluence >= 0)
        {
            middleGroundImg.sprite = middleGround[0];
            if (manage.totalInfluence >= 3)
            {
                foreGroundImg.sprite = foreGround[0];
                if (manage.totalInfluence >= 5)
                {
                    skyImg.sprite = sky[0];
                }
            }
        }
        for(int i=0; i<copyFiles.Length; i++)
        {
            if(copyFiles[i].state==g && copyFiles[i].checkbox==1)
            {
                grassOBJ.SetActive(true);
                if(moreHouses)
                {
                    grassImg.sprite = grass[1];
                }
                else
                    grassImg.sprite = grass[0];
            }
            if (copyFiles[i].state == moreH && copyFiles[i].checkbox == 1)
            {
                morebuildingImg.sprite = morebuildings[0];
                moreHouses = true;
                if(isGrass)
                {
                    grassImg.sprite = grass[1];
                }
            }
            if(copyFiles[i].state == bird && copyFiles[i].checkbox == 1)
            {
                birdsOBJ.SetActive(true);
            }
            if (copyFiles[i].state == gl && copyFiles[i].checkbox == 1)
            {
                buildingImg.sprite = buildings[1];
            }

        }


    }


}
