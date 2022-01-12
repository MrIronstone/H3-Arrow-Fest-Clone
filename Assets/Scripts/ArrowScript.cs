using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ArrowScript : MonoBehaviour
{
    public int initialArrowCount = 1;
    private void Start()
    {
        GameManager.instance.SetArrowCount(initialArrowCount);
    }
}
