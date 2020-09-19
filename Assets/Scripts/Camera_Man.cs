using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Camera_Man : MonoBehaviour
{
    public float spawnHelper = 4.5f;
    public GameObject ball;
    public float ballForce;
    public float camSpeed;
    private int level = 0;

    private Camera _cam;

    public float ballCount = 15;
    public Text BallCountText;
    public Text GameOverText;
    public GameObject restartButton;

    bool isGameOver = false;
    public bool isGamePause = false;
   
    void Start()
    {
        _cam = GetComponent<Camera>();
       // DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        if (isGamePause)
        {
            camSpeed = 0;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1 * camSpeed);

        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !isGameOver && !isGamePause)
        {
            GameObject ballRigid;
            ballRigid = Instantiate(ball, transform.position, transform.rotation) as GameObject;
            ballCount--;
            Vector3 targetLoc = ray.direction;
            ballRigid.GetComponent<Rigidbody>().AddForce(targetLoc * ballForce);
        }

       // BallCountText.text = " " + ballCount;

        if (ballCount == 0)
        {
           // GameOverText.gameObject.SetActive(true);
            camSpeed = 0;
            isGameOver = true;
        }
    }

    public void RestartGame()
    {
        isGameOver = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("glass"))
        {
            ballCount -= 10;
        }
    }

    public void LevelUp()
    {
        SceneManager.LoadScene(level + 1);
        level++;
        Debug.Log (level);
    }
}
