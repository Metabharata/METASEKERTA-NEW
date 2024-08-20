// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class VictoryManager : MonoBehaviour
// {
//     private BabSatuManager babSatuManager;
//     public GameControler gameController; // Referensi ke GameControler

//     // ...

//     // Method yang dipanggil saat tombol "Selesai Pertarungan" ditekan
//     public void OnSelesaiPertarunganButtonClicked()
//     {
//         if (babSatuManager != null)
//         {
//             babSatuManager.SelesaiPertarungan();
//             gameController.BukaKarakterTerkunci(); // Memanggil method untuk membuka karakter terkunci di GameControler
//         }
//         else
//         {
//             Debug.LogWarning("Referensi BabSatuManager tidak ditemukan.");
//         }
//     }
// }
