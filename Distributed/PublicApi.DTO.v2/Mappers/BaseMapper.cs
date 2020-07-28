namespace PublicApi.DTO.v2.Mappers
{
    public abstract class BaseMapper<TLeftObject, TRightObject> : ee.itcollege.sisavi.DAL.Base.Mappers.BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
    }
}