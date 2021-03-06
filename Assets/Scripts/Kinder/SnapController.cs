using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<BaseDragAndDrop> draggableObjects;
    public float snapRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(BaseDragAndDrop draggable in draggableObjects) {
            draggable.dragEndedCallback = OnDragEnded;
        }
        GameManager.Instance.totalScore = draggableObjects.Count;
    }

    private void OnDragEnded(BaseDragAndDrop draggable) {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints) {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if(closestSnapPoint == null || currentDistance < closestDistance){
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if(closestSnapPoint != null && closestDistance <= snapRange){
            draggable.transform.localPosition = closestSnapPoint.localPosition;
        }
    }



    
}
