using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Apple0 : EventTrigger
{
    // I am stuck in this level, what I do is lower the choices and not exceed the total score
   private bool startDragging;

   private void Start() {
       Debug.Log(GameManager.Instance.totalOfCandies);
   }


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
        if(other.gameObject.CompareTag("Red")){
            if(3 > GameManager.Instance.totalOfCandies){
                //3
                GameManager.Instance.totalOfCandies+=1;
               
            }else{
                GameManager.Instance.totalOfCandies-=1;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Red")){
            //1

            if(GameManager.Instance.totalOfCandies <= 3){
                
                GameManager.Instance.totalOfCandies-=1;
                //2
            }else {
                GameManager.Instance.totalOfCandies+=1;
            }  
        }
    }

}
