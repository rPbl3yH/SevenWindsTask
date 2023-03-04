using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellsController : MonoBehaviour
{
    [SerializeField] private CellsConfig _cellsConfig;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private RectTransform _cellsParent;

    public delegate void ColorPickedDelegate(Color color);

    public event ColorPickedDelegate OnColorPicked;

    private List<Cell> _allCells = new();
    private Cell _selectedCell;

    public void Init() {
        GameManager.Instance.ColorsViewController.OnColorViewSelected += ColorsViewController_OnColorViewSelected;

        for (int i = 0; i < _cellsConfig.AvailableColors.Length; i++) {
            var cell = Instantiate(_cellPrefab, _cellsParent);
            cell.Init(_cellsConfig.AvailableColors[i]);
            cell.OnSelected += Cell_OnSelected;
            _allCells.Add(cell);
        }
    }

    private void ColorsViewController_OnColorViewSelected(ColorView colorView) {
        var cell = _allCells.First(c => c.Color == colorView.Color);
        SelectCell(cell, false);
    }

    private void Cell_OnSelected(Cell cell) {
        SelectCell(cell);
    }

    private void SelectCell(Cell cell, bool withEvent = true) {
        _selectedCell?.SetSelection(false);
        _selectedCell = cell;
        _selectedCell.SetSelection(true);
        if (withEvent) {
            OnColorPicked?.Invoke(cell.Color);
        }
    }
}
