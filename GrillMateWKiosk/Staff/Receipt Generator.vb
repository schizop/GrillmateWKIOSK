Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure
Imports System.IO

Public Class Receipt_Generator

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

    Public Function GeneratePdfReceipt(orderInfo As OrderInfo) As String
        ' Create PDF file path
        Dim fileName As String = "Receipt_" & orderInfo.OrderNumber.Replace("-", "_") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"
        Dim pdfPath As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, fileName)
        
        ' Generate PDF using QuestPDF
        QuestPDF.Settings.License = LicenseType.Community
        
        Document.Create(Sub(container)
            container.Page(Sub(page)
                page.Size(PageSizes.A4)
                page.Margin(2, Unit.Centimetre)
                page.PageColor(Colors.White)
                
                page.Content().Column(Sub(column)
                    column.Spacing(0.5, Unit.Centimetre)
                    
                    ' Header
                    column.Item().AlignCenter().Text("GRILL MATE POS").FontSize(20).Bold()
                    column.Item().LineHorizontal(1).LineColor(Colors.Black)
                    column.Item().PaddingTop(0.5, Unit.Centimetre)
                    
                    ' Order Information
                    column.Item().Text("Order Number: " & orderInfo.OrderNumber)
                    column.Item().Text("Date: " & orderInfo.OrderDate.ToString("MM/dd/yyyy HH:mm"))
                    column.Item().Text("Type: " & orderInfo.OrderType)
                    If orderInfo.OrderType = "Dine-In" Then
                        column.Item().Text("Table: " & orderInfo.TableNumber)
                    End If
                    
                    column.Item().PaddingTop(0.5, Unit.Centimetre)
                    column.Item().LineHorizontal(1).LineColor(Colors.Black)
                    column.Item().PaddingTop(0.5, Unit.Centimetre)
                    
                    ' Items Header
                    column.Item().Row(Sub(row)
                        row.RelativeItem(3).Text("Item").Bold()
                        row.ConstantItem(50).Text("Qty").Bold().AlignCenter()
                        row.RelativeItem(2).Text("Price").Bold().AlignRight()
                        row.RelativeItem(2).Text("Subtotal").Bold().AlignRight()
                    End Sub)
                    
                    column.Item().LineHorizontal(0.5).LineColor(Colors.Grey.Lighten2)
                    
                    ' Items
                    For Each item In orderInfo.Items
                        column.Item().Row(Sub(row)
                            row.RelativeItem(3).Text(item.ProductName)
                            row.ConstantItem(50).Text(item.Quantity.ToString()).AlignCenter()
                            row.RelativeItem(2).Text("₱" & item.Price.ToString("N2")).AlignRight()
                            row.RelativeItem(2).Text("₱" & item.Subtotal.ToString("N2")).AlignRight()
                        End Sub)
                    Next
                    
                    column.Item().PaddingTop(0.5, Unit.Centimetre)
                    column.Item().LineHorizontal(1).LineColor(Colors.Black)
                    column.Item().PaddingTop(0.5, Unit.Centimetre)
                    
                    ' Totals
                    column.Item().Row(Sub(row)
                        row.RelativeItem().Text("Subtotal:")
                        row.RelativeItem().Text("₱" & orderInfo.Subtotal.ToString("N2")).AlignRight()
                    End Sub)
                    
                    If orderInfo.Discount > 0 Then
                        column.Item().Row(Sub(row)
                            row.RelativeItem().Text("Discount (20%):")
                            row.RelativeItem().Text("-₱" & orderInfo.Discount.ToString("N2")).AlignRight()
                        End Sub)
                    End If
                    
                    If orderInfo.Tax > 0 Then
                        column.Item().Row(Sub(row)
                            row.RelativeItem().Text("Tax VAT (12%):")
                            row.RelativeItem().Text("₱" & orderInfo.Tax.ToString("N2")).AlignRight()
                        End Sub)
                    ElseIf orderInfo.HasPwdDiscount Then
                        column.Item().Row(Sub(row)
                            row.RelativeItem().Text("Tax VAT:")
                            row.RelativeItem().Text("₱0.00 (Exempt)").AlignRight()
                        End Sub)
                    End If
                    
                    column.Item().PaddingTop(0.3, Unit.Centimetre)
                    column.Item().LineHorizontal(1).LineColor(Colors.Black)
                    column.Item().PaddingTop(0.3, Unit.Centimetre)
                    
                    column.Item().Row(Sub(row)
                        row.RelativeItem().Text("TOTAL:").Bold().FontSize(12)
                        row.RelativeItem().Text("₱" & orderInfo.TotalAmount.ToString("N2")).Bold().FontSize(12).AlignRight()
                    End Sub)
                    
                    column.Item().PaddingTop(1, Unit.Centimetre)
                    column.Item().AlignCenter().Text("Thank you for your business!").FontSize(10)
                End Sub)
            End Sub)
        End Sub).GeneratePdf(pdfPath)
        
        Return pdfPath
    End Function
End Class
