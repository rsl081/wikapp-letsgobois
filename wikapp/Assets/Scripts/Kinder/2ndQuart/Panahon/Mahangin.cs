using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mahangin : EventTrigger
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
        if(other.gameObject.CompareTag("Mahangin")){
            GameManager.Instance.totalOfCandies++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Mahangin")){
            GameManager.Instance.totalOfCandies--;
        }
    }
}
