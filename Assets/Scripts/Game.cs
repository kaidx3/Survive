using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{ 
    private int level = 1;
    private double xp = 0;
    private double xpTillLevel = 100;
    private float time = 0;
    private float playerDeadTime = 0;
    private double spawnRate = 5;

    public GameObject enemy;
    public Transform player;
    private Game game;
    private PlayerController playerController;

    public TMP_Text leveLabel;
    public TMP_Text hpLabel;
    public GameObject gameoverText;

    private GameObject weapon;
    private GameObject weaponUpgrade1;
    private GameObject basicLeftGun;
    private GameObject basicRightGun;
    private GameObject leftMachineGun;
    private GameObject rightMachineGun;
    private GameObject speedCannon;
    private GameObject basicCannon;

    public List<GameObject> enemies = new List<GameObject>();

    public int Level
    {
        get { return level; }
        set
        {
            if (value > 1)
            {
                level = value;
            }
            else
            {
                throw new Exception("Level must be above 0");
            }
        }
    }

    public double Xp
    {
        get { return xp; }
        set
        {
            if (value >= 0)
            {
                xp = value;
            }
            else
            {
                throw new Exception("Xp must be above 0");
            }
        }
    }

    public double XpTillLevel
    {
        get { return xpTillLevel; }
        set
        {
            if (value > 0)
            {
                xpTillLevel = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        CreateEnemy();
        weapon = GameObject.Find("Weapon");
        weaponUpgrade1 = GameObject.Find("WeaponUpgrade1");
        basicLeftGun = GameObject.Find("BasicLeftGun");
        basicRightGun = GameObject.Find("BasicRightGun");
        leftMachineGun = GameObject.Find("LeftMachineGun");
        rightMachineGun = GameObject.Find("RightMachineGun");
        speedCannon = GameObject.Find("SpeedCannon");
        basicCannon = GameObject.Find("BasicCannon");
        gameoverText = GameObject.Find("GameoverText");

        weaponUpgrade1.SetActive(false);
        basicLeftGun.SetActive(false);
        basicRightGun.SetActive(false);
        leftMachineGun.SetActive(false);
        rightMachineGun.SetActive(false);
        speedCannon.SetActive(false);
        basicCannon.SetActive(false);
        gameoverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnRate)
        {
            CreateEnemy();
            time = 0;
        }

        if (playerController == null)
        {
            gameoverText.SetActive(true);
            playerDeadTime += Time.deltaTime;
            if (Input.anyKey && playerDeadTime > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKey(KeyCode.Escape) && playerDeadTime > 2)
            {
                Application.Quit();
            }
        }
        else
        {
            leveLabel.text = $"Level: {level}";
            hpLabel.text = $"HP: {playerController.health}/100";
        }
    }

    void CreateEnemy()
    {
        if (player != null)
        {
            Vector3 enemySpawn = new Vector3(UnityEngine.Random.Range(player.position.x - 20f, player.position.x + 20f), UnityEngine.Random.Range(player.position.y - 20f, player.position.y + 20f), 0);
            if (enemies.Count < 400)
            {
                enemies.Add(Instantiate(enemy, enemySpawn, Quaternion.identity));
            }
        }
    }

    public void LevelCheck()
    {
        if (xp >= xpTillLevel)
        {
            while (xp >= xpTillLevel)
            {
                xp -= xpTillLevel;
                level++;
            }
            xpTillLevel *= 1.5;
        }
        WeaponCheck();
    }

    public void WeaponCheck()
    {
        if (level == 2)
        {
            weapon.SetActive(false);
            weaponUpgrade1.SetActive(true);
            spawnRate = 2.2;
        }
        else if (level == 3)
        {
            basicLeftGun.SetActive(true);
            basicRightGun.SetActive(true);
            spawnRate = 1.8;
        }
        else if (level == 3)
        {
            spawnRate = 1.2;
        }
        else if (level == 4)
        {
            spawnRate = 1;
        }
        else if (level == 5)
        {
            weaponUpgrade1.SetActive(false);
            basicCannon.SetActive(true);
            spawnRate = 0.8;
        }
        else if (level == 6)
        {
            spawnRate = 0.7;
        }
        else if (level == 7)
        {
            spawnRate = 0.45;
        }
        else if (level == 8)
        {
            leftMachineGun.SetActive(true);
            rightMachineGun.SetActive(true);
            spawnRate = 0.3;
        }
        else if (level == 9)
        {
            spawnRate = 0.2;
            speedCannon.SetActive(true);
            basicCannon.SetActive(false);
        }
        else if (level == 10)
        {
            spawnRate = 0.18;
        }
        else if (level == 11)
        {
            spawnRate = 0.1;
        }
        else if (level == 12)
        {
            spawnRate = 0.08;
        }
        else if (level == 13)
        {
            spawnRate = 0.05;
        }
        else if (level == 14)
        {
            spawnRate = 0.02;
        }
        else if (level == 15)
        {
            spawnRate = 0.01;
        }
    }
}

