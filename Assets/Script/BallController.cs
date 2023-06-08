using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Parameter")]
    public float speed = 5f; // Vitesse de déplacement horizontal de la balle
    public float fallSpeed = 2f; // Vitesse de chute de la balle
    public float gravityScale = 1f; // Échelle de gravité personnalisée

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
        rb.gravityScale = gravityScale; // Applique l'échelle de gravité personnalisée
        ChangeColor();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Récupère l'entrée horizontale (axe X)

        Vector2 movement = new Vector2(moveHorizontal * speed, -fallSpeed); // Crée un vecteur de mouvement en fonction de l'entrée

        rb.velocity = movement; // Applique la vitesse de déplacement à la balle
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
