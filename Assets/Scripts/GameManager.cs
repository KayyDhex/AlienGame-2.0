using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    public int enemyCount;
    private void Awake(){
        int managers = GameObject.FindObjectsOfType<GameManager>().Length;
        if( managers > 1) 
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this); 
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        enemyCount = enemies.Length;
    }

    void Update()
    {
        //Time.timeScale = 0; 
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        GameObject.Find("Canvas").SetActive(false);
        foreach(GameObject enemy in enemies){
            float minX = Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x;
            float maxX = Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x;

            float x = Random.Range(minX,maxX);

            Instantiate(enemy, new Vector2(x,0.5F),Quaternion.identity);
        }
    }
}
