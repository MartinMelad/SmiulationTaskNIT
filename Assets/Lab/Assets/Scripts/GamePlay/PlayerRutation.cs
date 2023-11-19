using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRutaton : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTramsform;
    public float mousetSensteivity = 100f;
    float cameraVerticalRoutation = 0f;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    { 
        // get mouse direction
        float inputX = Input.GetAxis("Mouse X") * mousetSensteivity * Time.deltaTime;
        float inputY = Input.GetAxis("Mouse Y") * mousetSensteivity * Time.deltaTime;

        // routat player around x axis

        cameraVerticalRoutation -= inputY;
        cameraVerticalRoutation = Mathf.Clamp(cameraVerticalRoutation, -90, 90);
        transform.localEulerAngles = Vector3.right * cameraVerticalRoutation;

        // routat player around y axis
        playerTramsform.Rotate(Vector3.up * inputX);

    }
}
