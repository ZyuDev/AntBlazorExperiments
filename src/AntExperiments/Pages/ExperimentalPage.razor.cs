using AntDesign;
using AntExperiments.Models;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace AntExperiments.Pages;

public partial class ExperimentalPage: ComponentBase
{
    private int _counter;

    string[] checkedKeys;

    private List<MetaObjectTreeNode> _data;

    protected override void OnInitialized()
    {
        _data = GetData();
        _data.Last().Children.Last().IsChecked = true;
        
        var checkedList = new List<string>();
        checkedList.Add(_data.First().Children.Last().Children.Last().Children.First().Uid.ToString());
        checkedList.Add(_data.Last().Children.Last().Uid.ToString());
        
        checkedKeys = checkedList.ToArray();
    }

    private void OnButtonClicked()
    {
        _counter++;
    }

    private List<MetaObjectTreeNode> GetData()
    {
        return new List<MetaObjectTreeNode>
        {
            new MetaObjectTreeNode
            {
                Name = "1",
                Title = "1",
                IconClass = "smile",
                Children = GetOperationChildren("1")
            },
            new MetaObjectTreeNode
            {
                Name = "2",
                Title = "2",
                IconClass = "glyphicon glyphicon-book mr-1",
                Children = GetChildren("2")
            },
            new MetaObjectTreeNode
            {
                Name = "3",
                Title = "3",
                IconClass = "glyphicon glyphicon-list mr-1",
                Children = GetChildren("3")
            },
            new MetaObjectTreeNode
            {
                Name = "4",
                Title = "4",
                IconClass = "glyphicon glyphicon-cog mr-1",
                Children = GetChildren("4")
            }
        };

        List<MetaObjectTreeNode> GetChildren(string parentName)
        {
            var list = new List<MetaObjectTreeNode>();

            for (int i = 1; i <= 5; i++)
            {
                list.Add(new MetaObjectTreeNode
                {
                    Name = $"{parentName}.{i}",
                    Title = $"{parentName}.{i}",
                    Uid = Guid.NewGuid()
                });
            }

            return list;
        }
        List<MetaObjectTreeNode> GetOperationChildren(string parentName)
        {
            var list = new List<MetaObjectTreeNode>();

            for (int i = 1; i <= 5; i++)
            {
                list.Add(new MetaObjectTreeNode
                {
                    Name = $"{parentName}.{i}",
                    Title = $"{parentName}.{i}",
                    Uid = Guid.NewGuid(),
                    Children = new List<MetaObjectTreeNode>()
                    {
                        new MetaObjectTreeNode
                        {
                            Name = "Header Fields",
                            Title = "Header Fields"
                        },
                        new MetaObjectTreeNode
                        {
                            Name = "Tables",
                            Title = "Tables",
                            Children = new List<MetaObjectTreeNode>
                            {
                                new MetaObjectTreeNode
                                {
                                    Name = $"{parentName}.{i}.1",
                                    Title = $"{parentName}.{i}.1",
                                    Uid= Guid.NewGuid()
                                }
                            }
                        }
                    }
                });
            }

            return list;
        }
    }

    private void ClickBtn()
    {

    }

    private void SetChecked()
    {
        checkedKeys = new List<string> { "abaf0a59-a2b0-4872-a89f-caf3b2e89d63" }.ToArray();
        StateHasChanged();
    }
}