Imports System.Data
Imports System.Windows.Forms

Namespace Q205299
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            Dim dataSet11 As New DataSet()
            dataSet11.Tables.Add(GetCustomerDataTable())
            dataSet11.Tables.Add(GetPersonDataTable())
            Dim keyColumn As DataColumn = dataSet11.Tables("Customers").Columns("ID")
            Dim foreignKeyColumn As DataColumn = dataSet11.Tables("Persons").Columns("ID")
            dataSet11.Relations.Add("CustomersPersons", keyColumn, foreignKeyColumn)

            bindingSource1.DataSource = dataSet11
            bindingSource1.DataMember = "Customers"
            bindingSource2.DataSource = bindingSource1
            bindingSource2.DataMember = "CustomersPersons"

            gridControl1.DataSource = bindingSource1
            gridControl2.DataSource = bindingSource2
        End Sub
        Private Function GetCustomerDataTable() As DataTable
            Dim table As New DataTable()
            table.TableName = "Customers"
            table.Columns.Add(New DataColumn("Items", GetType(String)))
            table.Columns.Add(New DataColumn("Money", GetType(Double)))
            table.Columns.Add(New DataColumn("ID", GetType(Integer)))
            For i As Integer = 0 To 9
                table.Rows.Add("Product " & i, 3000 + i * 298.55D, i)
            Next i
            Return table
        End Function
        Private Function GetPersonDataTable() As DataTable
            Dim table As New DataTable()
            table.TableName = "Persons"
            table.Columns.Add(New DataColumn("FirstName", GetType(String)))
            table.Columns.Add(New DataColumn("SecondName", GetType(String)))
            table.Columns.Add(New DataColumn("Age", GetType(Integer)))
            table.Columns.Add(New DataColumn("ID", GetType(Integer)))
            For i As Integer = 0 To 49

                Dim name_Renamed As String = "Adam"
                Dim secondName As String = "Smith"
                If i Mod 2 = 0 Then
                    name_Renamed = "Ben"
                    secondName = "Black"
                End If
                table.Rows.Add(name_Renamed, secondName, 20 + i \ 2, i Mod 10)
            Next i
            Return table
        End Function
    End Class
End Namespace