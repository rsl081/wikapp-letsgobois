using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDragAndDrop : MonoBehaviour
{
    public delegate void DragEndedDelegate(BaseDragAndDrop draggableOject);
    public DragEndedDelegate dragEndedCallback;
    private bool isDragged = false;
    public static bool locked;

    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private void Start() {
        locked = false;
           //remove !locked
        if(Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase){
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        isDragged = true;
                        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        spriteDragStartPosition = transform.localPosition;
                    }
                break;

                case TouchPhase.Moved:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)){
                        if(isDragged){
                            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);

                        }
                    }
                break;

                case TouchPhase.Ended:
                    isDragged = false;
                    dragEndedCallback(this);
                break;

            }
        }
    }
    private void OnMouseDown() {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag() {
        if(isDragged){
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);

        }
    }

    private void OnMouseUp() {
        isDragged = false;
        dragEndedCallback(this);
    }
//      bool HasMouseMoved()
//      { 
//          return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
//      }
}
