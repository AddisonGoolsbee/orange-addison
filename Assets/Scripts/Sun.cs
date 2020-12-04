using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public bool sunClicked;
    public GameObject screenCover;
    private SpriteRenderer cover;

    // Start is called before the first frame update
    void Start()
    {
        cover = screenCover.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            cover.enabled = true;
            Destroy(gameObject);
        }
    }
}
