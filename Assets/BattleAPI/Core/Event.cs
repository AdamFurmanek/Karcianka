namespace Card
{
    interface Event<T> : IEvent<T>
    {
        T Activate(BaseMatch match);
    }
}
