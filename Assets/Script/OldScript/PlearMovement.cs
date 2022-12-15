using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Security.Cryptography.X509Certificates;

public class PlearMovement : MonoBehaviour
{
    #region Variables
    public static bool cursorLocked = true;

    [Header("�վ�t��")]
    public float orgSpeed = 800;
    public float turnSmoothTime = 0.1f;
    public float sprintSpeed;
    public float jumpAmount = 500;

    //public CharacterController controller;
    [Header("���a����")]
    public Transform playerCam;
    public Rigidbody playerRig;

    [Header("���[����")]
    public LayerMask ground;
    public Transform groundDetector;


    private float turnSmoothVelocity;
    private float targetAngle, angle;

    #endregion

    private void Update()
    {
        //Axis
        float vertical = Input.GetAxisRaw("Vertical");//�����C��JS=-1, ��JW=1
        float horizontal = Input.GetAxisRaw("Horizontal");//�����C��JA=-1, ��JD=1
        Vector3 t_direction = new Vector3(horizontal, 0, vertical).normalized;//normalized = ���L�̤j=1�A�קK�P�ɫ�AW���ɭԳt���ܦ��ڸ��G

        //Input
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        updateCursorLock();

        //States
        bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        bool isSprinting = sprint && vertical > 0 && isGrounded;
        bool isJumping = jump && isGrounded;

        if (isJumping)
        {
            playerRig.AddForce(0, jumpAmount, 0);
        }
    }
    void FixedUpdate()
    {
        //Axis
        float vertical = Input.GetAxisRaw("Vertical");//�����C��JS=-1, ��JW=1
        float horizontal = Input.GetAxisRaw("Horizontal");//�����C��JA=-1, ��JD=1
        Vector3 t_direction = new Vector3 (horizontal, 0,vertical).normalized;//normalized = ���L�̤j=1�A�קK�P�ɫ�AW���ɭԳt���ܦ��ڸ��G

        //Input
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKeyDown(KeyCode.Space);

        //States
        bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        bool isSprinting = sprint && vertical > 0;
        bool isJumping = jump && isGrounded;

        if (t_direction.magnitude >= 0.1f)//�p��Vector3�P(0,0,0)���Z���A�]�N�O(x*x+y*y+z*z)�}�ڸ�
        {
            #region �ਤ��
            //Atan2 = https://home.gamer.com.tw/artwork.php?sn=5068016
            targetAngle = Mathf.Atan2(t_direction.x, t_direction.z) * Mathf.Rad2Deg + playerCam.eulerAngles.y;//��ؼШ���+�۾����ס]0~360�^

            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            #endregion

            //move
            Vector3 moveDirection = Quaternion.Euler(0,targetAngle, 0) * Vector3.forward;//�ؼШ������ܬ�Vecter3
            float t_targetSpeed = orgSpeed;
            if (isSprinting)
            {
                t_targetSpeed *= sprintSpeed;
            }
            Vector3 t_targetVelocity = moveDirection.normalized * t_targetSpeed * Time.deltaTime;
            t_targetVelocity.y = playerRig.velocity.y;
            playerRig.velocity = t_targetVelocity;

            /*Vector3 t_targetForce = moveDirection.normalized * Time.deltaTime;
            t_targetForce.y = playerRig.velocity.y;
            playerRig.AddForce(t_targetForce);*/

            //controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }
    }
    void updateCursorLock()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;
            }
        }
    }
}
