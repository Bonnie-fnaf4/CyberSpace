using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text txtStatic1, txtStatic2, txtStatic3, txtFinish;
    [SerializeField] Player player;
    [SerializeField] Transform basePlayerTransform;
    [SerializeField] BasePlayer basePlayer;
    [SerializeField] GameObject meteorite, enemy, menuPause, menuFinish;
    [SerializeField] int basehp, playerHP, countEnemys, countMeteorites;

    public Color NotActive = new Color(1, 1, 1, 0.5f);
    public Color Active = new Color(1, 1, 1, 1);

    public Image ContinueButton;

    GameObject[] enemys;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        player.hp = playerHP;
        basePlayer.hp = basehp;
        ContinueButton.color = Active;
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        txtStatic1.text = $"Жизни { player.hp,3}";
        txtStatic2.text = $"Жизни Станции { basePlayer.hp,3}";
        txtStatic3.text = $"Противнкиов { countEnemys,3}";
        if(basePlayer.hp <= 0 || player.hp == 0)
        {
            Lose();
            return;
        }
        if(getCountEnemy() == 0)
        {
            Win();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1) PauseGame();
    }
    void GenerateLevel()
    {
        enemys = new GameObject[countEnemys];

        for(int i = 0; i < countEnemys; i++)
        {
            Vector3 randomPos = Random.onUnitSphere * 100;
            enemys[i] = Instantiate(enemy, randomPos, Quaternion.identity);
                Enemy script = enemys[i].GetComponent<Enemy>();
            script.target = basePlayerTransform;
        }
        for(int i = 0; i < countMeteorites; i++)
        {
            Vector3 randomPos = Random.onUnitSphere * 100;
            Instantiate(meteorite, randomPos, Quaternion.identity);
        }
    }
    void Lose()
    {
        menuFinish.SetActive(true);
        txtFinish.text = "Поражение";
        ContinueButton.color = NotActive;
        Time.timeScale = 0;
        //Cursor.lockState = CursorLockMode.None;
    }
    void Win()
    {
        menuFinish.SetActive(true);
        txtFinish.text = "Победа";
        ContinueButton.color = NotActive;
        Time.timeScale = 0;
        //Cursor.lockState = CursorLockMode.None;
    }
    void PauseGame()
    {
        menuFinish.SetActive(true);
        ContinueButton.color = Active;
        Time.timeScale = 0;
        //Cursor.lockState = CursorLockMode.None;
    }
    public void ContinueGame()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    int getCountEnemy()
    {
        int count = 0;
        foreach (GameObject g in enemys)
            if (g != null) count++;
        return count;
    }
}
