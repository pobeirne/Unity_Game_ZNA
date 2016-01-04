using System.Collections.Generic;
using UnityEngine;

public class Position
{
    public float xPos;
    public float yPos;
}


public class LevelLoadManager : GMBase
{
    //Player
    public GameObject player;

    //CheckPoints
    public GameObject checkPoint;
    public GameObject checkPointFlag;

    //Screens
    public GameObject hudScreen;
    public GameObject pauseScreen;
    //public GameObject gameOverScreen;

    //Map
    public GameObject map;

    //Collectables    
    private GameObject coin;
    public GameObject[] coinArray;
    private List<GameObject> coinList;
    private List<Vector3> coinGridPositions;

    //Enemies    
    private GameObject enemy;
    public GameObject[] enemyArray;
    private List<GameObject> enemyList;
    private List<Vector3> enemyGridPositions;


    void OnLevelWasLoaded()
    {
        if (Application.loadedLevel == 1 || Application.loadedLevel == 2)
        {
            if (Application.loadedLevel == 1)
            {

                LoadMap();
                LoadHUDSystem();
                LoadScreens();
                LoadCheckPoints(1);
                LoadPlayer();


                AddEnemyLevelPositions(1);
                AddCoinLevelPositions(1);
                LoadCoins(40,25,15);
                LoadEnemies(9, 9);
            }

            if (Application.loadedLevel == 2)
            {
                LoadMap();
                LoadHUDSystem();
                LoadScreens();
                LoadCheckPoints(2);
                LoadPlayer();


                AddEnemyLevelPositions(2);
                AddCoinLevelPositions(2);
                LoadCoins(50,30,23);
                LoadEnemies(12, 13);
            }
        }
    }
    private void LoadMap()
    {
        var levelHolder = new GameObject("Loaded_Map").transform;
        map = Instantiate(map, new Vector3(-9f, 5f, 0f), Quaternion.identity) as GameObject;
        map.transform.SetParent(levelHolder);
    }
    private void LoadHUDSystem()
    {
        var levelHolder = new GameObject("Loaded_Hud").transform;
        hudScreen = Instantiate(hudScreen, new Vector3(0f, 0f, -10f), Quaternion.identity) as GameObject;
        hudScreen.transform.SetParent(levelHolder);
    }
    private void LoadCheckPoints(int level)
    {
        var levelHolder = new GameObject("Loaded_CheckPoints").transform;
        checkPoint = Instantiate(checkPoint, new Vector3(-7.5f, -2.5f, 0), Quaternion.identity) as GameObject;

        if (level == 1)
        {
            checkPointFlag = Instantiate(checkPointFlag, new Vector3(53.8f, 3.6f, 0), Quaternion.identity) as GameObject;
        }
        if (level == 2)
        {
            checkPointFlag = Instantiate(checkPointFlag, new Vector3(27.42f, 3.16f, 0), Quaternion.identity) as GameObject;
        }

        checkPoint.transform.SetParent(levelHolder);
        checkPointFlag.transform.SetParent(levelHolder);

    }
    private void LoadPlayer()
    {
        var levelHolder = new GameObject("Loaded_Player").transform;
        player = Instantiate(player, checkPoint.transform.position, checkPoint.transform.rotation) as GameObject;
        player.transform.SetParent(levelHolder);
    }
    private void LoadScreens()
    {
        var levelHolder = new GameObject("Loaded_Screens").transform;
        pauseScreen = Instantiate(pauseScreen, new Vector3(0f, 0f, -10f), Quaternion.identity) as GameObject;
        pauseScreen.transform.SetParent(levelHolder);
    }
    private void LoadCoins(int b, int s , int g)
    {
        coinList = new List<GameObject>();
        PopulateList(b, 0, coinList, coinArray);
        PopulateList(s, 1, coinList, coinArray);
        PopulateList(g, 2, coinList, coinArray);

        var levelHolder = new GameObject("Loaded_Coins").transform;

        foreach (var item in coinList)
        {
            var randomPosition = RandomPosition(coinGridPositions);
            coin = Instantiate(item, randomPosition, Quaternion.identity) as GameObject;
            coin.transform.SetParent(levelHolder);
        }
    }
    private void LoadEnemies(int t1, int t2)
    {
        enemyList = new List<GameObject>();
        PopulateList(t1, 0, enemyList, enemyArray);
        PopulateList(t2, 1, enemyList, enemyArray);

        var levelHolder = new GameObject("Loaded_Enemies").transform;

        foreach (var item in enemyList)
        {
            var randomPosition = RandomPosition(enemyGridPositions);
            enemy = Instantiate(item, randomPosition, Quaternion.identity) as GameObject;
            enemy.transform.SetParent(levelHolder);
        }
    }

