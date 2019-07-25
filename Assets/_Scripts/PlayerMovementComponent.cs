using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{

    //[SerializeField]
    //private int num = 2;

    //public float fl = 1.4f;

    //private int[] arr;

    //public char character = 'A';

    //public string str = "I am a string";


    // Start is called before the first frame update

    public float SprintSpeed, Walkspeed;
    private float CurrentSpeed;

    private Rigidbody RB;

    public Vector3 IP;

    public bool IsSprinting;
    void Start()
    { 
        RB = GetComponent<Rigidbody>();
    }
    
    public void DoMovement()
    {

        IP.x = Input.GetAxisRaw("Horizontal");
        IP.z = Input.GetAxisRaw("Vertical");

        //RB.AddForce(IP * Speed * Time.deltaTime);
        RB.velocity = new Vector3(IP.x * CurrentSpeed * Time.deltaTime,
                                  RB.velocity.y,
                                  IP.z * CurrentSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //1
        if(Input.GetKey(KeyCode.LeftShift))
        {
            CurrentSpeed = SprintSpeed;
        }
        else
        {
            CurrentSpeed = Walkspeed;
        }

        //Sprinting is set to true when we press the lef shift key
        IsSprinting = Input.GetKey(KeyCode.LeftShift);
        // Current speed changes to sprint or walk speed when sprinting is true or false
        CurrentSpeed = (IsSprinting == true) ? SprintSpeed : Walkspeed;

        DoMovement();



    }
}
