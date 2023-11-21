using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    public float Jump;

    private float HorizontalInput;
    private float VerticalInput;
    private bool Grounded;

    private Transform posicion;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        posicion = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    void Mover()
    {
        HorizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        VerticalInput = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            body.AddForce(Vector3.up * (Jump * Jump * Jump / 5));
        }

        posicion.Translate(HorizontalInput, 0, VerticalInput);
    }
    
    void FixedUpdate()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;

        if (Physics.Raycast(posicion.position, posicion.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
    }
}
