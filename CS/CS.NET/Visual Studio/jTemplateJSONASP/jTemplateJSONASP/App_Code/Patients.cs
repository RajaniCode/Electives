using System;
using System.Collections.Generic;

/// <summary>
/// Author:Aamir Hasan
/// Article Written for DotNetCurry.com
/// </summary>
public class Patients
{
    public List<Patient> getList()
    {
        List<Patient> Patients = new List<Patient>();
        Patients.Add(new Patient { ID = 1, FullName = "Aamir Hasan", Address = "-", PhoneNo = "3335494532", Gender = 'M' });
        Patients.Add(new Patient { ID = 2, FullName = "Awais Ahmed", Address = "-", PhoneNo = "-", Gender = 'M' });
        Patients.Add(new Patient { ID = 3, FullName = "Amir Hassan", Address = "-", PhoneNo = "12345678", Gender = 'M' });
        Patients.Add(new Patient { ID = 4, FullName = "Sobia Hina", Address = "-", PhoneNo = "-", Gender = 'F' });
        Patients.Add(new Patient { ID = 5, FullName = "Mahwish Hasan", Address = "-", PhoneNo = "65789544", Gender = 'F' });
        Patients.Add(new Patient { ID = 6, FullName = "Saba Khan", Address = "-", PhoneNo = "12345678", Gender = 'F' });
        Patients.Add(new Patient { ID = 7, FullName = "John ", Address = "-", PhoneNo = "877467889", Gender = 'M' });
        Patients.Add(new Patient { ID = 8, FullName = "Salman Khan", Address = "-", PhoneNo = "44772798", Gender = 'M' });
        Patients.Add(new Patient { ID = 9, FullName = "Nasir Hameed", Address = "-", PhoneNo = "543287", Gender = 'M' });

        return Patients;
    }

}

public class Patient
{
    public int ID { get; set; }
    public String FullName { get; set; }
    public string Address { get; set; }
    public string PhoneNo { get; set; }
    public char Gender { get; set; }
}