using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateLane
{
    None,
    Left,
    Middle,
    Right
}

public class PlayerController : MonoSingleton<PlayerController>
{
    private StateLane _stateLane;

    public Rigidbody player;
    public Animator anim;

    //private float animDuration;
    private bool isMove;
    private Vector3 moveVector;
    public float speedRun;
    public float jumpForce;

    bool isGround;

    private float timer;
    private float timerCountdown;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
        speedRun = 5f;
        jumpForce = 5.5f;
        timer = 2.5f;
        _stateLane = StateLane.Middle;
        Invoke("checkMove", 3f);
    }

    public void checkMove()
    {
        isMove = true;
    }

    public bool CheckGround(Vector3 position)
    {
        isGround = Physics.CheckSphere(position, 0.5f, 1 << 8);
        return isGround;

    }
    void Move(float speed)
    {
        player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Slide()
    {
        anim.SetBool("Sliding", true);
        player.GetComponent<CapsuleCollider>().height = 0.48f;
        Invoke("EndSlide", 1.2f);
    }
    void EndSlide()
    {
        player.GetComponent<CapsuleCollider>().height = 1.13f;
        anim.SetBool("Sliding", false);
    }
    void Jump(float jump)
    {
        player.velocity = Vector3.up * jump;
        anim.SetBool("Jumping", true);
        Invoke("EndJump", 1.2f);
    }
    void EndJump()
    {               
        {
            anim.SetBool("Jumping", false);
        }
    }
    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    checkMove();
        //}
        
        if (isMove)
        {
            
            Move(speedRun);
            timerCountdown += Time.deltaTime;

            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || MobieInput.Instance.Left) && gameObject.transform.position.x > -1)
            {
                //Debug.Log(_stateLane);
                if (_stateLane == StateLane.Middle)
                {
                    gameObject.transform.position = Vector3.Lerp(transform.position ,new Vector3(- 1, player.transform.position.y, player.transform.position.z), speedRun);
                    _stateLane = StateLane.Left;
                    //Debug.Log(_stateLane);
                }
                else if (_stateLane == StateLane.Right)
                {
                    gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(0, player.transform.position.y, player.transform.position.z), speedRun);
                    _stateLane = StateLane.Middle;
                    //Debug.Log(_stateLane);
                }
                
            }
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || MobieInput.Instance.Right) && gameObject.transform.position.x < 1)
            {
                //Debug.Log(_stateLane);
                if (_stateLane == StateLane.Middle)
                {
                    gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(1, player.transform.position.y, player.transform.position.z), speedRun);
                    _stateLane = StateLane.Right;
                    //Debug.Log(_stateLane);
                }
                else if (_stateLane == StateLane.Left)
                {
                    gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(0, player.transform.position.y, player.transform.position.z), speedRun);
                    _stateLane = StateLane.Middle;
                    //Debug.Log(_stateLane);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && CheckGround(gameObject.transform.position) || MobieInput.Instance.Up)
            {
                Jump(jumpForce);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || MobieInput.Instance.Down)
            {
                Slide();
            }
            GameSetting.SCORE += 1;
        }

        MobieInput.Instance.Left = MobieInput.Instance.Right = MobieInput.Instance.Up = MobieInput.Instance.Down = MobieInput.Instance.Tap = false;

        if (timerCountdown > timer)
        {
            speedRun += 0.1f;
            timerCountdown = 0;
        }

    }

    void Dead()
    {
        isMove = false;

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Dead();
            AnimationOther.Instance.ActionAnimation(other.gameObject, "nameAnimation", true);
        }
        else if (other.gameObject.tag == "diamond")
        {
            GameSetting.DIAMOND++;
            AnimationOther.Instance.ActionAnimation(other.gameObject, "NameAnimation", true);
        }
    }


}
