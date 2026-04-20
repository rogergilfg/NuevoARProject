using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        Vector3 distance = (player.position - transform.position).normalized;
        transform.position += distance * speed * Time.deltaTime;
    }

    
}
