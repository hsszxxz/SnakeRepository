using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace save
{
    ///<summary>
    ///
    ///<summary>
    public class SaveItem : MonoBehaviour
    {
        [HideInInspector]
        public int saveIndex;
        private Image image;
        private Text text;
        private Button button;
        public GameObject selection;
        private void Awake()
        {
            image = GetComponent<Image>();
            text = GetComponentInChildren<Text>();
            button = GetComponent<Button>();
            button.onClick.AddListener(SelectSave);
        }
        public void ItemInit(Sprite sprite,string time,int index)
        {
            image.sprite = sprite;
            text.text = time;
            saveIndex = index;
        }
        private void SelectSave()
        {
            UIManager.Instance.GetUIWindow<SaveUIWindow>().saveIndex = saveIndex;
            foreach (var item in UIManager.Instance.GetUIWindow<SaveUIWindow>().saveItems.Values)
            {
                if (item!=this)
                    item.selection.gameObject.SetActive(false);
            }
            selection.gameObject.SetActive(true);
        }
    }
}

