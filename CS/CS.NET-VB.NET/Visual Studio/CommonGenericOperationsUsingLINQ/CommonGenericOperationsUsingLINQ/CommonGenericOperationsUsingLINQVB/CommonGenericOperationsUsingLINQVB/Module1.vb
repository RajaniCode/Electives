Module Module1

    Sub Main()
        Dim Person = TypeCreator.TypeGenerator(New Object() { _
            New With {.ID = 1, .FirstName = "John", .MiddleName = "", .LastName = "Shields", .Age = 29, .Sex = "M"c}, _
            New With {.ID = 2, .FirstName = "Mary", .MiddleName = "Matthew", .LastName = "Shields", .Age = 29, .Sex = "M"c}, _
            New With {.ID = 3, .FirstName = "Amber", .MiddleName = "Carl", .LastName = "Shields", .Age = 29, .Sex = "M"c}, _
            New With {.ID = 4, .FirstName = "Kathy", .MiddleName = "", .LastName = "Shields", .Age = 29, .Sex = "M"c}})

        Person.PrintToConsole()

        Dim Products = TypeCreator.TypeGenerator(New Object() { _
             New With {.PID = 1, .ProductName = "Chai", .Quantity = 12, .Price = 18.1}, _
             New With {.PID = 2, .ProductName = "Coffee", .Quantity = 23, .Price = 28.2}, _
             New With {.PID = 3, .ProductName = "Chains", .Quantity = 42, .Price = 21.6}, _
             New With {.PID = 4, .ProductName = "Chips", .Quantity = 21, .Price = 21.2}})

        Products.PrintToConsole()
    End Sub

End Module

