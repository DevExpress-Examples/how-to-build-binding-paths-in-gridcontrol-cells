# How to build binding paths in GridControl cells

Cell elements contain [EditGridCellData](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.EditGridCellData) objects in their [DataContext](https://docs.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement.datacontext). 
Use the following binding paths to access cell values, columns, and ViewModel properties:
* `Value` - access the current cell value;
* `Column` - access the current column;
* `RowData.Row.[YourPropertyName]` - access a property of an object from the [ItemsSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.ItemsSource) collection;
* `Data.[FieldName]` - access column values in [Server Mode](https://docs.devexpress.com/WPF/9588/controls-and-libraries/data-grid/binding-to-data/server-mode), access [unbound column](https://docs.devexpress.com/WPF/6124/controls-and-libraries/data-grid/binding-to-data/unbound-columns) values;
* `View.DataContext.[YourPropertyName]` - access a property in the grid's ViewModel.
