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
    private CharacterController charCtrl;
    Animator m_Animator;
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator> ();
        GameStatic.CharGameObject = gameObject;
    }

    // Update is called once per frame
    
    private void Awake()
    {
        TileDestroy.player = GetComponent<Transform>();
        GameStatic.CharGameObject = gameObject;
        m_Animator = GetComponent<Animator> ();
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

        if (turnLeft)
        {
            transform.Rotate(new Vector3(0, -90f, 0));
        }else if (turnRight)
        {
            transform.Rotate(new Vector3(0, 90f, 0));

        }

        if (Input.GetKeyDown("space"))
        {
            //Jump();
            
            m_Animator.SetBool("jump",true);
            //charCtrl.Move(transform.up * Speed *5* Time.deltaTime);
            Drop();
        }
        else if (Input.GetKeyDown("s"))
        {
            m_Animator.SetBool("slide",true);
        }
        
        charCtrl.SimpleMove(new Vector3(0, 0, 0));
        charCtrl.Move(transform.forward * Speed * Time.deltaTime);
    }

    
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject,3);
        GameStatic.spawn.DecreaseTile();
    }
    public void Die()
    {
        alive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        onAir = true;
        charCtrl.Move(transform.up * Speed *3* Time.deltaTime);
        //charCtrl.Move(velocity * Time.deltaTime);
    }

    private void Drop()
    {
        velocity.y = 0;
        if (charCtrl.isGrounded)
        {
            
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
