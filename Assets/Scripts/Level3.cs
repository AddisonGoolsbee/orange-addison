using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    public GameObject screenCover;
    public GameObject sun;
    public GameObject winScreen;

    public float speed = 100;
    public float winWaitTime = 1f;
    public float axisLimit = 1f;
    private float timer, winTimer;
    private bool win;
    private SpriteRenderer cover, orangesr;



    // Start is called before the first frame update
    void Start()
    {
        cover = screenCover.GetComponent<SpriteRenderer>();
        orangesr = winScreen.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(transform.localRotation.z);
        if (win)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45.8f);
            if(Time.time-winTimer >= winWaitTime)
            {
                orangesr.enabled = true;
            }
        } else if (cover.enabled && Mathf.Abs(transform.localRotation.z) >= 0.38 && Mathf.Abs(transform.localRotation.z) <= 0.395)
        {
            if (Time.time - timer >= winWaitTime)
            {
                win = true;
            }
            winTimer = Time.time;
        } else
        {
            timer = Time.time;
        }
        if (Input.GetMouseButton(0) && Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width)
        {

            float turnAmount = Mathf.Min(1,Mathf.Max(-1,Input.GetAxis("Mouse X")));
            transform.Rotate(new Vector3(0, 0, -turnAmount) * Time.deltaTime * speed);
        }
    }

}
