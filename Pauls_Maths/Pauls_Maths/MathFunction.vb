Imports System
Imports System.Drawing
Imports System.Math






'class that holds generic math functions
'
'############################
'Paul Anderson
'2011
'#############################

Public Class MathFunction

    'this meathod  retruns all the points on a given line for constarnt resolution
    Shared Function get_points_of_Line(ByRef sp As Point, ByRef ep As Point) As Point()

        Dim xDiff As Double = xDifference(sp, ep)

        Dim yDiff As Double = yDifference(sp, ep)

        Dim lLength As Double = LineLength(sp, ep)

        Dim steps As Double = lLength / 2 ' / 0.5 '<-- the reolution control is here , this is how many points you want to return along the line.

        Dim xStep As Double = xDiff / steps

        Dim yStep As Double = yDiff / steps

        Dim result(steps) As Point

        For i As Double = 0 To steps - 1 Step 1

            Dim x As Double = sp.X + (xStep * i)

            Dim y As Double = sp.Y + (yStep * i)

            result(i) = New Point(x, y)

        Next

        Return result

    End Function

    Shared Function nMM_from_SP(ByRef sp As Point, ByRef ep As Point, ByRef distance As Integer) As Point

        Dim xDiff As Double = xDifference(sp, ep)

        Dim yDiff As Double = yDifference(sp, ep)

        Dim steps As Double = LineLength(sp, ep)

        Dim xStep As Double = xDiff / steps

        Dim yStep As Double = yDiff / steps

        Dim x As Double = sp.X + (xStep * distance)

        Dim y As Double = sp.Y + (yStep * distance)

        Return New Point(x, y)

    End Function

    Shared Function xDifference(ByRef sp As Point, ByRef ep As Point) As Double

        Return ep.X - sp.X

    End Function

    Shared Function yDifference(ByRef sp As Point, ByRef ep As Point) As Double

        Return ep.Y - sp.Y

    End Function

    'Shared Function get_Vector(ByRef sp As Point, ByRef ep As Point) As Vector

    '    Return sp - ep

    'End Function

    Shared Function absoluteXdifference(ByRef sp As Point, ByRef ep As Point) As Double

        Return Math.Abs(sp.X - ep.X)

    End Function

    Shared Function absoluteYdifference(ByRef sp As Point, ByRef ep As Point) As Double

        Return Math.Abs(sp.Y - ep.Y)

    End Function

    Shared Function LineLength(ByRef sp As Point, ByRef ep As Point) As Integer

        If Not Double.IsNaN(sp.X) AndAlso Not Double.IsNaN(sp.Y) AndAlso Not Double.IsNaN(ep.X) AndAlso Not Double.IsNaN(ep.Y) Then

            Return CInt((Math.Sqrt((Math.Pow(absoluteXdifference(sp, ep), 2) + Math.Pow(absoluteYdifference(sp, ep), 2)))))

        Else

            Return 0

        End If

    End Function

    Shared Function midX(ByRef sp As Point, ByRef ep As Point) As Double

        Return Math.Abs((sp.X + ep.X) / 2)

    End Function

    Shared Function midY(ByRef sp As Point, ByRef ep As Point) As Double

        Return Math.Abs((sp.Y + ep.Y) / 2)

    End Function

    'returns the angle(degrees) formed between two vecotrs with different startpoints and a common end points (V shape)
    'Shared Function getangle(ByVal StartPoint As Point, ByVal EndPoint As Point, ByVal OtherStartPoint As Point) As Double

    '    'cosine rule
    '    'c^2 = b^2 + a^2 - 2baCOSc
    '    'therefore
    '    ' cos C = a^2+b^2-c^2 / 2ab


    '    'make line length long so as to increase angle calculation accuracy for small bend lengths (eg 10mm x 10 mm)

    '    Dim v1, v2 As Vector
    '    v1 = EndPoint - StartPoint
    '    v2 = OtherStartPoint - StartPoint
    '    v1.Normalize()
    '    v2.Normalize()
    '    v1 *= 100000
    '    v2 *= 100000

    '    EndPoint += v1
    '    OtherStartPoint += v2


    '    Dim lnth As Double = LineLength(OtherStartPoint, EndPoint)

    '    Dim a, b, c, asqr, bsrq, csqr As Double

    '    a = LineLength(OtherStartPoint, StartPoint)

    '    b = LineLength(StartPoint, EndPoint)

    '    c = LineLength(OtherStartPoint, EndPoint)

    '    asqr = a * a

    '    bsrq = b * b

    '    csqr = c * c

    '    Dim COSc As Double = (asqr + bsrq - csqr) / (2 * a * b)

    '    Dim angle As Double = Math.Acos(COSc)

    '    Return Math.Floor(angle * (180 / Math.PI)) ' 0)
    '    ' Return Math.Round(angle * (180 / Math.PI), 0)

    'End Function
    'Shared Function Intersect_point(ByVal a As LineGeometry, ByVal b As LineGeometry) As Point
    '    Dim isectpoint As Point

    '    Dim a1, b1, c1 As Double
    '    a1 = a.EndPoint.Y - a.StartPoint.Y
    '    b1 = a.StartPoint.X - a.EndPoint.X
    '    c1 = (a1 * a.StartPoint.X) + (b1 * a.StartPoint.Y)

    '    Dim a2, b2, c2 As Double
    '    a2 = b.EndPoint.Y - b.StartPoint.Y
    '    b2 = b.StartPoint.X - b.EndPoint.X
    '    c2 = (a2 * b.StartPoint.X) + (b2 * b.StartPoint.Y)

    '    Dim det As Double = (a1 * b2) - (a2 * b1)
    '    If Not det = 0 Then
    '        Dim dx, dy As Double
    '        dx = (b2 * c1 - b1 * c2) / det
    '        dy = (a1 * c2 - a2 * c1) / det
    '        isectpoint = New Point(dx, dy)

    '    End If
    '    Return isectpoint
    'End Function
    Shared Function CloseEnough(ByVal value As Double, ByVal comparedtoo As Integer) As Boolean
        comparedtoo = Math.Abs(comparedtoo)
        Dim hi, lo As Integer
        hi = comparedtoo + 2
        lo = comparedtoo - 2
        If value >= lo AndAlso value <= hi Then
            Return True
        Else
            Return False
        End If



    End Function
End Class
