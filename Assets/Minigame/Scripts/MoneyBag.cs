using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private GameObject _coin;
    void Start()
    {
        _animator = GetComponent<Animator>();   
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            _animator.SetBool("playerAttacking", true);
            Destroy(this.gameObject, 3);
            InstantiateCoin();
        }
    }
    void InstantiateCoin()
    {
        Instantiate(_coin, transform.position, Quaternion.identity);
    }

}
