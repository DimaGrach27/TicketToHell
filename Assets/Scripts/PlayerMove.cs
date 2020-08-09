using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    public float Speed = 12.0f;
    public float jumpForce = 7f;
    public float rayCast = 1.35f;
    public LayerMask whatIsGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, rayCast, whatIsGround); ///Рисует луч под персонажа
        if (Input.GetKeyDown(KeyCode.Space) && ground.collider != null) ///Персонаж прыгает если стоит на земеле и нажат пробел
            jump(); ///Вызывает прижок
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y); ///Двигает персонажа по горизонтали с помощью клавиш движения
        Flip(); ///Вызывает поворот персонажа
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") == 0)
            anim.SetInteger("Idle", 0);
        else
            anim.SetInteger("Idle", 1);
    }

    void jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); ///Прикладывает силу к Ridgidbody2D что дает возможность персонажу прыгать
    }
    void Flip() /// Поворачивает спрайт персонажа на 180 градусов
    {
        if (Input.GetAxis("Horizontal") < 0) 
            sprite.flipX = true;
        else if 
            (Input.GetAxis("Horizontal") > 0) 
            sprite.flipX = false;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Teleport");
            GameControl.finishLevel = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            anim.SetTrigger("Teleport");
            GameControl.death = true;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.name.Equals("MovingPlatform") || collision.gameObject.name.Equals("Ship"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("MovingPlatform") || collision.gameObject.name.Equals("Ship"))
        {
            this.transform.parent = null;
        }
    }
}
