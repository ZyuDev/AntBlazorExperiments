namespace Company.WebApplication1.Models;

public class RightsPageViewModel
{
    public List<RightsRow> Rights { get; set; } = new List<RightsRow>();

   

    public RightsRow AddRow(string objectName)
    {
        var newRow = new RightsRow()
        {
            ObjectName = objectName
        };
        
        Rights.Add(newRow);

        return newRow;
    }

    public void RemoveRow(RightsRow row)
    {
        Rights.Remove(row);
    }

    public void CheckAll()
    {
        foreach (var row in Rights)
        {
            row.SetFlags(true);
        }
    }
    
    public void UnCheckAll()
    {
        foreach (var row in Rights)
        {
            row.SetFlags(false);
        }
    }

    public void ColumnCheck(int flagIndex)
    {
        foreach (var row in Rights)
        {
            switch (flagIndex)
            {
                case 1:
                    row.AllowRead = true;
                    break;
            }
        }
    }
    
    public void ColumnUnCheck(int flagIndex)
    {
        foreach (var row in Rights)
        {
            switch (flagIndex)
            {
                case 1:
                    row.AllowRead = false;
                    break;
            }
        }
    }

    public void Init(int max)
    {
        for (var i = 1; i <= max; i++)
        {
            AddRow($"Object {i}");
        }
    }
}