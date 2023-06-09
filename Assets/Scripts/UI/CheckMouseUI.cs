using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckMouseUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool isMouseOverUIElement = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOverUIElement = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOverUIElement = false;
    }

}
