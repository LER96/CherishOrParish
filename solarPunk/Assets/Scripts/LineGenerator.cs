using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineGenerator : MonoBehaviour
{
    //public GameObject linePref;
    public GameObject linePrefab;
    [SerializeField] public GameObject gameManager;
    [SerializeField] List<GameObject> signature;
    GameManager man;
    Drawing activeLine;
    public bool hancock;

    Drawing line;

    private void Start()
    {
        gameManager= GameObject.FindGameObjectWithTag("Manager");
        //man = linePref.GetComponent<GameManager>();
        line = GameObject.FindGameObjectWithTag("Line").GetComponent<Drawing>();
    }

    private void Update()
    {
        man = gameManager.GetComponent<GameManager>();
        if (man.candraw)
        {
            if (IsMouseOnImage() == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject newLine = Instantiate(linePrefab);
                    signature.Add(newLine);
                    activeLine = newLine.GetComponent<Drawing>();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    activeLine = null;
                    hancock = true;
                }

                if (activeLine != null)
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    activeLine.UpdateLine(mousePos);
                }
            }
        }
        else if(man.candraw==false)
        {
            ResetLine();
        }
    }

    public bool IsMouseOnImage()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public bool IsMouseOverUi()
    {
        PointerEventData pointErevent = new PointerEventData(EventSystem.current);
        pointErevent.position = Input.mousePosition;
        List<RaycastResult> raycastResult = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointErevent, raycastResult);
        for (int i = 0; i < raycastResult.Count; i++)
        {
            if (raycastResult[i].gameObject.GetComponent<UiClickthrough>() != null)
            {
                raycastResult.RemoveAt(i);
                i--;
            }
        }

        return raycastResult.Count > 0;
    }

    public void ResetLine()
    {
        Debug.Log("erase");
        for(int i=0; i<signature.Count;i++)
        {
            GameObject.Destroy(signature[i]);
            signature.Remove(signature[i]);
        }
        //line.lineRenderer.positionCount = 0;
    }
}
