using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText;
    Color32 orange = new Color32(235, 167, 49, 255);
    Color32 white = new Color32(255, 255, 255, 255);

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = orange;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = white;
    }

}
