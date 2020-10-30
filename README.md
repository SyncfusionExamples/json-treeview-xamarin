# How to bind JSON data to Xamarin.Forms TreeView (SfTreeView)

You can bind the data from [JSON](http://www.json.org/) (JavaScript Object Notation) file to the Xamarin forms [SfTreeView](https://help.syncfusion.com/xamarin/treeview/getting-started?) using [ItemSource](https://help.syncfusion.com/cr/xamarin/Syncfusion.XForms.TreeView.SfTreeView.html?_ga=2.169034657.1409646585.1603702470-522025424.1599212225#Syncfusion_XForms_TreeView_SfTreeView_ItemsSource) property.

You can also refer our article from Syncfusion KnowledgeBase

https://www.syncfusion.com/kb/12002/how-to-bind-json-data-to-xamarin-forms-treeview-sftreeview

**STEP 1:** Create a JSON data model

``` c#
public class Cities
{
    public string Name { get; set; }
}

public class States
{
    public List<Cities> Cities { get; set; }
    public string Name { get; set; }
}

public class Countries
{
    public List<States> States { get; set; }
    public string Name { get; set; }
}
``` c#
**STEP 2:** Accessed the JSON file from local folder and use [StreamReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netcore-3.1) to reads the data and return as a ObservableCollection property.

``` c#
private void GenerateSource()
{
    var assembly = typeof(MainPage).GetTypeInfo().Assembly;
    Stream stream = assembly.GetManifestResourceStream("TreeViewXamarin.Data.navigation.json");
    using (StreamReader sr = new StreamReader(stream))
    {
        var jsonText = sr.ReadToEnd();
        ImageNodeInfo = new ObservableCollection<Countries>();
        var MyArrayData = JsonConvert.DeserializeObject<List<Countries>>(jsonText);
        foreach (var data in MyArrayData)
        {
            ImageNodeInfo.Add(data);
        }
    }
}
``` 
**STEP 3:** Bind the JSON collection data to the SfTreeView ItemSource.
``` xml
<syncfusion:SfTreeView x:Name="treeView"
                       ItemHeight="40"
                       Indentation="30"
                       ExpanderWidth="20"              
                       ItemsSource="{Binding ImageNodeInfo}" 
                       AutoExpandMode="RootNodesExpanded" NodePopulationMode="Instant">
    <syncfusion:SfTreeView.HierarchyPropertyDescriptors>
        <syncfusion1:HierarchyPropertyDescriptor TargetType="{x:Type local:Countries}" ChildPropertyName="States"/>
        <syncfusion1:HierarchyPropertyDescriptor TargetType="{x:Type local:States}" ChildPropertyName="Cities"/>
    </syncfusion:SfTreeView.HierarchyPropertyDescriptors>
    <syncfusion:SfTreeView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <Grid x:Name="grid" BackgroundColor="Transparent">
                    <Label LineBreakMode="WordWrap"
                                           Text="{Binding Name}"
                                           TextColor="Black"
                                           VerticalTextAlignment="Center"/>
                </Grid>
            </ViewCell>
        </DataTemplate>
    </syncfusion:SfTreeView.ItemTemplate>
</syncfusion:SfTreeView>
```
**Output**
![JSONTreeViewXamarin](https://github.com/SyncfusionExamples/json-treeview-xamarin/blob/main/ScreenShots/JSONTreeViewXamarin.gif)
