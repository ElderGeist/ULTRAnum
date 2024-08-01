#nullable enable
using System;
using System.Collections.Generic;
using UnityEngine;


public partial class Grid : MonoBehaviour
{
	private struct PositionInfo
	{
		public string Name;
		public Vector2 Position;
	}

	private List<CellType> _cellTypes = new List<CellType>();
	public RectTransform CellParent;
	public RectTransform ResultParent;
	public Canvas Canvas;
	public GameObject OperationCellObject;
	public GameObject ResultCellObject;

	public int ROW, COLUMN;

	private const int PixelCellSize = 75;

	private void Start()
	{
		CreateGrid(ROW, COLUMN);
	}
	public void CreateGrid(int row, int col)
	{
		var Offset = new Vector2(Mathf.Floor(row / 2) * PixelCellSize, Mathf.Floor(col / 2) * PixelCellSize);

		var center = Canvas.pixelRect.position;

		PositionInfo positionInfo;

		for (int currentCol = 0; currentCol < col; currentCol++)
		{
			for (int currentRow = 0; currentRow < row; currentRow++)
			{
				positionInfo = new PositionInfo
				{
					Name = $"_{currentCol}_{currentRow}",
					Position = new Vector2(center.x - Offset.x + PixelCellSize * currentRow,
										   center.y + Offset.y + -PixelCellSize * currentCol
										  )
				};

				var createdOperation = CreateAndSetCell<OperationCell>(OperationCellObject, CellParent, positionInfo);

				_cellTypes.Add(createdOperation);

				foreach (var position in GetResultPositions(currentRow, currentCol, createdOperation))
				{
					positionInfo.Position = position;

					var createdResult = CreateAndSetCell<ResultCell>(ResultCellObject, ResultParent, positionInfo);
					_cellTypes.Add(createdResult);

				}


			}

		}
	}

	private IList<Vector2> GetResultPositions(int currentRow, int currentColumn, CellType createdCell)
	{
		List<Vector2> positions = new List<Vector2>();

		Func<Vector2, RectTransform, Vector2> AddX = (v, t) => new Vector2(v.x + t.anchoredPosition.x, t.anchoredPosition.y);
		Func<Vector2, RectTransform, Vector2> AddY = (v, t) => new Vector2(t.anchoredPosition.x, v.y + t.anchoredPosition.y);

		var transform = createdCell.GetComponent<RectTransform>();

		if (currentRow == 0) positions.Add(AddX(Vector2.left * PixelCellSize, transform));
		if (currentColumn == 0) positions.Add(AddY(Vector2.up * PixelCellSize, transform));

		if (currentRow == ROW -1) positions.Add(AddX(Vector2.right * PixelCellSize, transform));
		if (currentColumn == COLUMN - 1) positions.Add(AddY(Vector2.down * PixelCellSize, transform));

		return positions;

	}

	private T CreateAndSetCell<T>(GameObject prefab, Transform parent, PositionInfo info) where T : CellType, new()
	{

		CellType cell = new T();

		cell.CreateCell(prefab, parent);

		RectTransform cellRectTransform = cell.gameObject.GetComponent<RectTransform>();

		cellRectTransform.anchoredPosition = info.Position;

		cell.gameObject.name += info.Name;

		return cell as T;
	}


}

