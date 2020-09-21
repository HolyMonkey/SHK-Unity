using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;

    public abstract void Close();
}
