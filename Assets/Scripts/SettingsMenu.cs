using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public static float sensitivity = 0.50f;
    public void SetSensitivity(float pSensitivity)
    {
        sensitivity = pSensitivity + 0.5f;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
