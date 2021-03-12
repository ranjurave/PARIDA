using UnityEngine;
using UnityEngine.UI;

public class CategorySelector : MonoBehaviour
{
    public Button CategoryButton;
    public Category category;

    void Start() {
        CategoryButton.onClick.AddListener(SelectCategory);
    }

    void SelectCategory() {
        MenuManager.Instance.selectedCategory = category;
    }

}
