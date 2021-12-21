using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float jumpforce = 7.0f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float Speed = 7.0f;
    private bool turnLeft = false;
    private bool turnRight = false;
    private bool alive = true;
    private CharacterController charCtrl;
    Animator m_Animator;
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    
    private void Awake()
    {
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
        if (transform.position.y < -10)
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
            m_Animator.SetBool("jump",true);
        }
        else if (Input.GetKeyDown("s"))
        {
            m_Animator.SetBool("slide",true);
        }

        charCtrl.SimpleMove(new Vector3(0, 0, 0));
        charCtrl.Move(transform.forward * Speed * Time.deltaTime);
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
}
