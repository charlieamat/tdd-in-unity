namespace Editor.Infrastructure
{
    public static class A
    {
        public static HeartBuilder Heart()
        {
            return new HeartBuilder();
        }

        public static HeartContainerBuilder HeartContainer()
        {
            return new HeartContainerBuilder();
        }
    }
}