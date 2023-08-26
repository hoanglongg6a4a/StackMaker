using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private People peoplePrefab;
    [SerializeField] private Vector3 SpawnOffset;
    [SerializeField] private Vector3 moveDistance;
    private Vector2 mouseStartPosition;
    private People people;
    private void Awake()
    {
        //SpawnPeople();
    }
    private void SpawnPeople()
    {
        people = Instantiate(peoplePrefab, SpawnOffset, Quaternion.identity);
    }
    private void SwipeControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 mouseEndPosition = Input.mousePosition;
            float swipeDistanceX = mouseEndPosition.x - mouseStartPosition.x;
            float swipeDistanceY = mouseEndPosition.y - mouseStartPosition.y;

            if (swipeDistanceY > 0 && Mathf.Abs(swipeDistanceY) > Mathf.Abs(swipeDistanceX))
            {
                Debug.Log("Lên trên");
                peoplePrefab.transform.position -= moveDistance;
            }
            else if (swipeDistanceY < 0 && Mathf.Abs(swipeDistanceY) > Mathf.Abs(swipeDistanceX))
            {
                Debug.Log("Xu?ng d??i");
            }
            else if (swipeDistanceX < 0 && Mathf.Abs(swipeDistanceY) < Mathf.Abs(swipeDistanceX))
            {
                Debug.Log("Sang trái");
            }
            else if (swipeDistanceX > 0 && Mathf.Abs(swipeDistanceY) < Mathf.Abs(swipeDistanceX))
            {
                Debug.Log("Sang ph?i");
            }
        }
    }
    private void Update()
    {
        SwipeControl();
    }

}
