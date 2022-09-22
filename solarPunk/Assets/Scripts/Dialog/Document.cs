using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Document", menuName ="Document")]
public class Document : ScriptableObject
{
    public string documentTitle;
    public string documentDescription;
    //0 = destructive, 1 = ecological  
    public int documentType;
    public int influence; 
}
