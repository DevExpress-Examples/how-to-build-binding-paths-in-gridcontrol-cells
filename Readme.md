<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/287469740/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T925591)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Build Binding Paths in WPF Data Grid Cells

![image](https://user-images.githubusercontent.com/65009440/186659717-090cf737-f4b1-44fb-91fe-1f1d1fb688ef.png)

Cell elements contain [EditGridCellData](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.EditGridCellData) objects in their [DataContext](https://docs.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement.datacontext).
Use the following binding paths to access cell values, columns, and ViewModel properties:

* `Value` - access the current cell value;
* `Column` - access the current column;
* `RowData.Row.[YourPropertyName]` - access a property of an object from the [ItemsSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.ItemsSource) collection;
* `Data.[FieldName]` - access column values in [Server Mode](https://docs.devexpress.com/WPF/9588/controls-and-libraries/data-grid/binding-to-data/server-mode), access [unbound column](https://docs.devexpress.com/WPF/6124/controls-and-libraries/data-grid/binding-to-data/unbound-columns) values;
* `View.DataContext.[YourPropertyName]` - access a property in the grid's ViewModel.


The bindings we use in this example work as follows:

* Bind `ComboBoxEdit.ItemsSource` to the `Countries` property of the grid's `ViewModel`:

```xml
<dxe:ComboBoxEdit x:Name="PART_Editor" DisplayMember="Name" ItemsSource="{Binding View.DataContext.Countries}" />
```
To assign the same `ItemsSource` collection to all editors in a column, use the [EditSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.EditSettings) property instead of [CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate) to gain better performance.

* Bind `ComboBoxEdit.ItemsSource` to the `Cities` property stored at the item level:

```xml
<dxe:ComboBoxEdit x:Name="PART_Editor" ItemsSource="{Binding RowData.Row.Country.Cities}" />
```

* Bind `Button.Visibility` to an unbound column value. The unbound column's `FieldName` is **Visited**:

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

You can also use the [CellToolTipBinding](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.BaseColumn.CellToolTipBinding) property to specify a tooltip for grid cells.

* Bind the cell `Background` to the `Color` property stored at the item level:

```xml
<!-- xmlns:dxmvvm="http://schemas.devexpress.com/winfx/2008/xaml/mvvm" -->
<Style.Triggers>
    <Trigger Property="SelectionState" Value="None">
        <Setter Property="Background" Value="{Binding RowData.Row.Color, Converter={dxmvvm:ColorToBrushConverter}}" />
    </Trigger>
</Style.Triggers>
```

## Files to Look at

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))

## Documentation

* [EditGridCellData](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.EditGridCellData)
* [CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate)
* [EditSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.EditSettings)
* [Assign Editors to Cells](https://docs.devexpress.com/WPF/401011/controls-and-libraries/data-grid/data-editing-and-validation/modify-cell-values/assign-an-editor-to-a-cell)
* [Choose Templates Based on Custom Logic](https://docs.devexpress.com/WPF/6677/controls-and-libraries/data-grid/appearance-customization/choosing-templates-based-on-custom-logic)

## More Examples

* [Build Binding Paths in WPF Data Grid Rows](https://github.com/DevExpress-Examples/how-to-build-binding-paths-in-gridcontrol-rows)
* [WPF Data Grid - Change a Cell Template Based on Custom Logic](https://github.com/DevExpress-Examples/wpf-data-grid-change-cell-template-based-on-custom-logic)
* [WPF Data Grid - Assign a ComboBox Editor to a Column](https://github.com/DevExpress-Examples/wpf-data-grid-assign-combobox-editor-to-column)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-build-binding-paths-in-gridcontrol-cells&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-build-binding-paths-in-gridcontrol-cells&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
