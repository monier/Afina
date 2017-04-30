namespace Afina.DataAccess.AdoNet.Instrumentations
{
    public interface IDbValueMapper
    {
        object MapToDb(object value);
        object MapFromDb(object value);
    }
}
