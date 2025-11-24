using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerMovement>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("PlayerMovement");
                    instance = instanceContainer.AddComponent<PlayerMovement>();
                }
            }
            return instance;
        }
    }
    private static PlayerMovement instance;

    Rigidbody rb;
    public float moveSpeed = 5f;
    public Animator Anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector3 input = JoyStickMovement.Instance.joyVec;

        // �Է� ���� ��
        if (input.sqrMagnitude < 0.001f)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        // �̵� ó��
        Vector3 moveDir = new Vector3(input.x, 0, input.y);
        rb.linearVelocity = moveDir * moveSpeed;

        // ȸ�� ó�� (DOTween)
        // ���� ȸ�� Tween�� �����ִٸ� ����
        transform.DOKill();

        transform.DOLookAt(transform.position + moveDir, 0.15f)
                 .SetEase(Ease.OutQuad);
    }
}
