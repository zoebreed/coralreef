// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class player : MonoBehaviour
// {   
//     public Vector2 joystick;
//     public GameObject centerCamera;
//     public GameObject OVRcamera;
//     public float speed = 5;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

//         transform.eulerAngles = new Vector3(0, centerCamera.transform.localEulerAngles.y, 0 );
//         transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
//         transform.Translate(Vector3.right * speed * joystick.x * Time.deltaTime);
       
//        OVRCamera.transform.position = Vector3.Lerp(OVRCamera.transform.position, transform.position, 10f * Time.deltaTime);
//     }
// }
