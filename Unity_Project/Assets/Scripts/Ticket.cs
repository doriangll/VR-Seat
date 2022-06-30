using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                if (hit.collider != null){
                    Color redColor = new Color(1f,0f,0f,1f);
                    Color greenColor = new Color(0f,1f,0f,1f);
                    Color yourColor = new Color(1f,0.6f,0f,1f);

                    if (hit.collider.GetComponent<MeshRenderer>().material.color == redColor){
                        hit.collider.GetComponent<MeshRenderer>().material.color = redColor;
                    } else if (hit.collider.GetComponent<MeshRenderer>().material.color == greenColor){
                        GameObject parent = hit.collider.gameObject.transform.parent.gameObject;
                        foreach (Transform child in parent.transform){
                            child.gameObject.GetComponent<Renderer>().material.color = yourColor;
                        }
                    } else if (hit.collider.GetComponent<MeshRenderer>().material.color == yourColor){
                        GameObject parent = hit.collider.gameObject.transform.parent.gameObject;
                        foreach (Transform child in parent.transform){
                            child.gameObject.GetComponent<Renderer>().material.color = greenColor;
                        }
                    }
                }
                Debug.Log(Physics.Raycast(ray, out hit));
            }
        }
    }
}
