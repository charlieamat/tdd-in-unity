namespace Editor.Infrastructure
{
    public abstract class TestDataBuilder<T>
    {
        public abstract T Build();

        public static implicit operator T(TestDataBuilder<T> builder)
        {
            return builder.Build();
        }
    }
}