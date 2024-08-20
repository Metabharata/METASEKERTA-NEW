using UnityEngine;

[CreateAssetMenu(fileName = "New Battle Data", menuName = "Battle Data")]
public class BattleData : ScriptableObject
{
    public GameObject selectedPlayerCharacter;
    public GameObject selectedEnemyCharacter;
    public GameObject selectedArena;
}
