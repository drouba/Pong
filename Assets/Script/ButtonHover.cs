using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText;
    private Color32 white = new Color32(255, 255, 255, 255);

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = RandomColor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = white;
    }

    private Color32 RandomColor()
    {
        return new Color32(
        (byte)UnityEngine.Random.Range(0, 255), //Red
        (byte)UnityEngine.Random.Range(0, 255), //Green
        (byte)UnityEngine.Random.Range(0, 255), //Blue
        255 //Alpha (transparency)
         );
    }
}
