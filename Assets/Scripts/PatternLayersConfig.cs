using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = nameof(PatternLayersConfig), menuName = "SevenWinds/" + nameof(PatternLayersConfig))]
public class PatternLayersConfig : ScriptableObject
{
    [field: SerializeField] public Image[] Layers { private set; get; }
}
