using UnityEngine;
using System.Collections;

public class TrackBuilder : MonoBehaviour
{

    [SerializeField]private GameObject[] tracks;
    [SerializeField]private Transform trackSpawnerPos;
    private float newPos;
    public static TrackBuilder trackBuilder;

    private float waitTime;
    private GameObject track;

    private void Start () 
    {
        trackBuilder = this;
        newPos = 20.0f;
        waitTime = 2.0f;
        Track();
    }

    private void Track()
    {
        track = Instantiate (tracks [Random.Range(0,tracks.Length)], trackSpawnerPos.position, Quaternion.identity) as GameObject;
        Destroy(track.gameObject, 8f);
        Vector3 temp = trackSpawnerPos.position;
        temp.y = 0;
        temp.x = 0;
        temp.z += 40;
        trackSpawnerPos.position = temp;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        Track();
    }
}