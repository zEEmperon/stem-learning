using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public void Start()
    {
        transform.LeanMoveLocal(new Vector2(0, 0), 1.5f).setEaseInOutBack();
        //transform.LeanMoveLocal(new Vector2(0, 0), 1);
    }
}
