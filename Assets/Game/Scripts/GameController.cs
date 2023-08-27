using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private People peoplePrefab;
    [SerializeField] private float moveDistance = 1f;
    private Vector2 mouseStartPosition;
    private void Awake()
    {
        //SpawnPeople();
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
                peoplePrefab.MovePeople(new Vector3(moveDistance, 0f, 0f));
            }
            else if (swipeDistanceY < 0 && Mathf.Abs(swipeDistanceY) > Mathf.Abs(swipeDistanceX))
            {
                peoplePrefab.MovePeople(new Vector3(-moveDistance, 0f, 0f));
            }
            else if (swipeDistanceX < 0 && Mathf.Abs(swipeDistanceY) < Mathf.Abs(swipeDistanceX))
            {
                peoplePrefab.MovePeople(new Vector3(0f, 0f, moveDistance));
            }
            else if (swipeDistanceX > 0 && Mathf.Abs(swipeDistanceY) < Mathf.Abs(swipeDistanceX))
            {
                peoplePrefab.MovePeople(new Vector3(0f, 0f, -moveDistance));
            }
        }
    }
    private void Update()
    {
        SwipeControl();
    }

}
