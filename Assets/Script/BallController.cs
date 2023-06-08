using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Parameter")]
    public float speed = 5f; 
    public float fallSpeed = 2f; 
    public float gravityScale = 1f; 

    [Space(10)]
    [Header("Bool")]
    public bool Red;
    public bool Bleu;
    public bool Green;

    [Space(10)]
    [Header("Graphic")]
    public SpriteRenderer sprite;
    public Sprite[] spritcolor;

    private int colorIndex;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale; 
        ChangeColor();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 

        Vector2 movement = new Vector2(moveHorizontal * speed, -fallSpeed); 

        rb.velocity = movement;
    }

    void ChangeColor()
    {
        colorIndex = Random.Range(1,4);

        if(colorIndex ==1)
        {
            Red = true;
            sprite.sprite = spritcolor[0];
        }
        else if(colorIndex ==2)
        {
            Bleu = true;
            sprite.sprite = spritcolor[1];

        }
        else if(colorIndex==3)
        {
            Green = true;
            sprite.sprite = spritcolor[2];

        }
    }
}
