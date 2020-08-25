Imports System
Imports System.Windows
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Windows.Data
Imports System.Windows.Markup
Imports DevExpress.Mvvm
Imports System.Windows.Media

Namespace DXGridSample
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
	Public Class ViewModel
		Inherits BindableBase

		Public Property Countries() As ObservableCollection(Of Country)
			Get
				Return GetValue(Of ObservableCollection(Of Country))()
			End Get
			Set(ByVal value As ObservableCollection(Of Country))
				SetValue(value)
			End Set
		End Property
		Public Property Items() As ObservableCollection(Of Item)
			Get
				Return GetValue(Of ObservableCollection(Of Item))()
			End Get
			Set(ByVal value As ObservableCollection(Of Item))
				SetValue(value)
			End Set
		End Property

		Public Sub New()
			Countries = New ObservableCollection(Of Country) _
				From {
					New Country With {
						.Name = "USA",
						.Cities = New ObservableCollection(Of String) From {"Washington, D.C.", "New York", "Los Angeles", "Las Vegas"}
					},
					New Country With {
						.Name = "Germany",
						.Cities = New ObservableCollection(Of String) From {"Berlin", "Munich", "Frankfurt"}
					},
					New Country With {
						.Name = "Russia",
						.Cities = New ObservableCollection(Of String) From {"Moscow", "Saint-Petersburg"}
					}
				}

			Items = New ObservableCollection(Of Item)()
			Dim i As Integer = 0
			For Each country In Countries
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: Items.Add(new Item { Country = country, Visits = i++ });
				Items.Add(New Item With {
					.Country = country,
					.Visits = i
				})
				i += 1
			Next country
		End Sub
	End Class
	Public Class Item
		Inherits BindableBase

		Public Property Country() As Country
			Get
				Return GetValue(Of Country)()
			End Get
			Set(ByVal value As Country)
				SetValue(value)
				City = value?.Cities(0)
			End Set
		End Property
		Public Property City() As String
			Get
				Return GetValue(Of String)()
			End Get
			Set(ByVal value As String)
				SetValue(value)
			End Set
		End Property
		Public Property Visits() As Integer
			Get
				Return GetValue(Of Integer)()
			End Get
			Set(ByVal value As Integer)
				SetValue(value)
			End Set
		End Property
		Public Property Color() As Color
			Get
				Return GetValue(Of Color)()
			End Get
			Set(ByVal value As Color)
				SetValue(value)
			End Set
		End Property
	End Class
	Public Class Country
		Inherits BindableBase

		Public Property Name() As String
			Get
				Return GetValue(Of String)()
			End Get
			Set(ByVal value As String)
				SetValue(value)
			End Set
		End Property
		Public Property Cities() As ObservableCollection(Of String)
			Get
				Return GetValue(Of ObservableCollection(Of String))()
			End Get
			Set(ByVal value As ObservableCollection(Of String))
				SetValue(value)
			End Set
		End Property
		Public Overrides Function ToString() As String
			Return Name
		End Function
	End Class
	Public Class CellTooltipConverter
		Inherits MarkupExtension
		Implements IMultiValueConverter

		Public Function Convert(ByVal values() As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
			Return If(values(0) IsNot Nothing AndAlso values(1) IsNot Nothing, String.Format("{0}: {1}", values(0), values(1)), Nothing)
		End Function
		Public Function ConvertBack(ByVal value As Object, ByVal targetTypes() As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
		Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
			Return Me
		End Function
	End Class
End Namespace