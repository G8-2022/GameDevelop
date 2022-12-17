using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    public bool useOffsetValue;

    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngel;
    public float minViewAngel;
    
    public bool invertY;

    

    // Start is called before the first frame update
    void Start()
    {

        if(!useOffsetValue)
            offset = target.position - transform.position;

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Get the X position of the mouse & rorate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //Get the Y position of the mouse & rorate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        if(invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        } else
        {
            pivot.Rotate(-vertical, 0, 0);
        }
        
        //Limit up/down camera rotation
        if(pivot.rotation.eulerAngles.x > maxViewAngel && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngel, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minViewAngel)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngel, 0, 0);
        }

        //Move the camera based on the current rotation of the target & the original offset
        float desireYAngle = target.eulerAngles.y;
        float desireXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desireXAngle, desireYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }

        transform.LookAt(target);
    }
}
