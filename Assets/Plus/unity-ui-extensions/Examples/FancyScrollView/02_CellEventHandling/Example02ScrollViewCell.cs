﻿namespace UnityEngine.UI.Extensions.Examples
{
    public class Example02ScrollViewCell
        : FancyScrollViewCell<Example02CellDto, Example02ScrollViewContext>
    {
        [SerializeField]
        Animator animator;
        [SerializeField]
        Text message;
        [SerializeField]
        Image image;
        [SerializeField]
        Button button;

        readonly int scrollTriggerHash = Animator.StringToHash("scroll");
        Example02ScrollViewContext context;
        int lastIndex;

        void Start()
        {
            var rectTransform = transform as RectTransform;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchoredPosition3D = Vector3.zero;
            UpdatePosition(0);

            button.onClick.AddListener(OnPressedCell);
        }

        /// <summary>
        /// コンテキストを設定します
        /// </summary>
        /// <param name="context"></param>
        public override void SetContext(Example02ScrollViewContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// セルの内容を更新します
        /// </summary>
        /// <param name="itemData"></param>
        public override void UpdateContent(Example02CellDto itemData)
        {
            message.text = itemData.Message;

            if (context != null)
            {
                var isSelected = context.SelectedIndex == DataIndex;
               
                image.color = isSelected
                    ? new Color32(0, 255, 255, 100)
                    : new Color32(255, 255, 255, 77);
            }
        }

        /// <summary>
        /// セルの位置を更新します
        /// </summary>
        /// <param name="position"></param>
        public override void UpdatePosition(float position)
        {
            animator.Play(scrollTriggerHash, -1, position);
            animator.speed = 0;
        }

        public void OnPressedCell()
        {
            if (context != null)
            {
                context.OnPressedCell(this);
                var isSelected = context.SelectedIndex == DataIndex;
              
                bool isTwice = lastIndex == DataIndex;
                
                if (isSelected && isTwice)
                {
                    print("被选中");
                  
                }
                else if(isSelected)
                {
                    
                }
                lastIndex = DataIndex;

            }
        }
    }
}
