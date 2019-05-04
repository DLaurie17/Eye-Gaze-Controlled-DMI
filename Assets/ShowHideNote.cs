using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideNote : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    SpriteRenderer spriteRenderer;
    string noteName;

    public Text noteNameText;

    // Start is called before the first frame update   
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();        
        noteName = gameObject.name.ToString().Remove(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            circleCollider2D.enabled = false;
            spriteRenderer.enabled = false;

            noteNameText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            circleCollider2D.enabled = true;
            spriteRenderer.enabled = true;

            noteNameText.text = noteName;
        }
    }
}
