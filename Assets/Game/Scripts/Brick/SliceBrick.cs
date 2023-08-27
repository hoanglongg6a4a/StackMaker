using UnityEngine;

public class SliceBrick : Brick
{
    [SerializeField] private GameObject brickSlice;
    // Start is called before the first frame update
    public override void Handle()
    {
        brickSlice.gameObject.SetActive(true);
    }
}
