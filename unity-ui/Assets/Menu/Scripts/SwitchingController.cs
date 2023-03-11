using System.Collections.Generic;
using UnityEngine;

public class SwitchingController : MonoBehaviour
{
    public GameObject chalkboard;
    public GameObject chalkboardShadow;
    
    public float animationTime = 1.4f;
    public float outsideScreenPosition = 50;
    void Start()
    {
        PutAwayAllObjects();
        
        var offset = 35;
        var chalkboardX = 0;
        var chalkboardY = 50;
        chalkboard.LeanMoveLocal(new Vector2(chalkboardX, chalkboardY), animationTime).setEaseInOutBack();
        chalkboardShadow.LeanMoveLocal(new Vector2(chalkboardX + offset, chalkboardY - offset), animationTime).setEaseInOutBack();
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
        newPosition.x = outsideScreenPosition;
        obj.transform.position = newPosition;
    }

    private void MoveFromOut(GameObject obj)
    {
        
    }

    private void MoveToOut(GameObject obj)
    {
        
    }
}
