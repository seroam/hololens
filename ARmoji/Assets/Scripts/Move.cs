using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.velocity = new Vector3(0, 0, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if ( _rigidbody.velocity.magnitude < 0.1 ){
            _rigidbody.velocity = new Vector3(0, 0, 0);
		}
    }
}
