using UnityEngine;
using UnityEngine.UI;

namespace Editor.Infrastructure
{
    public class ImageBuilder : TestDataBuilder<Image>
    {
        private int _fillAmount;

        public ImageBuilder(int fillAmount)
        {
            _fillAmount = fillAmount;
        }

        public ImageBuilder() : this(0)
        {
        }

        public ImageBuilder WithFillAmount(int fillAmount)
        {
            _fillAmount = fillAmount;
            return this;
        }

        public override Image Build()
        {
            var image = new GameObject().AddComponent<Image>();
            image.fillAmount = _fillAmount;
            return image;
        }
    }
}