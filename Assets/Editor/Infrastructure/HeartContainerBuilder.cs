using System.Collections.Generic;
using System.Linq;

namespace Editor.Infrastructure
{
    public class HeartContainerBuilder : TestDataBuilder<HeartContainer>
    {
        private List<Heart> _hearts;

        public HeartContainerBuilder(List<Heart> hearts)
        {
            _hearts = hearts;
        }

        public HeartContainerBuilder() : this(new List<Heart>())
        {
        }

        public HeartContainerBuilder With(params Heart[] hearts)
        {
            _hearts = hearts.ToList();
            return this;
        }

        public override HeartContainer Build()
        {
            return new HeartContainer(_hearts);
        }
    }
}