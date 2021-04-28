using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public GameObject Cover;
    public GameObject GOCover;
    public ItemManager itemManager;
    public SpawnManager spawnManager;

    int score = 0;
    UserData userData;
    public Text ScoreText;
    public Text BestScoreText;

    public Text GOScoreText;
    public Text GOBestScoreText;

    void Start() {
        EventManager.EnemyDieEvent += OnEnemyDie;
        EventManager.CoinEatEvent += EatCoin;
        EventManager.PlayerDieEvent += PlayerDie;

        ScoreText.text = System.String.Format("Score : {0}", score);

        LoadUserData();
        BestScoreText.text = System.String.Format("Best Score : {0}", userData.BestScore);
        
    }

    public void PlayerDie() {
        GOBestScoreText.text = System.String.Format("Best Score : {0}", userData.BestScore);
        GOScoreText.text = System.String.Format("Your Score : {0}", score);
        GOCover.SetActive(true);
    }

    public void OnClickStartBtn() {
        Cover.SetActive(false);
        StartCoroutine(itemManager.SpawnRandom());
        StartCoroutine(spawnManager.SpawnRandom());
    }

    public void OnEnemyDie() {
        score++;
        ScoreText.text = System.String.Format("Score : {0}", score);

        if (score > userData.BestScore) {
            userData.BestScore = score;
            BestScoreText.text = System.String.Format("Best Score : {0}", userData.BestScore);

            SaveUserData();
        }
    }

    public void EatCoin() {
        score += 2;
        ScoreText.text = System.String.Format("Score : {0}", score);

        if (score > userData.BestScore) {
            userData.BestScore = score;
            BestScoreText.text = System.String.Format("Best Score : {0}", userData.BestScore);

            SaveUserData();
        }
    }

    void SaveUserData() {
        FileStream fs = new FileStream(Application.persistentDataPath + "/userData.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, userData);
        fs.Close();
    }

    void LoadUserData() {
        try{
            FileStream fs = new FileStream(Application.persistentDataPath + "/userData.dat", FileMode.Open);   
            BinaryFormatter bf = new BinaryFormatter();
            userData = (UserData)bf.Deserialize(fs);
            fs.Close();
        } catch(System.Exception e){
            Debug.Log(e.Message);
            userData = new UserData();
        }
    }
}

[System.Serializable]
class UserData {
    public int BestScore;
}