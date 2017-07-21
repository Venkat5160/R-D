namespace FastDatabaseQuery
{
    public interface IReceiveVisitor
    {
        string Accept(IPropertiesVisitor visit);

    }

}