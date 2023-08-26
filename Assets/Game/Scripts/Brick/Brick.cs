using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected MeshRenderer meshRenderer;
    public virtual void DisableMesh()
    {
        Debug.Log("c� v�o");
        meshRenderer.enabled = false;
    }
}
