// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ComboAttackManager : MonoBehaviour
// {

//     private enum ComboState
//     {
//         None,
//         Pukul,
//         Senjata
//     }

//     private CharacterAnimation myAnim;
//     private bool activateTimeToReset;
//     private float defaultComboTimer = 0.5f;
//     private float currentComboTimer;
//     private ComboState currentComboState;

//     private void Update()
//     {
//         if (activateTimeToReset)
//         {
//             currentComboTimer -= Time.deltaTime;
//             if (currentComboTimer <= 0)
//             {
//                 currentComboState = ComboState.None;
//                 activateTimeToReset = false;
//             }
//         }
//     }

//     public void PukulButtonClicked()
//     {
//         if (currentComboState == ComboState.Pukul || currentComboState == ComboState.Senjata)
//         {
//             return;
//         }

//         currentComboState++;
//         activateTimeToReset = true;
//         currentComboTimer = defaultComboTimer;

//         if (currentComboState == ComboState.Pukul)
//         {
//             myAnim.Pukul();
//         }
//         else if (currentComboState == ComboState.Senjata)
//         {
//             myAnim.Senjata();
//         }
//     }

//     public void SenjataButtonClicked()
//     {
//         if (currentComboState == ComboState.Pukul || currentComboState == ComboState.Senjata)
//         {
//             return;
//         }

//         currentComboState = ComboState.Senjata;
//         activateTimeToReset = true;
//         currentComboTimer = defaultComboTimer;

//         myAnim.Senjata();

//     }


// }
