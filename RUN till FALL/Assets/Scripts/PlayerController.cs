using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float UnitDistance = 5;
    public float speed;
    public float MaxUnitDistance;
    public float MinUnitDistance;
    private Vector3 targetPos;
    public PauseMenuManager pm;
    private void Start()
    {
        targetPos = transform.position;
    }
    private void Update()
    {
        bool leftDirection = gameObject.GetComponent<Swipe>().SwipeLeft;
        bool rightDirection = gameObject.GetComponent<Swipe>().SwipeRight;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (  ((rightDirection) || Input.GetKey(KeyCode.D)) && (transform.position.x < MaxUnitDistance) )
        {
            targetPos = new Vector3(transform.position.x + UnitDistance, transform.position.y, transform.position.z);
        }

        else if (((leftDirection) || Input.GetKey(KeyCode.A)) && (transform.position.x > MinUnitDistance))
        {
            targetPos = new Vector3(transform.position.x - UnitDistance, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pm.Pause();
        }
    }

}
