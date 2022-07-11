using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class loadToCanvas : MonoBehaviour
{
    public Image oldimg;
    public Sprite[] newimg;
    public Dropdown mvDD;

    public void ImageChange(Dropdown myDD)
    {
        oldimg.sprite = newimg[myDD.value];
    }
}