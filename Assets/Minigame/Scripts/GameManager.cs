using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text timeVariable, coinVariable, previewCoins;
    private float minutes,seconds;
    [SerializeField]
    private float time = 10;
    [SerializeField]
    private GameObject gameOverMenu,missile,enemyPosition;
    private int coins,allCoins;
    private bool gameOver;
    
    void Start()
    {
        InvokeRepeating("Timer", 1f, 1f);
        InvokeRepeating("InstantiateEnemy", 5, 5);
        allCoins = PlayerPrefs.GetInt("PlayerCoins",0);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        coinVariable.text =coins.ToString();
        if (time == 0)
        {
            gameOver = true;
            gameOverMenu.SetActive(true);
            previewCoins.text = coins.ToString();
            Invoke("StopTime", 2);
            
        }
    }


    private void Timer()
    {
        if (!gameOver)
        {
            time--;
            minutes = Mathf.Floor(time / 60);
            seconds = time % 60;
            if ((time % 60) < 10){
                
                timeVariable.text = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {

                timeVariable.text = minutes.ToString() + ":" + seconds.ToString();
            }
            
        }
        
    }
    public void UpdateCoins()
    {
        int coinAmount=Random.Range(100,500);
        coins += coinAmount;
    }
    public void CollectCoins()
    {
        Time.timeScale=1;
        PlayerPrefs.SetInt("PlayerCoins", allCoins+coins);
        SceneManager.LoadScene(0);
    }

    void StopTime()
    {
        Time.timeScale = 0;
    }

    void InstantiateEnemy()
    {
        Instantiate(missile,new Vector3(enemyPosition.transform.position.x+Random.Range(-9,9), enemyPosition.transform.position.y, 0),this.transform.rotation);
    }
}
