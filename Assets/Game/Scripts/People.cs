using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    private Stack<Brick> stackBrick;
    [SerializeField] private GameObject brickPrefab;

    private void Start()
    {
        stackBrick = new();
        CheckGrounded();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 2f);
    }
    private void CheckGrounded()
    {
        Debug.Log("?ã vào 0");
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 2f, Color.red);
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider != null)
            {
                Debug.Log("?ã vào 1");
                Brick brick = hit.collider.GetComponent<Brick>();
                if (brick is NormalBrick)
                {
                    Debug.Log("?ã vào 2");
                    AddBrick(brick);
                }
            }
        }
    }
    public void AddBrick(Brick brick)
    {
        if (brick != null)
        {
            GameObject Prefab = Instantiate(brickPrefab);
            Prefab.transform.position = transform.position;
            Prefab.transform.SetParent(transform);
            stackBrick.Push(brick);
            brick.DisableMesh();
        }
    }
    public void RemoveBrick()
    {
        stackBrick.Pop();
    }
    public void PlusThang()
    {

    }
}
