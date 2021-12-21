using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    [SerializeField] private int itemCount = 5;
    [SerializeField] private Upgrade itemPrefab; //From Unity cookbook for O'Reilly!
    [SerializeField] private RectTransform itemContainer;

    void Start()
    {
        for (int i = 0; i < itemCount; i++)
        {
            var label = string.Format("Item {0}", i);
            CreateNewUpgrade(label);
        }
    }

    public void CreateNewUpgrade(string label)
    {
        var newItem = Instantiate(itemPrefab);
        newItem.transform.SetParent(
            itemContainer,
            worldPositionStays:false);

        newItem.Label = label;
    }
}
