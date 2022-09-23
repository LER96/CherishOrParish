using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePref;
    Drawing activeLine;

    private void Update()
    {
        if (IsMouseOnImage() == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                GameObject newLine = Instantiate(linePref);
                activeLine = newLine.GetComponent<Drawing>();
            }

            if (Input.GetMouseButtonUp(0))
            {
                activeLine = null;
            }

            if (activeLine != null)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                activeLine.UpdateLine(mousePos);
            }
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
}
