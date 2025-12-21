using UnityEngine;

[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string objectName;
    public bool isCuttable;
    public int maxCutsRequired;
    public bool isCookable;
}
