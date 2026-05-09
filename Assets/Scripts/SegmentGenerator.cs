using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;
    public Transform player;

    [SerializeField] int zPos = 50;
    [SerializeField] int distanceToSpawn = 300;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (zPos < player.position.z + distanceToSpawn)
        {
            SpawnSegment();
        }
    }

    void SpawnSegment()
    {
        int segmentNum = Random.Range(0, segment.Length);
        GameObject newSegment = Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        if (newSegment.GetComponent<SegmentLife>() != null)
        {
            newSegment.GetComponent<SegmentLife>().enabled = true;
        }
        zPos += 50;
    }
}