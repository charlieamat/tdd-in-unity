using UnityEngine.UI;

namespace Editor.Infrastructure
{
    public class HeartBuilder : TestDataBuilder<Heart>
    {
        private Image _image;

        public HeartBuilder(Image image)
        {
            _image = image;
        }

        public HeartBuilder() : this(An.Image())
        {
        }

        public HeartBuilder With(Image image)
        {
            _image = image;
            return this;
        }

        public override Heart Build()
        {
            return new Heart(_image);
        }
    }
}