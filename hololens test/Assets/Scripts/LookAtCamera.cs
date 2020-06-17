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
        Vector3 fwd = camera.transform.forward;

        fwd.y = transform.forward.y;
        transform.rotation = Quaternion.LookRotation(fwd);
    }
}
