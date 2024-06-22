using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public HealthManager healthManager;
    private void Start()
    {
        healthManager = GameObject.Find("UIManager").GetComponent<HealthManager>();
    }
    private void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthManager.ChangeHealth();
            Destroy(gameObject);
        }
    }
}
