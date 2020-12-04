using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject winScreen;
    private SpriteRenderer orangesr;

    public float speed = 100;
    public float winWaitTime = 1f;
    public float axisLimit = 1f;
    private float winTime;

    // Start is called before the first frame update
    void Start()
    {
        orangesr = winScreen.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.localRotation.z) >= 0.9997)
        {
            if (winTime == 0)
            {
                winTime = Time.time;
            } else if (Time.time - winTime >= winWaitTime)
            {
                orangesr.enabled = true;
                Invoke("nextScene", 1f);
            }
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if(Input.GetMouseButton(0) && Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width)
        {

            float turnAmount = Mathf.Min(1,Mathf.Max(-1,Input.GetAxis("Mouse X")));
            transform.Rotate(new Vector3(0, 0, -turnAmount) * Time.deltaTime * speed);
        }
    }

    void nextScene()
    {
        SceneManager.LoadScene(1);
    }
}
