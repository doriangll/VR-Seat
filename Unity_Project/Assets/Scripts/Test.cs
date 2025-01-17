using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Camera Camera;
    protected Plane Plane;

    private void Awake()
    {
        if (Camera == null){
            Camera = Camera.main;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount >= 1){
            Plane.SetNormalAndPosition(transform.up, transform.position);
        }

        var Delta1 = Vector3.zero;
        var Delta2 = Vector3.zero;

        if (Input.touchCount >= 1) {
            Delta1 = PlanePositionDelta(Input.GetTouch(0));
            if (Input.GetTouch(0).phase == TouchPhase.Moved){
                Camera.transform.Translate(Delta1, Space.World);
            }
        }
    }

    protected Vector3 PlanePositionDelta(Touch touch){
        if (touch.phase != TouchPhase.Moved){
            return Vector3.zero;
        }

        var rayBefore = Camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = Camera.ScreenPointToRay(touch.position);
        if (Plane.Raycast(rayBefore, out var enterBefore) && Plane.Raycast(rayNow, out var enterNow)){
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);
        }
        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos){

        var rayNow = Camera.ScreenPointToRay(screenPos);
        if (Plane.Raycast(rayNow, out var enterNow)){
            return rayNow.GetPoint(enterNow);
        }
        return Vector3.zero;
    }
}
