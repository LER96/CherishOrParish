using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Document", menuName ="Document")]
public class Document : ScriptableObject
{
    public string date;
    public string documentTitle;
    public string documentStart;
    public string documentmMiddle;
    public string documentEnd;

    public float cost;
    public float profit;

    public int influence;

    //if we did V/X;
    public int checkbox;
}
