using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 velocity=new Vector3(0,-1,0);
    [SerializeField] private float jumpforce = 7.0f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float Speed = 7.0f;
    private bool turnLeft = false;
    private bool turnRight = false;
    private bool alive = true;
    private bool onAir = false;
    private bool canStart = false;
    private CharacterController charCtrl;
    Animator m_Animator;
    public Animator e_Animator;
    public GameObject enemy;
    public GameObject deathUI;
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator> ();
        GameStatic.CharGameObject = gameObject;
    }

    // Update is called once per frame
    
    private void Awake()
    {
        //TileDestroy.player = GetComponent<Transform>();
        //GameStatic.CharGameObject = gameObject;
        //m_Animator = GetComponent<Animator> ();
    }
    void Update()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("isWalking", isWalking);
        if (!alive) return;
        if (transform.position.y < 10)
        {
            Die();
        }
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            m_Animator.SetBool("start",true);
            canStart = true;
        }
        if (turnLeft)
        {
            transform.Rotate(new Vector3(0, -90f, 0));
        }else if (turnRight)
        {
            transform.Rotate(new Vector3(0, 90f, 0));

        }

        if (Input.GetKeyDown("space")&&!m_Animator.GetBool("jump"))
        {
            //Jump();
            if (!m_Animator.GetBool("jump"))
            {
                m_Animator.SetBool("jump",true);
                //charCtrl.Move(transform.up * Speed *5* Time.deltaTime);
                //Drop();
            }
            
            
            Drop();
        }
        else if (Input.GetKeyDown("s"))
        {
            m_Animator.SetBool("slide",true);
        }
        
        
        charCtrl.SimpleMove(new Vector3(0, 0, 0));

        if (canStart)
        {
            charCtrl.Move(transform.forward * Speed * Time.deltaTime);
        }
        
    }

    
    void OnTriggerExit(Collider other)
    {
        
        Destroy(other.gameObject,3);
        //GameStatic.spawn.DecreaseTile();
        //GameStatic.spawn.thisTileAmount-=1;
        Spawn.thisTileAmount -= 1;
        
    }
    public void Die()
    {
        alive = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathUI.SetActive(true);
        Time.timeScale = 0f;
        
    }
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "obstacle")
        {
            e_Animator.SetBool("canAttack",true);
            
            m_Animator.SetBool("end",true);
            canStart = false;
            enemy.transform.position = transform.position-new Vector3(1,0,1);
            e_Animator.SetBool("canAttack",true);
        }

        if (col.gameObject.tag == "coin")
        {
            Debug.Log("lose");
            Destroy(col.gameObject);
            GameManager.inst.IncreaseScore();
        }
           
    }

    void cancelMove(string AniName)
    {
        m_Animator.SetBool(AniName,false);
    }

    private void Jump()
    {
        
        
        
        // if (charCtrl.isGrounded)
        // {
        //     
        //     charCtrl.Move(velocity * Time.deltaTime);
        //     velocity.y = jumpforce*25;
        //    
        //     
        // }
        // else
        // {
        //     velocity.y -= gravity * -2f * Time.deltaTime;
        // }
        onAir = false;
        Debug.Log("jump");
        charCtrl.Move(transform.up * Speed *4* Time.deltaTime);
        //charCtrl.Move(velocity * Time.deltaTime);
    }

    private void Drop()
    {
        velocity.y = 0;
        if (charCtrl.isGrounded)
        {
            onAir = true;
            // charCtrl.Move(velocity * Time.deltaTime);
            // velocity.y = jumpforce*25;
            //

        }
        else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
            charCtrl.Move(velocity * Time.deltaTime);
        }
    }
}
