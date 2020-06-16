using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        /*var myTransform = transform;
        myTransform.LookAt(camera.transform);
        transform.rotation = Quaternion.Euler(transform.rotation.x, myTransform.rotation.y, transform.rotation.z);*/

        transform.LookAt(new Vector3(0, camera.transform.position.y, 0));
    }
}
