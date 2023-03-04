using UnityEngine;
using UnityEngine.UI;

public class PatternLayer : MonoBehaviour
{
    [field: SerializeField] public Image[] ImageLayers { private set; get; }

    public void Init() {
        
    }

    public void SetView(bool isView) {
        foreach (var layer in ImageLayers) {
            layer.gameObject.SetActive(isView);
        }
    }
}
