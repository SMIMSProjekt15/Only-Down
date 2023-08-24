using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JewelCounter : MonoBehaviour
{
    public int jewelCount = 0; 

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = jewelCount.ToString();
    }
}
