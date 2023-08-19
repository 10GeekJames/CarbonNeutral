namespace CarbonNeutral.KernelShared;
public abstract class BaseEntityTracked<T>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public T Id { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public List<BaseDomainEvent>? Events = new List<BaseDomainEvent>();

    private List<PropertyInfo>? properties;
    private List<FieldInfo>? fields;

    /* public override string ToString()
    {
        var props = GetProperties();
        var buffOut = new StringBuilder(props.Count());
        foreach (var prop in props)
        {
            buffOut.Append(prop?.GetValue(this, null)?.ToString()).Append(' ');
        }

        return buffOut.ToString();
    } */

    public IEnumerable<PropertyInfo> GetProperties()
    {
        return this.properties ??= GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                .ToList();
    }

    public IEnumerable<PropertyInfo> GetPropertiesNoId()
    {
        return this.properties ??= GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null 
                    && p.Name != "Id")
                .ToList();
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        return this.fields ??= GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                .ToList();
    }

    public override int GetHashCode()
    {
        unchecked   //allow overflow
        {
            int hash = 17;
            foreach (var prop in GetProperties())
            {
                var value = prop.GetValue(this, null);
                hash = HashValue(hash, value!);
            }

            foreach (var field in GetFields())
            {
                var value = field.GetValue(this);
                hash = HashValue(hash, value!);
            }

            return hash;
        }
    }

    private int HashValue(int seed, object value)
    {
        var currentHash = value != null
            ? value.GetHashCode()
            : 0;

        return seed * 23 + currentHash;
    }
}
