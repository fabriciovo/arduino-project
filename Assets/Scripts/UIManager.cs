using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject Ui;
}
