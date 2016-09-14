using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour 
{
    [SerializeField] private GameObject[] obstacle_prefabs;
    private int obstacle_index;
    private bool spawn;

    private void Start()
    {
        spawn = true;
    }

    void Update()
    {
        if (spawn)
        {
            StartCoroutine(SpawnObstacle());
        }
    }

    IEnumerator SpawnObstacle()
    {
        spawn = false;
        obstacle_index = Random.Range(0, obstacle_prefabs.Length);
        Instantiate(obstacle_prefabs[obstacle_index],obstacle_prefabs[obstacle_index].transform.localPosition,Quaternion.identity);
        yield return new WaitForSeconds(2f);
        spawn = true;
    }
   
}