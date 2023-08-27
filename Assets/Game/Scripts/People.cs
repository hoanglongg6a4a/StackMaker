using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    private List<GameObject> listBrick;
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private Transform BrickParent;
    [SerializeField] private GameObject people;
    [SerializeField] private Animator animator;
    private bool isMove = false;
    private bool checkRay;
    private bool isWin = false;
    private bool isUseDirect = false;
    private Vector3 destination;
    private Vector3 moveDirect;

    private void Start()
    {
        listBrick = new();
        CheckGrounded();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 2f);
    }
    private void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider != null)
            {
                Brick brick = hit.collider.GetComponent<Brick>();
                if (brick is NormalBrick && !brick.IsUse)
                {
                    NormalBrick normalBrick = brick as NormalBrick;
                    AddBrick(normalBrick);
                    normalBrick.IsUse = true;
                }
                else if (brick is SliceBrick && !brick.IsUse)
                {
                    brick.Handle();
                    brick.IsUse = true;
                    RemoveBrick();
                }
                else if (brick is WinBrick)
                {
                    brick.Handle();
                    WinBrick winBrick = brick as WinBrick;
                    destination = winBrick.Destination.position;
                    Move();
                    isWin = true;
                    for (int i = 0; i < listBrick.Count; i++)
                    {
                        Destroy(listBrick[i].gameObject);
                        ChangeAnime(2);
                    }
                }
                else if (brick is DirectBrick && !isUseDirect)
                {
                    isUseDirect = true;
                    DirectBrick directBrick = brick as DirectBrick;
                    directBrick.Handle();
                    Vector3 newDirect = directBrick.CheckDirection(moveDirect);
                    Debug.Log(newDirect);
                    MovePeople(newDirect);
                }
            }
        }
    }
    public void AddBrick(Brick brick)
    {
        if (brick != null)
        {
            GameObject Prefab = Instantiate(brickPrefab, listBrick.Count > 0 ? listBrick[listBrick.Count - 1].transform.position + new Vector3(0, 0.2f, 0) : BrickParent.position, brickPrefab.transform.rotation);
            listBrick.Add(Prefab);
            Prefab.transform.SetParent(BrickParent);
            people.transform.position += new Vector3(0, 0.2f, 0);
            animator.SetInteger("state", 1);
            brick.Handle();
        }
    }
    public void ChangeAnime(int i)
    {
        animator.SetInteger("state", i);
    }
    public void MovePeople(Vector3 distance)
    {
        if (isMove || isWin) return;
        isMove = true;
        moveDirect = distance;
        Vector3 NewPosition = transform.position;
        bool canMove = true;
        while (canMove)
        {
            Ray ray = new Ray(NewPosition + distance, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider != null)
                {
                    Brick brick = hit.collider.GetComponent<Brick>();
                    if (brick != null)
                    {
                        NewPosition += distance;
                    }
                }
            }
            else
            {
                checkRay = true;
                destination = NewPosition;
                canMove = false;
            }
        }
    }
    public void Move()
    {
        ChangeAnime(1);
        var step = 10f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
        if (transform.position == destination)
        {
            checkRay = false;
            isMove = false;
            isUseDirect = false;
            if (isWin)
            {
                ChangeAnime(2);
            }
            else
            {
                ChangeAnime(0);
            }

        }
    }
    public void CheckRay()
    {
        if (checkRay)
        {
            Move();
            CheckGrounded();
        }
    }

    public void RemoveBrick()
    {
        if (listBrick.Count > 0 && isMove == true)
        {
            Debug.Log("có vào");
            people.transform.position -= new Vector3(0, 0.2f, 0);
            Destroy(listBrick[listBrick.Count - 1]);
            listBrick.RemoveAt(listBrick.Count - 1);
        }
    }
    private void Update()
    {
        CheckRay();
    }
}
