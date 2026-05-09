using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float currentLife { get; private set; }
    [SerializeField] private float maxLife;
    [SerializeField] private UIController uiController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLife = maxLife;
        currentLife = Mathf.Max(currentLife, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
        uiController.UpdateHearts();

        if(currentLife <= 0)
        {
            uiController.GameOver();
        }
    }

    public void HealPlayer()
    {
        if(currentLife >= maxLife)
        {
            return;
        }
        currentLife++;
    }
}
