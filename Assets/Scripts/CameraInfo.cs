using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraInfo : MonoBehaviour
{
    public TextMeshProUGUI cameraText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraText.text = "Position: " + Camera.main.transform.position.ToString() + "\n Rotation: " + Camera.main.transform.rotation.eulerAngles.ToString();
    }
}
