using System.Collections.Generic;
using UnityEngine;

public class SwitchingController : MonoBehaviour
{
    public GameObject chalkboard1;
    public GameObject chalkboardShadow1;    
    
    public GameObject chalkboard2;
    public GameObject chalkboardShadow2;
    
    public float animationTime = 2f;
    public float shadowOffset = 35;
    
    public Vector2 chalkboardPosition = new Vector2(0, 50);

    private Vector2 _shadowPosition;
    private float _xOffset = 10000;

    void Start()
    {
        _shadowPosition = new Vector2(chalkboardPosition.x + shadowOffset, chalkboardPosition.y - shadowOffset);
        
        PutAwayAllObjects();
        MoveChalkboardToCenter(chalkboard1, chalkboardShadow1);
    }

    public void ClickPlay()
    {
        MoveChalkboardOutTheCenter(chalkboard1, chalkboardShadow1, -_xOffset);
        MoveChalkboardToCenter(chalkboard2, chalkboardShadow2);
    }

    public void ClickBack()
    {
        MoveChalkboardOutTheCenter(chalkboard2, chalkboardShadow2, _xOffset);
        MoveChalkboardToCenter(chalkboard1, chalkboardShadow1);
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

    private void MoveChalkboardToCenter(GameObject chalkboard, GameObject chalkboardShadow)
    {
        MoveObject(chalkboard, chalkboardPosition);
        MoveObject(chalkboardShadow, _shadowPosition);
    }

    private void MoveChalkboardOutTheCenter(GameObject chalkboard, GameObject chalkboardShadow, float xOffset)
    {
        var oldChalkboardPosition = chalkboardPosition;
        var oldChalkboardShadowPosition = chalkboardShadow.transform.position;

        var newChalkboardPos = new Vector2(xOffset , oldChalkboardPosition.y);
        var newChalkboardShadowPos = new Vector2(xOffset, oldChalkboardShadowPosition.y);
        
        MoveObject(chalkboard, newChalkboardPos);
        MoveObject(chalkboardShadow, newChalkboardShadowPos);
    }
}
