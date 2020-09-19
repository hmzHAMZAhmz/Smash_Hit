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

    public Animator leftdoor;
    public Animator rightdoor;

    private Camera _cam;

    public float ballCount = 15;
    public Text BallCountText;
    public Text GameOverText;
    public GameObject restartButton;
    public GameObject finishPanel;
    public int passedDoor;

    bool isGameOver = false;
    public bool isGamePause = false;
    bool isGameFinished = false;

    void Start()
    {
        _cam = GetComponent<Camera>();
        //leftdoor = GameObject.FindGameObjectWithTag("left_door").GetComponent<Animator>();
        //rightdoor = GameObject.FindGameObjectWithTag("right_door").GetComponent<Animator>();
    }

    private void Update()
    {
        if (isGamePause && isGameFinished)
        {
            camSpeed = 0;
        }
        else if (transform.position.z < 440)
        {
            camSpeed = 3;
        }
        else
        {
            camSpeed = 5.5f;
        }


        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1 * camSpeed);

        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !isGameOver && !isGamePause && !isGameFinished)
        {
            GameObject ballRigid;
            ballRigid = Instantiate(ball, transform.position, transform.rotation) as GameObject;
            ballCount--;
            Vector3 targetLoc = ray.direction;
            ballRigid.GetComponent<Rigidbody>().AddForce(targetLoc * ballForce);
        }

        BallCountText.text = " " + ballCount;

        if (ballCount == 0)
        {
            GameOverText.gameObject.SetActive(true);
            camSpeed = 0;
            isGameOver = true;
        }
        Debug.Log(Time.time);
    }

    public void RestartGame()
    {
        isGameOver = false;
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void DoorAnim()
    {
        if (passedDoor == 0)
        {
            leftdoor.SetTrigger("doorbutton");
            rightdoor.SetTrigger("doorbutton");
        }
        else
        {
            leftdoor.SetTrigger("doorbutton" + passedDoor);
            rightdoor.SetTrigger("doorbutton" + passedDoor);
        }

        Debug.Log("door is open");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("left_door"))
        {
            ballCount -= 10;

        }

        if (other.gameObject.CompareTag("glassobstacle"))
        {
            ballCount -= 10;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            finishPanel.gameObject.SetActive(true);
            isGameFinished = true;
        }
    }
}
