using UnityEngine;
using UnityEngine.UI;

public class PatternLayer : MonoBehaviour
{
    [field: SerializeField] public Image[] ImageLayers { private set; get; }

    public void SetView(bool isView) {
        gameObject.SetActive(isView);
    }
}
