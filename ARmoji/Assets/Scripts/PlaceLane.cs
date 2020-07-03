using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLane : MonoBehaviour
{

    private static bool placing = true;


    // Update is called once per frame
    void Update() {
        // Bit shift the index of the layer (10) to get a bit mask
        int layerMask = 1 << LayerMask.NameToLayer("floor");

        // Does the ray intersect any objects on layer 10?
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);

            //Debug.Log($"Hit in position\t({hit.point.x}, {hit.point.y}, {hit.point.z})");
            if (placing) {
				InstantiateLevel.current.transform.position = hit.point;
			}
		}
        else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
        }
    }

    public static void Place(){
        placing = false;

        InstantiateLevel.current.GetComponent<BoxCollider>().enabled = false;
        InstantiateLevel.current.GetComponent<LookAtCamera>().enabled = false;

        InstantiateLevel.current.GetComponent<CanvasGroup>().alpha = 1;

        InstantiateLevel.EnablePinPhysics();
	}
}
