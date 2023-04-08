namespace Company.WebApplication1.Models;

public class RightsRow
{
    public string ObjectName { get; set; } = string.Empty;
    public bool AllowRead { get; set; }
    public bool AllowInsert { get; set; }
    public bool AllowUpdate { get; set; }
    public bool AllowDelete { get; set; }
    public bool AllowAttachedFiles { get; set; }

    public void SetFlags(bool flag)
    {
        AllowRead = flag;
        AllowUpdate = flag;
        AllowInsert = flag;
        AllowDelete = flag;
        AllowAttachedFiles = flag;
    }
}