' articles for codeguru
Module Module1

  Sub Main()

    Dim xml = <pets>
                <pet>
                  <id>2</id>
                  <name>Dog</name>
                  <species>Some Kind of Cat</species>
                  <sex>Female</sex>
                  <startYear>1972</startYear>
                  <endYear>1974</endYear>
                  <causeOfDeath>Car</causeOfDeath>
                  <specialQuality>Best mouser</specialQuality>
                </pet>
              </pets>

    Dim test = From pet In xml.Elements("pet").Elements("name") _
               Select pet


    Console.WriteLine(test.Value)
    Console.ReadLine()

  End Sub

End Module
