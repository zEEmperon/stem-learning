using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectsOutsideScreen : MonoBehaviour
{
    public List<GameObject> objectsToPlace;

    void Start()
    {
        Camera camera = Camera.main;
        
        float screenWidth = Screen.width;
        
        Vector3 rightEdge = camera.ScreenToWorldPoint(new Vector3(screenWidth, 0, camera.nearClipPlane));
        


        foreach (var o in objectsToPlace)
        {
            float xOffset = o.transform.localScale.x / 2.0f; 
            Vector3 newPosition = o.transform.position;
            newPosition.x = rightEdge.x + xOffset;
            o.transform.position = newPosition;
        }
    }
}
