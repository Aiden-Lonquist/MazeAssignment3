using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveScript : MonoBehaviour
{
    public static int score;
    public Vector3 playerPOS, enemyPOS;
    public static int savedScore;
    public static Vector3 savedPlayerPOS, savedEnemyPOS;
    public GameObject player, enemy;
    const string filename = "/gamestate.dat"; // file is at "[user]/AppData/LocalLow/[company name]/[game name]
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            saveScore();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            loadScore();
        }
    }

    [Serializable]
    class GameData
    {
        public int score = 0;
        public float playerX = 0;
        public float playerY = 0;
        public float playerZ = 0;
        public float enemyX = 0;
        public float enemyY = 0;
        public float enemyZ = 0;
    };

    public void loadScore() // load score function from lab
    {
        //Debug.Log("Loading Score...");
        if (File.Exists(Application.persistentDataPath + filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + filename, FileMode.Open, FileAccess.Read);
            GameData data = (GameData)bf.Deserialize(fs);
            fs.Close();
            savedScore = data.score;
            savedPlayerPOS = new Vector3 (data.playerX, data.playerY, data.playerZ);
            savedEnemyPOS = new Vector3(data.enemyX, data.enemyY, data.enemyZ);
            setPOS();

        }
    }

    public void saveScore() // save score function from lab
    {
        //Debug.Log("Saving Score");
        // save the current values

        savedPlayerPOS = GameObject.Find("Player").GetComponent<playerScript>().GetPlayerPOS();
        if (GameObject.Find("Enemy") != null)
        {
            savedEnemyPOS = GameObject.Find("Enemy").transform.position;
        } else
        {
            savedEnemyPOS = GameObject.Find("Enemy(Clone)").transform.position;
        }
        //Debug.Log("savedscore: " + savedScore + " savedplayerpos: " + savedPlayerPOS + " savedenemypos: " + savedEnemyPOS);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + filename, FileMode.OpenOrCreate);
        GameData data = new GameData();
        data.score = savedScore;
        data.playerX = savedPlayerPOS.x;
        data.playerY = savedPlayerPOS.y;
        data.playerZ = savedPlayerPOS.z;
        data.enemyX = savedEnemyPOS.x;
        data.enemyY = savedEnemyPOS.y;
        data.enemyZ = savedEnemyPOS.z;
        bf.Serialize(fs, data);
        fs.Close();
    }

    public void setPOS()
    {
        GameObject.Find("Player").transform.position = savedPlayerPOS;
        if (GameObject.Find("Enemy") != null)
        {
            GameObject.Find("Enemy").transform.position = savedEnemyPOS;
        } else
        {
            GameObject.Find("Enemy(Clone)").transform.position = savedEnemyPOS;
        }
    }

    public void increaseScore()
    {
        savedScore += 1;
        Debug.Log("Score increased to: " + score);
    }
}

