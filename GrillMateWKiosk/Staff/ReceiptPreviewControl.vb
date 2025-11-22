Imports System.Windows.Forms

Public Class ReceiptPreviewControl
    Inherits UserControl

    ' Reference to OrderInfo structure from UC_Billing
    Public Structure OrderInfo
        Public OrderID As Integer
        Public OrderNumber As String
        Public OrderDate As DateTime
        Public OrderType As String
        Public OrderStatus As String
        Public TableNumber As String
        Public Items As List(Of OrderItemInfo)
        Public Subtotal As Decimal
        Public Discount As Decimal
        Public Tax As Decimal
        Public TotalAmount As Decimal
        Public HasPwdDiscount As Boolean
    End Structure

    Public Structure OrderItemInfo
        Public ProductName As String
        Public Quantity As Integer
        Public Price As Decimal
        Public Subtotal As Decimal
    End Structure

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub GeneratePreview(orderInfo As OrderInfo)
        Dim receipt As String = GenerateReceiptText(orderInfo)
        txtReceiptPreview.Text = receipt
    End Sub

    Public Function GenerateReceiptText(orderInfo As OrderInfo) As String
        Dim receipt As String = ""
        receipt &= "=========================================" & vbCrLf
        receipt &= "            GRILL MATE POS              " & vbCrLf
        receipt &= "=========================================" & vbCrLf
        receipt &= "Order Number: " & orderInfo.OrderNumber & vbCrLf
        receipt &= "Date: " & orderInfo.OrderDate.ToString("MM/dd/yyyy HH:mm") & vbCrLf
        receipt &= "Type: " & orderInfo.OrderType & vbCrLf
        If orderInfo.OrderType = "Dine-In" Then
            receipt &= "Table: " & orderInfo.TableNumber & vbCrLf
        End If
        receipt &= "-----------------------------------------" & vbCrLf
        receipt &= "Items:" & vbCrLf

        For Each item In orderInfo.Items
            receipt &= item.ProductName.PadRight(20) & vbCrLf
            receipt &= ("  " & item.Quantity.ToString() & " x ₱" & item.Price.ToString("N2")).PadRight(15) & "₱" & item.Subtotal.ToString("N2") & vbCrLf
        Next

        receipt &= "-----------------------------------------" & vbCrLf
        receipt &= ("Subtotal:".PadRight(35) & "₱" & orderInfo.Subtotal.ToString("N2")) & vbCrLf
        If orderInfo.Discount > 0 Then
            receipt &= ("Discount (20%):".PadRight(35) & "-₱" & orderInfo.Discount.ToString("N2")) & vbCrLf
        End If
        If orderInfo.Tax > 0 Then
            receipt &= ("Tax VAT (12%):".PadRight(35) & "₱" & orderInfo.Tax.ToString("N2")) & vbCrLf
        ElseIf orderInfo.HasPwdDiscount Then
            receipt &= ("Tax VAT:".PadRight(35) & "₱0.00 (Exempt)") & vbCrLf
        End If
        receipt &= ("TOTAL:".PadRight(35) & "₱" & orderInfo.TotalAmount.ToString("N2")) & vbCrLf
        receipt &= "=========================================" & vbCrLf
        receipt &= "Thank you for your business!" & vbCrLf
        receipt &= "=========================================" & vbCrLf
        Return receipt
    End Function

    Public Sub Clear()
        txtReceiptPreview.Clear()
    End Sub
End Class
