using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private Interactable _interactable = null;

    private Camera _camera;

    private Rigidbody _rigidbody;

    public float Speed = 10;

    private float ScaledSpeed { get { return InstantiateLevel.current.transform.localScale.x * Speed; } }

    private bool running = false;

	void Start()
    {

        _camera = Camera.main;
        _rigidbody = GetComponentInChildren<Rigidbody>();
        _interactable = GetComponent<Interactable>();


        if ( _interactable == null ||_camera == null || _rigidbody == null){
            Debug.LogError($"_interactable={_interactable}\n_camera={_camera}\n_rigidbody={_rigidbody}");
            return;
		}

        if (Speed == 0){
            Debug.LogWarning("Speed set to 0, ball will not move.");
            return;
		}

        _interactable.OnClick.AddListener(() => {
            Launch();
        });
    }


    private void Launch(){

        Vector3 cameraDirection = _camera.transform.forward;

        _rigidbody.velocity = new Vector3(cameraDirection.x * ScaledSpeed, 0, cameraDirection.z * ScaledSpeed);
        running = true;

    }

    public void Update(){
        if (running){
            if (_rigidbody.velocity.magnitude < 0.1) {
                _rigidbody.velocity = new Vector3(0, 0, 0);
                running = false;
            }
        }
	}

    private void Reset(){
        var root = transform.parent;
	}
}
