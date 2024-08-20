using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private GameObject playerControllerObject;
    private GameObject playerAttackObject;

    private PlayerController playerController;
    private PlayerAttack playerAttack;

    private void Start()
    {
        playerController = playerControllerObject.GetComponent<PlayerController>();
        playerAttack = playerAttackObject.GetComponent<PlayerAttack>();
    }

    public void OnPukulButtonClicked()
    {
        playerAttack.PukulButtonClicked(); // Panggil metode Pukul pada PlayerController
    }

    public void OnSenjataButtonClicked()
    {
        playerAttack.SenjataButtonClicked(); // Panggil metode Senjata pada PlayerController
    }

    public void OnJumpButtonClicked()
    {
        playerController.Jump(); // Panggil metode Jump pada PlayerController
    }

    public void OnKananButtonClicked()
    {
        playerController.MoveRight(); // Panggil metode MoveRight pada PlayerController
    }

    public void OnKiriButtonClicked()
    {
        playerController.MoveLeft(); // Panggil metode MoveLeft pada PlayerController
    }

    public void OnStopButtonClicked()
    {
        playerController.StopMoving(); // Panggil metode StopMoving pada PlayerController
    }
}
