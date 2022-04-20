using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField]private TMP_Text textMesh;
    // Start is called before the first frame update
    public void changeText(string value)
    {
        textMesh.text = value;
    }
}
