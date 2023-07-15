namespace CarbonNeutral.KernelShared;
public static class ExtendCopyPropertiesTo
{
    public static void CopyPropertiesTo(this object fromObject, object toObject)
    {
        PropertyInfo[] toObjectProperties = toObject.GetType().GetProperties();
        foreach (PropertyInfo propTo in toObjectProperties)
        {
            PropertyInfo? propFrom = fromObject.GetType().GetProperty(propTo.Name);
            if (propFrom?.CanWrite == true && propTo.Name != "Id")
                propTo.SetValue(toObject, propFrom.GetValue(fromObject, null), null);
        }
    }
    public static void CopyPropertiesWithKey(this object fromObject, object toObject)
    {
        PropertyInfo[] toObjectProperties = toObject.GetType().GetProperties();
        foreach (PropertyInfo propTo in toObjectProperties)
        {
            PropertyInfo? propFrom = fromObject.GetType().GetProperty(propTo.Name);
            if (propFrom?.CanWrite == true)
                propTo.SetValue(toObject, propFrom.GetValue(fromObject, null), null);
        }
    }
    public static void CopyPropertiesToNoIds(this object fromObject, object toObject)
    {
        PropertyInfo[] toObjectProperties = toObject.GetType().GetProperties();
        foreach (PropertyInfo propTo in toObjectProperties)
        {
            PropertyInfo? propFrom = fromObject.GetType().GetProperty(propTo.Name);
            if (propFrom?.CanWrite == true && !propTo.Name.EndsWith("Id"))
                propTo.SetValue(toObject, propFrom.GetValue(fromObject, null), null);
        }
    }
}