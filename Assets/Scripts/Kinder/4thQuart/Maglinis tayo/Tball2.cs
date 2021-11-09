using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tball2 : MonoBehaviour
{

    Vector2 starPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [Range (0.5f, 1f)]
    public float throwForce = 0.7f;
  

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){

            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase){
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        touchTimeStart = Time.time;
                        starPos = Input.GetTouch(0).position;
                    }
                break;

                case TouchPhase.Ended:
                    touchTimeFinish = Time.time;

                    timeInterval = touchTimeFinish - touchTimeStart;

                    endPos = Input.GetTouch(0).position;

                    direction = starPos - endPos;

                    GetComponent<Rigidbody2D>().AddForce(-direction/timeInterval * throwForce);
                break;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Finish")){
            GameManager.Instance.totalOfCandies++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Finish")){
            GameManager.Instance.totalOfCandies--;
        }
    }

}
