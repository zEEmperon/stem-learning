using System.Collections.Generic;
using UnityEngine;

public class SwitchingController : MonoBehaviour
{
    public GameObject chalkboard;
    public GameObject chalkboardShadow;
    
    public float animationTime = 1.4f;
    public float outsideScreenOffset = 50;
    public float shadowOffset = 35;
    
    public Vector2 chalkboardPosition = new Vector2(0, 50);

    void Start()
    {
        PutAwayAllObjects();

        var shadowPosition = new Vector2(chalkboardPosition.x + shadowOffset, chalkboardPosition.y - shadowOffset);
        
        MoveObject(chalkboard, chalkboardPosition);
        MoveObject(chalkboardShadow, shadowPosition);
    }

    public void ClickPlay()
    {
        
    }

    public void ClickBack()
    {
        
    }

    private void PutAwayAllObjects()
    {
        var objects = new List<GameObject>
        {
            chalkboard, chalkboardShadow
        };

        foreach (var o in objects)
        {
            PlaceObjectOutsideOfTheScreen(o);
        }
    }

    private void PlaceObjectOutsideOfTheScreen(GameObject obj)
    {
        var newPosition = obj.transform.position;
        newPosition.x = outsideScreenOffset;
        obj.transform.position = newPosition;
    }

    private void MoveObject(GameObject obj, Vector2 destination)
    {
        obj.LeanMoveLocal(destination, animationTime).setEaseInOutBack();
    }
}
