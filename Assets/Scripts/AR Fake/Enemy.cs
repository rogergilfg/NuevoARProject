using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float destroyTime;
    private UIController uiController;
    public float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Camera.main.transform;
        uiController = FindObjectOfType<UIController>();
        StartCoroutine(TiempoDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player, Vector3.up);
        Vector3 distance = (player.position - transform.position).normalized;
        transform.position += distance * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado con: " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator TiempoDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

}
