using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayFinalTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Du hast " + StaticTime.Time + " gebraucht.";
    }
}
