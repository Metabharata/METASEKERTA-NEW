// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class PilihKarakter : MonoBehaviour
// {
//     [SerializeField]
//     private GameObject[] characters;

//     [SerializeField]
//     public Button playerSelectButton; // Tombol pilih karakter pemain

//     [SerializeField]
//     public Button enemySelectButton; // Tombol pilih karakter komputer/musuh

//     private int playerCharacterIndex = -1; // Index karakter untuk pemain (-1 menandakan belum dipilih)
//     private int enemyCharacterIndex = -1;  // Index karakter untuk komputer/musuh (-1 menandakan belum dipilih)

//     private void Start()
//     {
//         playerSelectButton.enabled = true; // Aktifkan tombol pilih karakter pemain
//         enemySelectButton.enabled = false; // Matikan tombol pilih karakter komputer/musuh
//     }

//     private void UpdateCharacterVisibility()
//     {
//         for (int i = 0; i < characters.Length; i++)
//         {
//             characters[i].SetActive(i == playerCharacterIndex || i == enemyCharacterIndex);
//         }
//     }

//     public void ChangePlayerCharacter(int index)
//     {
//         playerCharacterIndex = index;
//         playerSelectButton.enabled = false; // Matikan tombol pilih karakter pemain
//         enemySelectButton.enabled = true; // Aktifkan tombol pilih karakter komputer/musuh
//         UpdateCharacterVisibility();
//     }

//     public void ChangeEnemyCharacter(int index)
//     {
//         enemyCharacterIndex = index;
//         enemySelectButton.enabled = false; // Matikan tombol pilih karakter komputer/musuh
//         UpdateCharacterVisibility();
//     }
// }
