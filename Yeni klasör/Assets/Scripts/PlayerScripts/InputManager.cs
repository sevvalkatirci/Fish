using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    [SerializeField] float smoothnes;// hassasiyet hızı

    float startX;
    float lastX;
    float distance;
    float moveValue;

    #endregion

    #region Monobehaviour Call Backs

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            lastX = Input.mousePosition.x;
            distance = lastX - startX;
            moveValue = (distance / Screen.width) * smoothnes;

            MovePlayer.Instance.Turn(moveValue);

            startX = lastX;
        }
    }
}

#endregion