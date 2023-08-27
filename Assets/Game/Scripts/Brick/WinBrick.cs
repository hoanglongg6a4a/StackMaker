using UnityEngine;

public class WinBrick : Brick
{
    [SerializeField] private Transform destination;
    [SerializeField] private ParticleSystem particleSystem1;
    [SerializeField] private GameObject openGO;
    [SerializeField] private GameObject closeGO;

    public Transform Destination { get => destination; set => destination = value; }

    public override void Handle()
    {
        particleSystem1.Play();
        openGO.SetActive(true);
        closeGO.SetActive(false);
    }
}
