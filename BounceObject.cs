using UnityEngine;

public class BounceObject : MonoBehaviour
{
    public float bounceAmplitude = 1f;
    public float bounceFrequency = 1f;

    [SerializeField]
    private Direction direction;

    private Vector3 startPosition;
    private Transform transformCache;

    private Vector3 directionVector;

    private enum Direction
    {
        Vertical,
        Horizontal,
    }

    void Start()
    {
        transformCache = transform;
        startPosition = transformCache.position;
    }

    void Update()
    {
        directionVector = direction switch
        {
            Direction.Horizontal => transformCache.right,
            Direction.Vertical => transformCache.up,
            _ => Vector3.up,
        };
        transformCache.position = startPosition + bounceAmplitude * Mathf.Sin(bounceFrequency * Time.time) * directionVector;
    }
}
