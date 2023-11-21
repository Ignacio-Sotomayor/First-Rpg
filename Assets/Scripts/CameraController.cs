using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float Sensivility = 75f;
    public float LimitAngle = 25f;

    private Transform cameraTransform;
    private float AngleY;
    private float AngleX;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform.Find("Main Camera").GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
            
        var angles = transform.localEulerAngles;
        var cameraAngles = cameraTransform.localEulerAngles;

        var xAxis = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Sensivility;
        var yAxis = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Sensivility;

        AngleX = Mathf.Clamp(AngleX - yAxis, -LimitAngle, LimitAngle);
        AngleY = AngleY + xAxis;

        angles.y = AngleY;
        cameraAngles.x = AngleX;

        var localEuler = Quaternion.Euler(angles);
        var cameraEuler = Quaternion.Euler(cameraAngles);

        transform.localRotation = localEuler;
        cameraTransform.localRotation = cameraEuler;

        transform.localEulerAngles = angles;
        cameraTransform.localEulerAngles = cameraAngles;
    }
    
}
