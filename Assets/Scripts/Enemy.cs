using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform sla;
    public Transform sla2;
    public float moveSpeed = 3f;
    private Animator animator;

    private Rigidbody2D rb;
    private Transform currentTarget;
    private Vector3 scale;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTarget = sla;
        scale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();

    }

    private void MoveTowardsTarget()
    {
        Vector3 curTargetHorizontal = new Vector2(currentTarget.position.x, transform.position.y);
        Vector2 direction = (curTargetHorizontal - transform.position).normalized;

        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        if (Vector2.Distance(curTargetHorizontal, transform.position) <= 0.2f)
        {
            SwitchTarget();
        }
    }

    private void SwitchTarget()
    {
        if (currentTarget == sla)
        {
            currentTarget = sla2;
        }
        else
        {
            currentTarget = sla;
            transform.localScale = scale;

        }
    }
    
}