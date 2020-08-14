# How to build binding paths in GridControl cells

Cell elements contain [EditGridCellData](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.EditGridCellData) objects in their [DataContext](https://docs.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement.datacontext).
Use the following binding paths to access cell values, columns, and ViewModel properties:

* `Value` - access the current cell value;
* `Column` - access the current column;
* `RowData.Row.[YourPropertyName]` - access a property of an object from the [ItemsSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.ItemsSource) collection;
* `Data.[FieldName]` - access column values in [Server Mode](https://docs.devexpress.com/WPF/9588/controls-and-libraries/data-grid/binding-to-data/server-mode), access [unbound column](https://docs.devexpress.com/WPF/6124/controls-and-libraries/data-grid/binding-to-data/unbound-columns) values;
* `View.DataContext.[YourPropertyName]` - access a property in the grid's ViewModel.


The bindings we used in this example work as follows.

* Bind `ComboBoxEdit.ItemsSource` to the `Countries` property of the grid's `ViewModel`:

```xml
<dxe:ComboBoxEdit x:Name="PART_Editor" DisplayMember="Name" ItemsSource="{Binding View.DataContext.Countries}" />
```
**IMPORTANT:** If you wish to assign the same `ItemsSource` collection to all editors in a column, use the [EditSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.EditSettings) property instead of `CellTemplate` to gain better performance.

* Bind `ComboBoxEdit.ItemsSource` to the `Cities` properties stored at the item level:

```xml
<dxe:ComboBoxEdit x:Name="PART_Editor" ItemsSource="{Binding RowData.Row.Country.Cities}" />
```

* Bind `Button.Visibility` to an unbound column value. The unbound column's `FieldName` is "Visited":

```xml
<Button Visibility="{Binding Data.Visited, Converter={dx:BooleanToVisibilityConverter}}">Hide</Button>
```

* Bind `ToolTip` to display `FieldName` of the current column and a cell value:

```xml
<Setter Property="ToolTip">
    <Setter.Value>
        <MultiBinding Converter="{local:CellTooltipConverter}">
            <Binding Path="Column.FieldName" />
            <Binding Path="Value" />
        </MultiBinding>
    </Setter.Value>
</Setter>
```

**IMPORTANT:** You can use the [CellToolTipBinding](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.BaseColumn.CellToolTipBinding) property to specify a tooltip for grid cells.

* Bind cells' `Background` to the `Color` properties stored at the item level:

```xml
<!-- xmlns:dxmvvm="http://schemas.devexpress.com/winfx/2008/xaml/mvvm" -->
<Style.Triggers>
    <Trigger Property="SelectionState" Value="None">
        <Setter Property="Background" Value="{Binding RowData.Row.Color, Converter={dxmvvm:ColorToBrushConverter}}" />
    </Trigger>
</Style.Triggers>
```