Module Module1

    Sub Main()
        Dim pList As List(Of Person) = New List(Of Person)()
        pList.Add(New Person(1, "John", "", "Shields", 29, "M"c))
        pList.Add(New Person(2, "Mary", "Matthew", "Jacobs", 35, "F"c))
        pList.Add(New Person(3, "Amber", "Carl", "Agar", 25, "M"c))
        pList.Add(New Person(4, "Kathy", "", "Berry", 21, "F"c))
        pList.Add(New Person(5, "Lena", "Ashco", "Bilton", 33, "F"c))
        pList.Add(New Person(6, "Susanne", "", "Buck", 45, "F"c))
        pList.Add(New Person(7, "Jim", "", "Brown", 38, "M"c))
        pList.Add(New Person(8, "Jane", "G", "Hooks", 32, "F"c))
        pList.Add(New Person(9, "Robert", "", "", 31, "M"c))
        pList.Add(New Person(10, "Cindy", "Preston", "Fox", 25, "F"c))
        pList.Add(New Person(11, "Gina", "", "Austin", 27, "F"c))
        pList.Add(New Person(12, "Joel", "David", "Benson", 33, "M"c))
        pList.Add(New Person(13, "George", "R", "Douglas", 55, "M"c))
        pList.Add(New Person(14, "Richard", "", "Banks", 22, "M"c))
        pList.Add(New Person(15, "Mary", "C", "Shaw", 39, "F"c))

        PrintOnConsole(pList, "1. --- Looping through all items in the List<T> ---")

        Dim filterOne As List(Of Person) = pList.FindAll(Function(p As Person) p.Age > 35)
        PrintOnConsole(filterOne, "2. --- Filtering List<T> on single condition (Age > 35) ---")

        Dim filterMultiple As List(Of Person) = pList.FindAll(Function(p As Person) p.Age > 35 AndAlso p.Sex = "F"c)
        PrintOnConsole(filterMultiple, "3. --- Filtering List<T> on multiple conditions (Age > 35 and Sex is Female) ---")

        Dim sortFName As List(Of Person) = pList
        sortFName.Sort(Function(p1 As Person, p2 As Person) p1.FirstName.CompareTo(p2.FirstName))
        PrintOnConsole(sortFName, "4. --- Sort List<T> (Sort on FirstName) ---")


        Dim sortLNameDesc As List(Of Person) = pList
        sortLNameDesc.Sort(Function(p1 As Person, p2 As Person) p2.LastName.CompareTo(p1.LastName))
        PrintOnConsole(sortLNameDesc, "5. --- Sort List<T> descending (Sort on LastName descending) ---")


        Dim newList As List(Of Person) = New List(Of Person)()
        newList.Add(New Person(16, "Geoff", "", "Fisher", 29, "M"c))
        newList.Add(New Person(17, "Samantha", "Carl", "Baxer", 32, "F"c))
        pList.AddRange(newList)
        PrintOnConsole(pList, "6. --- Add new List<T> to existing List<> ---")

        Dim removeList As List(Of Person) = pList
        removeList.RemoveAll(Function(p As Person) p.Sex = "M"c)
        PrintOnConsole(removeList, "7. --- Remove multiple items from List<> based on condition ---")

        Console.WriteLine("Create Read Only List<>")
        Dim personReadOnly As IList(Of Person) = pList
        Console.WriteLine("Before - Is List Read Only? True or False : " & personReadOnly.IsReadOnly)
        personReadOnly = pList.AsReadOnly()
        Console.WriteLine("After - Is List Read Only? True or False : " & personReadOnly.IsReadOnly & "</br>")
    End Sub


    Sub PrintOnConsole(ByVal pList As List(Of Person), ByVal info As String)
        Console.WriteLine(info)
        Console.WriteLine(vbLf & "{0,2} {1,7} {2,8} {3,8} {4,2} {5,3}", "ID", "FName", "MName", "LName", "Age", _
        "Sex")
        For Each per As Person In pList
            Console.WriteLine("{0,2} {1,7} {2,8} {3,8} {4,2} {5,3}", per.ID, per.FirstName, per.MiddleName, per.LastName, per.Age, per.Sex)
        Next
        Console.ReadLine()

    End Sub

End Module
