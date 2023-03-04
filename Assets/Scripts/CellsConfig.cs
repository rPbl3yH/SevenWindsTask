using UnityEngine;

[CreateAssetMenu(fileName = nameof(CellsConfig), menuName = "SevenWinds/" + nameof(CellsConfig))]
public class CellsConfig : ScriptableObject
{
    [field: SerializeField] public Color[] AvailableColors { get; private set; }
}
