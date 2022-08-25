Imports System
Imports System.Windows
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Windows.Data
Imports System.Windows.Markup
Imports DevExpress.Mvvm
Imports System.Windows.Media

Namespace DXGridSample

    Public Partial Class MainWindow
        Inherits System.Windows.Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub
    End Class

    Public Class ViewModel
        Inherits DevExpress.Mvvm.BindableBase

        Public Property Countries As ObservableCollection(Of DXGridSample.Country)
            Get
                Return GetValue(Of System.Collections.ObjectModel.ObservableCollection(Of DXGridSample.Country))()
            End Get

            Set(ByVal value As ObservableCollection(Of DXGridSample.Country))
                SetValue(value)
            End Set
        End Property

        Public Property Items As ObservableCollection(Of DXGridSample.Item)
            Get
                Return GetValue(Of System.Collections.ObjectModel.ObservableCollection(Of DXGridSample.Item))()
            End Get

            Set(ByVal value As ObservableCollection(Of DXGridSample.Item))
                SetValue(value)
            End Set
        End Property

        Public Sub New()
            Me.Countries = New System.Collections.ObjectModel.ObservableCollection(Of DXGridSample.Country) From {New DXGridSample.Country With {.Name = "USA", .Cities = New System.Collections.ObjectModel.ObservableCollection(Of String) From {"Washington, D.C.", "New York", "Los Angeles", "Las Vegas"}}, New DXGridSample.Country With {.Name = "Germany", .Cities = New System.Collections.ObjectModel.ObservableCollection(Of String) From {"Berlin", "Munich", "Frankfurt"}}, New DXGridSample.Country With {.Name = "Russia", .Cities = New System.Collections.ObjectModel.ObservableCollection(Of String) From {"Moscow", "Saint-Petersburg"}}}
            Me.Items = New System.Collections.ObjectModel.ObservableCollection(Of DXGridSample.Item)()
            Dim i As Integer = 0
            For Each country In Me.Countries
                Me.Items.Add(New DXGridSample.Item With {.Country = country, .Visits = System.Math.Min(System.Threading.Interlocked.Increment(i), i - 1)})
            Next
        End Sub
    End Class

    Public Class Item
        Inherits DevExpress.Mvvm.BindableBase

        Public Property Country As Country
            Get
                Return GetValue(Of DXGridSample.Country)()
            End Get

            Set(ByVal value As Country)
                SetValue(value)
                Me.City = value?.Cities(0)
            End Set
        End Property

        Public Property City As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Property Visits As Integer
            Get
                Return GetValue(Of Integer)()
            End Get

            Set(ByVal value As Integer)
                SetValue(value)
            End Set
        End Property

        Public Property Color As Color
            Get
                Return GetValue(Of System.Windows.Media.Color)()
            End Get

            Set(ByVal value As Color)
                SetValue(value)
            End Set
        End Property
    End Class

    Public Class Country
        Inherits DevExpress.Mvvm.BindableBase

        Public Property Name As String
            Get
                Return GetValue(Of String)()
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Property Cities As ObservableCollection(Of String)
            Get
                Return GetValue(Of System.Collections.ObjectModel.ObservableCollection(Of String))()
            End Get

            Set(ByVal value As ObservableCollection(Of String))
                SetValue(value)
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
    End Class

    Public Class CellTooltipConverter
        Inherits System.Windows.Markup.MarkupExtension
        Implements System.Windows.Data.IMultiValueConverter

        Public Function Convert(ByVal values As Object(), ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements Global.System.Windows.Data.IMultiValueConverter.Convert
            Return If(values(0) IsNot Nothing AndAlso values(1) IsNot Nothing, String.Format("{0}: {1}", values(0), values(1)), Nothing)
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetTypes As System.Type(), ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object() Implements Global.System.Windows.Data.IMultiValueConverter.ConvertBack
            Throw New System.NotImplementedException()
        End Function

        Public Overrides Function ProvideValue(ByVal serviceProvider As System.IServiceProvider) As Object
            Return Me
        End Function
    End Class
End Namespace
