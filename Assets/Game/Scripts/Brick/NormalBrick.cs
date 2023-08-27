public class NormalBrick : Brick
{
    public override void Handle()
    {
        if (meshRenderer.enabled == true)
        {
            meshRenderer.enabled = false;
        }
    }
}
