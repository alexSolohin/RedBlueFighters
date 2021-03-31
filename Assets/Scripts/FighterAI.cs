using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class FighterAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private float attack;

    [Header("Time when fighter stay")]
    [SerializeField] private float startWaitTime;

    private float _health;
    
    private Vector2[] moveSpots;
    private int _randomSpot;
    private int _moveSpotsSize; // size array
    private float _waitTime;    // time between wart to spots
    private bool _toWards;      //ward to target
    private Transform _target;  
    private bool _setTarget;    //set target
    private float _time;        // time between atack
    
    private void Start()
    {
        _health = 100;
        _moveSpotsSize = 10;
        CreateSpotsArr();
        _waitTime = startWaitTime;
        _randomSpot = UnityEngine.Random.Range(0, moveSpots.Length);
        _toWards = false;
        _setTarget = false;
        _time = Time.time;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            moveSpots[_randomSpot], 
            speed * Time.deltaTime);
        FindCircleCollide();
        if (Time.time - _time >= 1f)
        {
            _setTarget = false;
        }
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
        if (_toWards)
        {
            if (_target != null)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    _target.position,
                    speed * Time.deltaTime);
            }
            else
            {
                _toWards = false;
            }
        }
        else
            PatrolSquare();
    }
    
    /// <summary>
    /// Find target using OverlapCircle
    /// </summary>
    private void FindCircleCollide()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, radius);
        if (!_setTarget)
        {
            if (!hitCollider.gameObject.CompareTag(transform.tag))
            {
                _time = Time.time;
                _setTarget = true;
                _target = hitCollider.transform;
                _toWards = true;
                _health -= hitCollider.GetComponent<FighterAI>().attack;
            }
        }
    }
    
    /// <summary>
    /// Patrol zone 
    /// </summary>
    private void PatrolSquare()
    {
        if (Vector2.Distance(transform.position, moveSpots[_randomSpot]) < 0.2f)
        {
            if (_waitTime <= 0)
            {
                _randomSpot = UnityEngine.Random.Range(0, moveSpots.Length);
                _waitTime = startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
    
    /// <summary>
    /// Create array with spots
    /// </summary>
    private void CreateSpotsArr()
    {
        moveSpots = new Vector2[_moveSpotsSize];
        for (int i = 0; i < moveSpots.Length; i++)
        {
            Vector2 spot = new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
            moveSpots[i] = spot;
        } 
    }
    
}
