using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectsOutsideScreen : MonoBehaviour
{
    public List<GameObject> objectsToPlace;

    void Start()
    {
        foreach (var o in objectsToPlace)
        {
            Vector3 newPosition = o.transform.position;
            newPosition.x = 50;
            o.transform.position = newPosition;
        }
    }
}