    //Helper Methods
    private Vector3 RandomPosition(List<Vector3> list)
    {
        //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
        int randomIndex = Random.Range(0, list.Count);
        //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
        Vector3 randomPosition = list[randomIndex];
        //Remove the entry at randomIndex from the list so that it can't be re-used.
        list.RemoveAt(randomIndex);
        //Return the randomly selected Vector3 position.
        return randomPosition;
    }
    private void AddCoinLevelPositions(int level)
    {
        if (level == 1)
        {
            coinGridPositions = new List<Vector3>() {
                {
                    new Vector3(-3.49f, 4.29f, 0f)
                }, {
                    new Vector3(-2.99f, 4.29f, 0f)
                }, {
                    new Vector3(-2.51f, 4.29f, 0f)
                }, {
                    new Vector3(-2.03f, 4.29f, 0f)
                }, {
                    new Vector3(-1.1f, -1.5f, 0f)
                }, {
                    new Vector3(-0.11f, -1.5f, 0f)
                }, {
                    new Vector3(-0.6f, -1.5f, 0f)
                }, {
                    new Vector3(2.29f, 4.29f, 0f)
                }, {
                    new Vector3(2.77f, 4.29f, 0f)
                }, {
                    new Vector3(3.23f, 4.29f, 0f)
                }, {
                    new Vector3(5.15f, -2.43f, 0f)
                }, {
                    new Vector3(5.63f, -2.43f, 0f)
                }, {
                    new Vector3(6.13f, -2.43f, 0f)
                }, {
                    new Vector3(10.42f, 4.29f, 0f)
                }, {
                    new Vector3(10.92f, 4.29f, 0f)
                }, {
                    new Vector3(11.4f, 4.29f, 0f)
                }, {
                    new Vector3(11.88f, 4.29f, 0f)
                }, {
                    new Vector3(10.92f, -1.5f, 0f)
                }, {
                    new Vector3(11.40f, -1.5f, 0f)
                }, {
                    new Vector3(11.88f, -1.5f, 0f)
                }, {
                    new Vector3(14.76f, 2.36f, 0f)
                }, {
                    new Vector3(15.26f, 2.36f, 0f)
                }, {
                    new Vector3(15.72f, 2.36f, 0f)
                }, {
                    new Vector3(15.74f, -2.43f, 0f)
                }, {
                    new Vector3(16.2f, -2.43f, 0f)
                }, {
                    new Vector3(16.68f, -2.43f, 0f)
                }, {
                    new Vector3(18.11f, 4.29f, 0f)
                }, {
                    new Vector3(18.59f, 4.29f, 0f)
                }, {
                    new Vector3(19.09f, 4.29f, 0f)
                }, {
                    new Vector3(19.57f, 4.29f, 0f)
                }, {
                    new Vector3(20.51f, -1.5f, 0f)
                }, {
                    new Vector3(21f, -1.5f, 0f)
                }, {
                    new Vector3(21.47f, -1.5f, 0f)
                }, {
                    new Vector3(25.81f, -2.44f, 0f)
                }, {
                    new Vector3(26.27f, -2.44f, 0f)
                }, {
                    new Vector3(26.75f, -2.44f, 0f)
                }, {
                    new Vector3(26.75f, 4.29f, 0f)
                }, {
                    new Vector3(27.23f, 4.29f, 0f)
                }, {
                    new Vector3(27.71f, 4.29f, 0f)
                }, {
                    new Vector3(28.21f, 4.29f, 0f)
                }, {
                    new Vector3(33.46f, -2.44f, 0f)
                }, {
                    new Vector3(33.96f, -2.44f, 0f)
                }, {
                    new Vector3(32.53f, 4.29f, 0f)
                }, {
                    new Vector3(33f, 4.29f, 0f)
                }, {
                    new Vector3(33.47f, 4.29f, 0f)
                }, {
                    new Vector3(33.96f, 4.29f, 0f)
                }, {
                    new Vector3(34.44f, -2.44f, 0f)
                }, {
                    new Vector3(36.35f, 2.36f, 0f)
                }, {
                    new Vector3(36.84f, 2.36f, 0f)
                }, {
                    new Vector3(37.33f, 2.36f, 0f)
                }, {
                    new Vector3(37.79f, -1.5f, 0f)
                }, {
                    new Vector3(38.29f, -1.5f, 0f)
                }, {
                    new Vector3(38.77f, -1.5f, 0f)
                }, {
                    new Vector3(39.7f, 4.29f, 0f)
                }, {
                    new Vector3(40.21f, 4.29f, 0f)
                }, {
                    new Vector3(40.68f, 4.29f, 0f)
                }, {
                    new Vector3(41.17f, 4.29f, 0f)
                }, {
                    new Vector3(43.57f, -2.44f, 0f)
                }, {
                    new Vector3(44.04f, 2.36f, 0f)
                }, {
                    new Vector3(44.53f, 2.36f, 0f)
                }, {
                    new Vector3(44.03f, -2.44f, 0f)
                }, {
                    new Vector3(44.53f, -2.44f, 0f)
                }, {
                    new Vector3(47.39f, 4.29f, 0f)
                }, {
                    new Vector3(47.88f, 4.29f, 0f)
                }, {
                    new Vector3(48.37f, 4.29f, 0f)
                }, {
                    new Vector3(48.84f, 4.29f, 0f)
                }, {
                    new Vector3(51.25f, 1.41f, 0f)
                }, {
                    new Vector3(51.72f, 1.86f, 0f)
                }, {
                    new Vector3(51.23f, -2.44f, 0f)
                }, {
                    new Vector3(51.7f, -2.44f, 0f)
                }, {
                    new Vector3(52.19f, 2.35f, 0f)
                }, {
                    new Vector3(52.68f, 2.84f, 0f)
                }, {
                    new Vector3(52.21f, -2.44f, 0f)
                }, {
                    new Vector3(54.62f, 2.35f, 0f)
                }, {
                    new Vector3(54.13f, 2.84f, 0f)
                }, {
                    new Vector3(55.37f, 1.41f, 0f)
                }, {
                    new Vector3(55.09f, 1.86f, 0f)
                }, {
                    new Vector3(55.08f, -2.44f, 0f)
                }, {
                    new Vector3(55.55f, -2.44f, 0f)
                }, {
                    new Vector3(56.06f, -2.44f, 0f)
                }
            };
        }
        else if (level == 2)
        {
            coinGridPositions = new List<Vector3>() {
				//1-40
				{
                    new Vector3(-8.29f, 3.33f, 0f)
                }, {
                    new Vector3(-7.81f, 3.33f, 0f)
                }, {
                    new Vector3(-7.33f, 3.33f, 0f)
                }, {
                    new Vector3(-6.82f, 3.33f, 0f)
                }, {
                    new Vector3(-6.36f, 3.33f, 0f)
                }, {
                    new Vector3(-5.85f, 3.33f, 0f)
                }, {
                    new Vector3(-1.07f, 3.33f, 0f)
                }, {
                    new Vector3(-0.56f, 3.33f, 0f)
                }, {
                    new Vector3(2.77f, 3.33f, 0f)
                }, {
                    new Vector3(6.62f, 3.33f, 0f)
                }, {
                    new Vector3(7.1f, 3.33f, 0f)
                }, {
                    new Vector3(10.47f, 3.33f, 0f)
                }, {
                    new Vector3(10.91f, 3.33f, 0f)
                }, {
                    new Vector3(16.71f, 3.33f, 0f)
                }, {
                    new Vector3(17.17f, 3.33f, 0f)
                }, {
                    new Vector3(26.76f, 3.33f, 0f)
                }, {
                    new Vector3(27.24f, 3.33f, 0f)
                }, {
                    new Vector3(34.45f, 3.33f, 0f)
                }, {
                    new Vector3(34.93f, 3.33f, 0f)
                }, {
                    new Vector3(38.3f, 3.33f, 0f)
                }, {
                    new Vector3(45.48f, 3.33f, 0f)
                }, {
                    new Vector3(45.99f, 3.33f, 0f)

                }, {
                    new Vector3(-8.29f, 1.39f, 0f)
                }, {
                    new Vector3(-7.33f, 1.39f, 0f)
                }, {
                    new Vector3(-6.82f, 1.39f, 0f)
                }, {
                    new Vector3(-6.36f, 1.39f, 0f)
                }, {
                    new Vector3(-5.85f, 1.39f, 0f)
                }, {
                    new Vector3(-1.07f, 1.39f, 0f)
                }, {
                    new Vector3(-0.56f, 1.39f, 0f)
                }, {
                    new Vector3(2.77f, 1.39f, 0f)
                }, {
                    new Vector3(3.23f, 1.39f, 0f)
                }, {
                    new Vector3(6.62f, 1.39f, 0f)
                }, {
                    new Vector3(7.1f, 1.39f, 0f)
                }, {
                    new Vector3(10.47f, 1.39f, 0f)
                }, {
                    new Vector3(10.91f, 1.39f, 0f)

                }, {
                    new Vector3(-1.07f, -0.53f, 0f)
                }, {
                    new Vector3(-0.56f, -0.53f, 0f)
                }, {
                    new Vector3(2.77f, -0.53f, 0f)
                }, {
                    new Vector3(3.23f, -0.53f, 0f)
                }, {
                    new Vector3(6.62f, -0.53f, 0f)
                }, {
                    new Vector3(7.0f, -0.53f, 0f)
                }, {
                    new Vector3(10.47f, -0.53f, 0f)
                }, {
                    new Vector3(10.91f, -0.53f, 0f)
                }, {
                    new Vector3(26.76f, -0.53f, 0f)
                }, {
                    new Vector3(27.24f, -0.53f, 0f)
                }, {
                    new Vector3(34.45f, -0.53f, 0f)
                }, {
                    new Vector3(34.93f, -0.53f, 0f)
                }, {
                    new Vector3(38.3f, -0.53f, 0f)
                }, {
                    new Vector3(45.48f, -0.53f, 0f)
                }, {
                    new Vector3(45.99f, -0.53f, 0f)
                }, {
                    new Vector3(17.21f, -0.53f, 0f)
                }, {
                    new Vector3(17.62f, -0.53f, 0f)
                }, {
                    new Vector3(18.12f, -0.53f, 0f)
                }, {
                    new Vector3(18.6f, -0.53f, 0f)
                }, {
                    new Vector3(19.08f, -0.53f, 0f)
                }, {
                    new Vector3(16.69f, -1f, 0f)
                }, {
                    new Vector3(17.17f, -1f, 0f)
                }, {
                    new Vector3(17.64f, -0.05f, 0f)
                }, {
                    new Vector3(18.11f, -0.05f, 0f)
                }, {
                    new Vector3(18.59f, -0.05f, 0f)
                }, {
                    new Vector3(19.09f, -0.05f, 0f)
                }, {
                    new Vector3(19.09f, 0.92f, 0f)
                }, {
                    new Vector3(19.09f, 1.42f, 0f)
                }, {
                    new Vector3(19.09f, 1.89f, 0f)
                }, {
                    new Vector3(18.59f, 1.89f, 0f)
                }, {
                    new Vector3(18.59f, 1.42f, 0f)
                }, {
                    new Vector3(18.59f, 0.92f, 0f)
                }, {
                    new Vector3(14.28f, 0.92f, 0f)
                }, {
                    new Vector3(13.8f, 0.45f, 0f)
                }, {
                    new Vector3(14.76f, 1.4f, 0f)
                }, {
                    new Vector3(15.23f, 1.87f, 0f)
                }, {
                    new Vector3(15.71f, 2.37f, 0f)
                }, {
                    new Vector3(49.8f, 1.4f, 0f)
                }, {
                    new Vector3(49.8f, 0.92f, 0f)
                }, {
                    new Vector3(49.8f, 0.45f, 0f)
                }, {
                    new Vector3(49.8f, -0.05f, 0f)
                }, {
                    new Vector3(50.29f, -0.05f, 0f)
                }, {
                    new Vector3(50.29f, 0.45f, 0f)
                }, {
                    new Vector3(50.29f, 0.93f, 0f)
                }, {
                    new Vector3(57.01f, 0.93f, 0f)
                }, {
                    new Vector3(57.01f, 0.45f, 0f)
                }, {
                    new Vector3(57.01f, -0.05f, 0f)
                }, {
                    new Vector3(57.01f, -0.51f, 0f)
                }, {
                    new Vector3(57.48f, -0.03f, 0f)
                }, {
                    new Vector3(57.48f, 0.45f, 0f)
                }, {
                    new Vector3(57.48f, 0.93f, 0f)
                }, {
                    new Vector3(57.48f, 1.4f, 0f)
                }, {
                    new Vector3(52.2f, -1f, 0f)
                }, {
                    new Vector3(52.68f, -1f, 0f)
                }, {
                    new Vector3(53.16f, -1f, 0f)
                }, {
                    new Vector3(53.65f, -1f, 0f)
                }, {
                    new Vector3(54.12f, -1f, 0f)
                }, {
                    new Vector3(54.61f, -1f, 0f)
                }, {
                    new Vector3(55.06f, -1f, 0f)
                }, {
                    new Vector3(51.73f, -1.47f, 0f)
                }, {
                    new Vector3(52.21f, -1.47f, 0f)
                }, {
                    new Vector3(52.69f, -1.47f, 0f)
                }, {
                    new Vector3(53.17f, -1.47f, 0f)
                }, {
                    new Vector3(53.62f, -1.47f, 0f)
                }, {
                    new Vector3(54.11f, -1.47f, 0f)
                }, {
                    new Vector3(54.59f, -1.47f, 0f)
                }, {
                    new Vector3(55.09f, -1.47f, 0f)
                }, {
                    new Vector3(55.58f, -1.47f, 0f)
                }
            };
        }
    }
    private void AddEnemyLevelPositions(int level)
    {
        if (level == 1)
        {
            enemyGridPositions = new List<Vector3>() {
				//1-10
				{
                    new Vector3(8.82f, -3.16f, 0f)
                }, {
                    new Vector3(7.7f, 1.66f, 0f)
                }, {
                    new Vector3(-0.25f, 1.66f, 0f)
                }, {
                    new Vector3(-4.83f, 3.7f, 0f)
                }, {
                    new Vector3(13.67f, 3.7f, 0f)
                }, {
                    new Vector3(18.91f, 3.7f, 0f)
                }, {
                    new Vector3(16.2f, -3.16f, 0f)
                }, {
                    new Vector3(16.2f, 1.69f, 0f)
                }, {
                    new Vector3(38.66f, 1.69f, 0f)
                }, {
                    new Vector3(35.85f, -3.16f, 0f)
                },
				//10-18
				{
                    new Vector3(27.1f, -3.16f, 0f)
                }, {
                    new Vector3(31.23f, 3.7f, 0f)
                }, {
                    new Vector3(42.48f, 3.7f, 0f)
                }, {
                    new Vector3(48.17f, 3.7f, 0f)
                }, {
                    new Vector3(46.78f, 1.66f, 0f)
                }, {
                    new Vector3(56.57f, 1.69f, 0f)
                }, {
                    new Vector3(57.82f, -3.16f, 0f)
                }, {
                    new Vector3(52.2f, -3.16f, 0f)
                }
            };
        }
        if (level == 2)
        {
            enemyGridPositions = new List<Vector3>() {

                {
                    new Vector3(-5.93f, 1.1f, 0f)
                }, {
                    new Vector3(-8.27f, 3.06f, 0f)
                }, {
                    new Vector3(-0.30f, -3.04f, 0f)
                }, {
                    new Vector3(-2.44f, -3.04f, 0f)
                }, {
                    new Vector3(8.76f, -3.04f, 0f)
                }, {
                    new Vector3(12.08f, -3.04f, 0f)
                }, {
                    new Vector3(25.33f, -3.04f, 0f)
                }, {
                    new Vector3(17.53f, 3.35f, 0f)
                }, {
                    new Vector3(8.67f, -0.67f, 0f)
                }, {
                    new Vector3(11.29f, -3.16f, 0f)
                },



                {
                    new Vector3(-3.36f, 3.16f, 0f)
                }, {
                    new Vector3(3.59f, 3.16f, 0f)
                }, {
                    new Vector3(-0.89f, 1.23f, 0f)
                }, {
                    new Vector3(7.35f, 1.23f, 0f)
                }, {
                    new Vector3(-2.43f, -0.71f, 0f)
                }, {
                    new Vector3(10.03f, 3.32f, 0f)
                }, {
                    new Vector3(21.31f, -3.16f, 0f)
                }, {
                    new Vector3(37.1f, -3.16f, 0f)
                }, {
                    new Vector3(38.75f, -0.67f, 0f)
                }, {
                    new Vector3(33.73f, -1.23f, 0f)

                }, {
                    new Vector3(28.42f, -1.31f, 0f)
                }, {
                    new Vector3(24.96f, 3.32f, 0f)
                }, {
                    new Vector3(46.63f, 3.32f, 0f)
                }, {
                    new Vector3(53.4f, 2.74f, 0f)
                }, {
                    new Vector3(56.4f, -1.23f, 0f)
                }, {
                    new Vector3(49.79f, -3.14f, 0f)
                }


            };
        }

    }
    private void PopulateList(int amount, int type, List<GameObject> list, GameObject[] array)
    {
        for (int i = 0; i < amount; i++)
        {
            list.Add(array[type]);
        }
    }
}