using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public GameObject background2, winScreen;

    public float speed = 100;
    public float winWaitTime = 1f;
    public float axisLimit = 1f;
    private float winTime;
    private bool checkLeft = false, checkRight = false;
    private SpriteRenderer b2, orangesr;

    // Start is called before the first frame update
    void Start()
    {
        b2 = background2.GetComponent<SpriteRenderer>();
        orangesr = winScreen.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (b2.enabled && Mathf.Abs(transform.localRotation.z) >= 0.9997)
        {
            if (winTime == 0)
            {
                winTime = Time.time;
            } else if (Time.time - winTime >= winWaitTime)
            {
                orangesr.enabled = true;
                Invoke("nextScene", 1f);
            }
            background2.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if(Input.GetMouseButton(0) && Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width)
        {

            float turnAmount = Mathf.Min(1,Mathf.Max(-1,Input.GetAxis("Mouse X")));
            if(!b2.enabled && transform.localRotation.z < -0.708 && turnAmount > 0)
            {
                //transform.rotation = Quaternion.Euler(0, 0, 270);
                checkLeft = true;
            }else if(!b2.enabled && transform.localRotation.z > 0.708 && turnAmount < 0){
                //transform.rotation = Quaternion.Euler(0, 0, 90);
                checkRight = true;
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -turnAmount) * Time.deltaTime * speed);
                background2.transform.Rotate(new Vector3(0, 0, -turnAmount) * Time.deltaTime * speed);
            }
        
        }

        if(checkRight && checkLeft && Mathf.Abs(transform.localRotation.z) <= 0.1)
        {
            b2.enabled = true;
        }
    }

    void nextScene()
    {
        SceneManager.LoadScene(2);
    }
}
