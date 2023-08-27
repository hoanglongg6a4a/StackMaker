using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected MeshRenderer meshRenderer;
    private bool isUse = false;

    public bool IsUse { get => isUse; set => isUse = value; }

    public virtual void Handle()
    {
        Debug.Log("có vào");
    }
}
