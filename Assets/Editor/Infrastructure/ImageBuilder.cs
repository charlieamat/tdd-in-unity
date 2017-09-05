using UnityEngine;
using UnityEngine.UI;

namespace Editor.Infrastructure
{
    public class ImageBuilder : TestDataBuilder<Image>
    {
        private float _fillAmount;

        public ImageBuilder(float fillAmount)
        {
            _fillAmount = fillAmount;
        }

        public ImageBuilder() : this(0)
        {
        }

        public ImageBuilder WithFillAmount(float fillAmount)
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