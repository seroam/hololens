using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDescription : MonoBehaviour
{
    private Collider lastHit = null;
    private Dictionary<Collider, Canvas> _name_to_canvas;
    
    // Start is called before the first frame update
    void Start()
    {
         _name_to_canvas = new Dictionary<Collider, Canvas> { { GameObject.Find("Smiling_Face_With_Sunglasses").GetComponent<Collider>(), GameObject.Find("info_glasses").GetComponent<Canvas>() },
                                                              { GameObject.Find("Rolling_On_The_Floor_Laughing").GetComponent<Collider>(), GameObject.Find("info_rofl").GetComponent<Canvas>() }};
    }

    // Update is called once per frame
    void Update() {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << LayerMask.NameToLayer("emojis");

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);

            // If it's the same emoji we've last looked at, 
            if (hit.collider != lastHit) {
                Canvas canvas;

                // If we've never looked at an emoji before, lastHit will be null, Dict key must not be null
                if (lastHit != null) {
                    // Hide the previous description
                    if (_name_to_canvas.TryGetValue(lastHit, out canvas) ){
                        canvas.enabled = false;
					}
                }

                // Show the current description
                if (_name_to_canvas.TryGetValue(hit.collider, out canvas)){
                    canvas.enabled = true;
				}
                
                // Update the last hit
                lastHit = hit.collider;
            }
        }
        else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue);
        }
    }
}
