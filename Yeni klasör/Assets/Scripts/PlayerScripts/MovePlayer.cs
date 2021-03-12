using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    #region Variables

    public static MovePlayer Instance;

    [SerializeField] float forwardSpeed;
    [SerializeField] float maxLimit;
    [SerializeField] float minLimit;
    public Animator playerAnim;
  

    #endregion

    #region Monobehaviour Callbacks

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
       
        Running();
    }
    #endregion

    #region Other Methods
    void Running()
    {
        transform.Translate(transform.forward * forwardSpeed * Time.deltaTime, Space.World);
    }

    public void Turn(float movementValue)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + movementValue, minLimit, maxLimit), transform.position.y, transform.position.z);
    }
    #endregion
}
