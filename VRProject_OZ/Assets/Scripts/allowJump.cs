using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allowJump : MonoBehaviour
{
    public PlayerMovement _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _playerMovement.isJumping = false;
        }
    }
}
