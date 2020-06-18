using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ShowDescription : MonoBehaviour
{
    private Collider lastHit = null;
    private Dictionary<Collider, GameObject> _name_to_canvas;

    public Test[] testArray;

    [Serializable]
    public struct Test {
        public Collider collider;
        public GameObject target;
    }

    // Start is called before the first frame update
    void Start()
    {
        _name_to_canvas = new Dictionary<Collider, GameObject> { { testArray[0].collider, testArray[0].target },
                                                              { testArray[1].collider, testArray[1].target },
                                                              { testArray[2].collider, testArray[2].target },
                                                              { testArray[3].collider, testArray[3].target } };
    }

    // Update is called once per frame
    void Update() {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << LayerMask.NameToLayer("emojis");

        // Does the ray intersect any objects on layer 8?
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);

            // If it's the same emoji we've last looked at, 
            if (hit.collider != lastHit) {

                // If we've never looked at an emoji before, lastHit will be null, dict key must not be null
                if (lastHit != null) {
                    // Hide the previous description
                    if (_name_to_canvas.TryGetValue(lastHit, out GameObject oldCanvas) ){
                        oldCanvas.SetActive(false);
					}
                }

                // Show the current description
                if (_name_to_canvas.TryGetValue(hit.collider, out GameObject newCanvas)){
                    newCanvas.SetActive(true);
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
