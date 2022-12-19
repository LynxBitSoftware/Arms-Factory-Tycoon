using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flagSelector : MonoBehaviour
{
    public Sprite[] images;
    public Image imageContainer;

    public void SetImage(int index)
    {
        if (images.Length >= index)
        {
            imageContainer.sprite = images[index];
        }
        else
        {
            Debug.LogError("Invalid image index: " + index);
        }
    }
}
