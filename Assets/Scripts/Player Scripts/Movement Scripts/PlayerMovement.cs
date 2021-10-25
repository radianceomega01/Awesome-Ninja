using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed;
    Rigidbody myBody;
    float turnSmoothTime;
    float turnSmoothVelocity;
    public Transform cam;
    Joystick joyStick;
    Animator anim;
    static string PLAYER_RUN = "Run";
    // Start is called before the first frame update
    void Awake()
    {
        joyStick = GameObject.Find("Joystick").GetComponent<Joystick>();
        speed = 1f;
        anim = GetComponent<Animator>();
        turnSmoothTime = 0.1f;
        myBody = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float joyHorizontal = joyStick.Horizontal;
        float joyVertical = joyStick.Vertical;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 joyDirection = new Vector3(joyHorizontal, 0, joyVertical).normalized;

        if (direction.magnitude >= 0.1f || joyDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0)*Vector3.forward;
            myBody.position += moveDir.normalized * speed * Time.deltaTime;
            anim.SetBool(PLAYER_RUN, true);
        }
        else {
            anim.SetBool(PLAYER_RUN, false);
        }
    }
}
