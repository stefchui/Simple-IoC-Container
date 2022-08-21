namespace IoC.Container
{
    public interface ISimpleContainer
    {
        public void Register<TService, TImpl>() 
            where TImpl : TService;
        public object Resolve<TClient>() 
            where TClient: class;
    }
}
