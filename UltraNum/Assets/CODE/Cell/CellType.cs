using UnityEngine;


public class CellType : MonoBehaviour
{
	public new GameObject gameObject { get; private set; }


	public CellType() { }

	public void CreateCell(GameObject prefab)
	{
		gameObject = Instantiate(prefab);
	}
	
	public void CreateCell(GameObject prefab, Transform parent)
	{
		gameObject = Instantiate(prefab, parent);
	}

	#region GameObject_Copy
	public new Transform transform => gameObject.transform;
	public new string tag
	{
		get => gameObject.tag;
		set => gameObject.tag = value;
	}
	public bool activeSelf => gameObject.activeSelf;
	public bool activeInHierarchy => gameObject.activeInHierarchy;
	public void SetActive(bool value) => gameObject.SetActive(value);
	public new T GetComponent<T>() => gameObject.GetComponent<T>();
	public new Component GetComponent(System.Type type) => gameObject.GetComponent(type);
	public new T GetComponentInChildren<T>() => gameObject.GetComponentInChildren<T>();
	public new Component GetComponentInChildren(System.Type type) => gameObject.GetComponentInChildren(type);
	public new T GetComponentInParent<T>() => gameObject.GetComponentInParent<T>();
	public new Component GetComponentInParent(System.Type type) => gameObject.GetComponentInParent(type);
	public new T[] GetComponents<T>() => gameObject.GetComponents<T>();
	public new Component[] GetComponents(System.Type type) => gameObject.GetComponents(type);
	public new T[] GetComponentsInChildren<T>(bool includeInactive = false) => gameObject.GetComponentsInChildren<T>(includeInactive);
	public new Component[] GetComponentsInChildren(System.Type type, bool includeInactive = false) => gameObject.GetComponentsInChildren(type, includeInactive);
	public new T[] GetComponentsInParent<T>(bool includeInactive = false) => gameObject.GetComponentsInParent<T>(includeInactive);
	public new Component[] GetComponentsInParent(System.Type type, bool includeInactive = false) => gameObject.GetComponentsInParent(type, includeInactive);
	#endregion
}

