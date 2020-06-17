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

            SetButtonText("Stop animation");

        }
        else {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = initialPosition;
            animating = false;

            SetButtonText("Animate");
        }
    }

    public void FreakOut() {
        if (!animating) {
            initialPosition = transform.position;
            initialRotation = transform.rotation;

            GetComponent<Animator>().enabled = true;
            animating = true;

            SetButtonText("Stop animation");
        }
        else {
            GetComponent<Animator>().enabled = false;

            transform.position = initialPosition;
            transform.rotation = initialRotation;
            animating = false;

            SetButtonText("Animate");
        }
    }

    public void BlowUp() {
        if (!animating) {
            initialScale = transform.localScale;

            GetComponent<AnimateIncreaseScale>().enabled = true;
            animating = true;

            SetButtonText("Stop animation");
        }
        else {
            GetComponent<AnimateIncreaseScale>().enabled = false;

            transform.localScale = initialScale;
            animating = false;

            SetButtonText("Animate");
        }

    }

    private void SetButtonText(string s) {
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Text text = button.GetComponentInChildren<Text>();
        if (text != null) {
            text.text = s;
        }
    }
}

