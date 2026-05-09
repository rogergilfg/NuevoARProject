using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int enemiesKilled;
    [SerializeField] private TextMeshProUGUI contador;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject gameOver;

    [SerializeField] private Image[] hearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Image heart in hearts)
        {
            heart.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKill()
    {
        enemiesKilled++;
        contador.text = enemiesKilled.ToString();

        if (enemiesKilled % 20 == 0)
        {
            playerController.HealPlayer();
            hearts[(int)(playerController.currentLife - 1)].enabled = true;
        }
    }

    public void UpdateHearts()
    {
        if(playerController.currentLife >= 0)
        {
            hearts[(int)(playerController.currentLife)].enabled = false;
        }
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
