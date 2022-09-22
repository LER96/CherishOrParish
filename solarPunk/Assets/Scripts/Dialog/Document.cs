using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Document", menuName ="Document")]
public class Document : ScriptableObject
{
    [SerializeField] string documentTitle;
    [SerializeField] string documentDescription; 
}
