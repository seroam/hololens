using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour {
    private bool animating = false;

    Vector3 initialPosition;
    Quaternion initialRotation;
    Vector3 initialScale;


    public void Drop() {
        if (!animating) {
            initialPosition = transform.position;
            GetComponent<Rigidbody>().isKinematic = false;
            animating = true;

        }
        else {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = initialPosition;
            animating = false;
        }
    }

    public void FreakOut() {
        if (!animating) {
            initialPosition = transform.position;
            initialRotation = transform.rotation;

            GetComponent<Animator>().enabled = true;
            animating = true;
        }
        else {
            GetComponent<Animator>().enabled = false;

            transform.position = initialPosition;
            transform.rotation = initialRotation;
            animating = false;
        }
    }

    public void Inflate() {
        if (!animating) {
            initialScale = transform.localScale;

            GetComponent<Inflate>().enabled = true;
            animating = true;
        }
        else {
            GetComponent<Inflate>().enabled = false;

            transform.localScale = initialScale;
            animating = false;
        }

    }

    public void Unknown(){
        Debug.Log("Unknown called.");
	}
}

