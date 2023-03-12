using System.Collections.Generic;
using UnityEngine;

public class SwitchingController : MonoBehaviour
{
    public GameObject chalkboard1;
    public GameObject chalkboardShadow1;    
    
    public GameObject chalkboard2;
    public GameObject chalkboardShadow2;
    
    public float animationTime = 1.4f;
    public float shadowOffset = 35;
    
    public Vector2 chalkboardPosition = new Vector2(0, 50);

    void Start()
    {
        PutAwayAllObjects();
        MoveChalkboardFromOffRightToCenter(chalkboard1, chalkboardShadow1);
    }

    public void ClickPlay()
    {
        MoveChalkboardFromCenterToOffLeft(chalkboard1, chalkboardShadow1);
        MoveChalkboardFromOffRightToCenter(chalkboard2, chalkboardShadow2);
    }

    public void ClickBack()
    {
        
    }

    private void PutAwayAllObjects()
    {
        var objects = new List<GameObject>
        {
            chalkboard1, chalkboardShadow1,
            chalkboard2, chalkboardShadow2
        };

        foreach (var o in objects)
        {
            PlaceObjectOutsideOfTheScreen(o);
        }
    }

    private void PlaceObjectOutsideOfTheScreen(GameObject obj)
    {
        var outsideScreenOffset = 50;
        var newPosition = obj.transform.position;
        newPosition.x = outsideScreenOffset;
        obj.transform.position = newPosition;
    }

    private void MoveObject(GameObject obj, Vector2 destination)
    {
        obj.LeanMoveLocal(destination, animationTime).setEaseInOutBack();
    }

    private void MoveChalkboardFromOffRightToCenter(GameObject chalkboard, GameObject chalkboardShadow)
    {
        var shadowPosition = new Vector2(chalkboardPosition.x + shadowOffset, chalkboardPosition.y - shadowOffset);
        MoveObject(chalkboard, chalkboardPosition);
        MoveObject(chalkboardShadow, shadowPosition);
    }
    
    private void MoveChalkboardFromCenterToOffLeft(GameObject chalkboard, GameObject chalkboardShadow)
    {
        var oldChalkboardPosition = chalkboardPosition;
        var oldChalkboardShadowPosition = chalkboardShadow.transform.position;

        var xOffset = -10000;
        
        var newChalkboardPos = new Vector2(xOffset , oldChalkboardPosition.y);
        var newChalkboardShadowPos = new Vector2(xOffset, oldChalkboardShadowPosition.y);
        
        MoveObject(chalkboard, newChalkboardPos);
        MoveObject(chalkboardShadow, newChalkboardShadowPos);
    }
}
