using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    private Obstacle obstacleScript;
    private float timer;
    public float SpawnIntervel;
    public float decreaseInterval;
    public float minInterval;
    public float speedIncrement;
    public float speedLimiter;
    public Vector3[] spawnPosition;
    private void Start()
    {
        obstacleScript = obstacle.GetComponent<Obstacle>();
        obstacleScript.speed = 10;
        for(int i = 0; i < spawnPosition.Length; i++)
        {
            spawnPosition[i].z = transform.position.z;
            spawnPosition[i].y = transform.position.y;
        }
    }
    private void Update()
    {
        if(timer <= 0)
        {
            int index1 = Random.Range(0, 3);//max limit is exlusive because its int
            int index2 = Random.Range(0, 3);//for float max limit is inclusive
            Instantiate(obstacle,spawnPosition[index1],Quaternion.identity);
            if(index1 != index2)
            {
                Instantiate(obstacle, spawnPosition[index2], Quaternion.identity);
            }
            //if(SpawnIntervel > minInterval)
            //{
            //    SpawnIntervel -= decreaseInterval;
            //}
            timer = SpawnIntervel;
            if(obstacleScript.speed < speedLimiter)
            {
                obstacleScript.speed += speedIncrement;
            }
            Debug.Log("speed = " + obstacleScript.speed + "  spawn interval = " + SpawnIntervel);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
