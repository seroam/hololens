using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Collider lastHit = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << LayerMask.NameToLayer("emoji_grin");


        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
            if (hit.collider != lastHit) {
                if (lastHit != null) {
                    lastHit.transform.GetComponent<ShowMenu>().Toggle(lastHit, false);
                }

                hit.transform.GetComponent<ShowMenu>().Toggle(hit.collider, true);
                lastHit = hit.collider;
            }

            Debug.Log("Did Hit");
            if (Input.anyKeyDown){
                Debug.Log("Key down");
			}
            Debug.Log(hit);
        }
        else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }
    }
}
