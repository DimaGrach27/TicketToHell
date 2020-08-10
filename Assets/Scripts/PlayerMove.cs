using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;         //Даем возможность использоваьть компонент Rigidbody2D
    SpriteRenderer sprite;  //Даем возможность использоваьть компонент SpriteRenderer
    Animator anim;          //Даем возможность использоваьть компонент Animator
    public float Speed = 12.0f;   
    public float jumpForce = 7f;
    public float rayCast = 1.35f;

    public LayerMask whatIsGround;   //Публично выбираем какой слой будет считывать
    public LayerMask whatIsEnemy;    //Публично выбираем какой слой будет считывать
    public GameObject fireBall;     //Публично выбираем игровой обьект
    public Transform castPoint;     //Публично выбираем трансформ игрового обьекта
    [SerializeField]
    GameObject hitBox;
    public AudioSource castFireBall;    //Даем возможность публично использоваьть компонент AudioSource
    public AudioSource swordArrack;     //Даем возможность публично использоваьть компонент AudioSource

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();           //присваиваем параметру rb компонент Rigidbody2D
        sprite = GetComponent<SpriteRenderer>();    //присваиваем параметру sprite компонент SpriteRenderer
        anim = GetComponent<Animator>();            //присваиваем параметру anim компонент Animator

        hitBox.SetActive(false);        //делаем обьект hitBox неактивным
    }

    void FixedUpdate()   /// срабатывает каждые 0.2 с,  используется для обработки физики
    {
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, rayCast, whatIsGround); ///Рисует луч под персонажа
        if (Input.GetKeyDown(KeyCode.Space) && ground.collider != null) ///Персонаж прыгает если стоит на земеле и нажат пробел
            jump(); ///Вызывает прижок
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y); ///Двигает персонажа по горизонтали с помощью клавиш движения
        Flip(); ///Вызывает поворот персонажа
    }

    private void Update()  //срабатывает каждый кадр
    {
        if (Input.GetAxis("Horizontal") == 0)
            anim.SetInteger("Idle", 0);
        else
            anim.SetInteger("Idle", 1);

        if (Input.GetKeyDown(KeyCode.Q))
            CastFireBall();

        if (Input.GetKeyDown(KeyCode.V))
            StartCoroutine(MelleAttack());
    }

    void jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); ///Прикладывает силу к Ridgidbody2D что дает возможность персонажу прыгать
    }
    void Flip() /// Поворачивает спрайт персонажа на 180 градусов
    {
        if (Input.GetAxis("Horizontal") < 0)
            sprite.flipX = true;
        //transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if
            (Input.GetAxis("Horizontal") > 0)
            //  transform.localRotation = Quaternion.Euler(0, 0, 0);
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

    void CastFireBall()
    {
        castFireBall.Play();
        anim.SetTrigger("CastFireBall");
        Instantiate(fireBall, castPoint.position, castPoint.rotation);
    }

    IEnumerator MelleAttack()
    {
        /* RaycastHit2D meleatacck = Physics2D.Raycast(castPoint.position, Vector2.right, 0.5f, whatIsEnemy);
         Debug.DrawRay(castPoint.position, Vector2.right, Color.red, 0.5f);
         if(meleatacck.collider != null)
         {
             Enemy enemt = new Enemy();
             enemt.TakeDamage(1);
         }*/
        swordArrack.Play();
        hitBox.SetActive(true);    
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        hitBox.SetActive(false);

    }
}
