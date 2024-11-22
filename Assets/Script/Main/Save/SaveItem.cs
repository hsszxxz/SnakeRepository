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
        private Image image
        {
            get
            {
                return GetComponent<Image>();
            }
        }
        private Text text
        {
            get
            {
                return GetComponentInChildren<Text>();
            }
        }
        private Button button;
        public GameObject selection;
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SelectSave);
        }
        public void ItemInit(Sprite sprite,string time,int index)
        {
            image.sprite = sprite;
            text.text = time;
            saveIndex = index;
        }
        public void SelectSave()
        {
            UIManager.Instance.GetUIWindow<SaveUIWindow>().saveItem = this;
            foreach (var item in UIManager.Instance.GetUIWindow<SaveUIWindow>().saveItems.Values)
            {
                if (item!=this)
                    item.selection.gameObject.SetActive(false);
            }
            selection.gameObject.SetActive(true);
        }
    }
}

