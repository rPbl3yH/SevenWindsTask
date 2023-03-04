using UnityEngine;

public class CellsController : MonoBehaviour
{
    [SerializeField] private LayerController _layerController;
    [SerializeField] private CellsConfig _cellsConfig;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private RectTransform _cellsParent;

    public delegate void OnClickDelegate(Color color);
    public event OnClickDelegate OnColorPicked;

    private Cell _selectedCell;

    public void Init() {
        for (int i = 0; i < _cellsConfig.AvailableColors.Length; i++) {
            var cell = Instantiate(_cellPrefab, _cellsParent);
            cell.Init(_cellsConfig.AvailableColors[i]);
            cell.OnSelected += Cell_OnSelected;
        }
    }

    private void Cell_OnSelected(Cell cell) {
        _selectedCell?.SetSelect(false);
        _selectedCell = cell;
        _selectedCell.SetSelect(true);
        OnColorPicked?.Invoke(cell.Color);
    }

    private void Start() {
        Init();
    }
}
