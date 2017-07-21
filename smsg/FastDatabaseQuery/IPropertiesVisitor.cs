namespace FastDatabaseQuery
{

    public interface IPropertiesVisitor
    {
        string Visited(IReceiveVisitor i);
    }

    public class AllPropertiesVisitorText:AllPropertiesVisitor
    {
        public AllPropertiesVisitorText():base()
        {
            FormatString = "{0}={1};" ;
        }
    }
}