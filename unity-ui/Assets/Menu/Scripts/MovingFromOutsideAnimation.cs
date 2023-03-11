using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFromOutsideAnimation : MonoBehaviour
{
    public Transform chalkboard;
    public Transform shadow;
    public float animationTime = 1.4f;
    void Start()
    {
        var offset = 35;
        var chalkboardX = 0;
        var chalkboardY = 50;
        chalkboard.LeanMoveLocal(new Vector2(chalkboardX, chalkboardY), animationTime).setEaseInOutBack();
        shadow.LeanMoveLocal(new Vector2(chalkboardX + offset, chalkboardY - offset), animationTime).setEaseInOutBack();
    }
}
