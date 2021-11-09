using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnakeBtn : EventTrigger
{
    private bool startDragging;


    private void Update() {

        if(startDragging){
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(touchPos.x, touchPos.y);
        }
        
    }


    public override void OnPointerDown(PointerEventData data)
    {
        startDragging = true;
    }
    public override void OnPointerUp(PointerEventData data)
    {
        startDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Snake")){
            GameManager.Instance.totalOfCandies++;
            Debug.Log("Weh  called.");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Snake")){
            GameManager.Instance.totalOfCandies--;
            Debug.Log("exit  called.");
        }
    }
}
