using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class IT_UfoMove : B_Entities
{
    [SerializeField] private float speed = 1;
    [SerializeField] private int plusScore = 0;
    private Vector2 moveDir = Vector2.right;
    [SerializeField] private LayerMask blockLayer;
    [HideInInspector] public GameManager gameManager;

    public override void Hit(int damage = 0)
    {
        gameManager.Score += plusScore;
        health += damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (_freezeState != E_FreezeState.FreezeY)
            return;
            
        if (WallCheck())
        {
            moveDir *= -1;
        }
        transform.Translate(GameTime.Instance.GameRunTime * speed * Time.deltaTime * moveDir);
    }

    private bool WallCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, 0.5f, blockLayer);
        return hit;
    }
}
